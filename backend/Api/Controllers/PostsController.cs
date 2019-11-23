using Ativ4Mongo.backend.Api.Payloads;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Domain;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ativ4Mongo.backend.Api.Controllers
{
    [ApiController]
    [Route("blogs/{owner}")]
    public class PostsController : ControllerBase
    {
        private readonly PostSectionRepository postSectionRepository;
        private readonly BlogRepository blogRepository;

        public PostsController(PostSectionRepository postSectionRepository, BlogRepository blogRepository)
        {
            this.postSectionRepository = postSectionRepository;
            this.blogRepository = blogRepository;
        }

        private List<PostSection> MapSectionsPayloadToEntities(
            List<NewPostPayload> postSectionsPayload,
            Post post
        )
        {
            return postSectionsPayload?.Select(sectionPayload => 
                new PostSection(
                    post,
                    sectionPayload.Title,
                    sectionPayload.Content,
                    MapSectionsPayloadToEntities(sectionPayload.Subsections, post)
                )
            ).ToList();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePost(string owner, [FromBody] NewPostPayload postPayload)
        {
            if (string.IsNullOrEmpty(owner) || postPayload == null)
            {
                return BadRequest();
            }
            
            var post = new Post(postPayload.Title, postPayload.Content);
            blogRepository.AddPostToBlogByOwner(owner, post);

            var postSections = MapSectionsPayloadToEntities(postPayload.Subsections, post);
            postSectionRepository.Add(postSections);

            return Ok();
        }

        /*
        [HttpDelete]
        [Route("{title}")]
        public IActionResult Delete(string title)
        {
            var post = 
            if (post == null)
            {
                return NotFound();
            }
            
            postSectionRepository.RemoveByTitle(title);

            return new NoContentResult();
        }
        */
    }
}