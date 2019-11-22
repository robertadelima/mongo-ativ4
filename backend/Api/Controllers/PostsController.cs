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
    [Route("blogs/{username}")]
    public class PostsController : ControllerBase
    {
        private readonly PostRepository postRepository;

        public PostsController(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        private List<PostSection> MapSectionsPayloadToEntities(
            List<PostSectionPayload> postSectionsPayload,
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
        public IActionResult CreatePost([FromBody] PostSectionPayload postPayload)
        {
            if (postPayload == null)
            {
                return BadRequest();
            }
            
            var post = new Post(postPayload.Title, postPayload.Content);
            var postSections = MapSectionsPayloadToEntities(postPayload.Subsections, post);
            
            post.Sections.AddRange(postSections);
            
            postRepository.Add(post);

            return Ok();
        }

        [HttpDelete]
        [Route("{title}")]
        public IActionResult Delete(string title)
        {
            var post = postRepository.GetByTitle(title);
            if (post == null)
            {
                return NotFound();
            }
            
            postRepository.RemoveByTitle(title);

            return new NoContentResult();
        }
    }
}