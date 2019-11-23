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

        private List<PostSectionViewModel> MapSectionsEntitiesToViewModel(
            List<PostSection> postSections
        )
        {
            return postSections?.Select(postSection => 
                new PostSectionViewModel()
                {
                    Title = postSection.Title,
                    Content = postSection.Content,
                    Subsections = MapSectionsEntitiesToViewModel(postSection.Subsections)
                }
            ).ToList();
        }

        /// <summary>
        /// Creates a new post in a blog
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="postPayload"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns sections for a given post position
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="position"></param>
        /// <returns> Post sections </returns>
        [HttpGet]
        [Route("{position}")]
        public IActionResult GetSubsectionsByPost(string owner, int position)
        {
            var blog = blogRepository.GetByOwner(owner);

            if (blog == null)
            {
                return NotFound("Owner does not exist."); 
            }

            if(blog.Posts.Count < position)
            {
                return NotFound("Post not found.");
            }

            var postId = blog.Posts[blog.Posts.Count - position].Id;

            var postSections = postSectionRepository.GetByPostId(postId);

                    
            return new ObjectResult( postSections.Select(postSection => new PostSectionViewModel()
            {
                Title = postSection.Title,
                Content = postSection.Content,
                Subsections = MapSectionsEntitiesToViewModel(postSection.Subsections)
            }).ToList()
            );
        }

    }
}