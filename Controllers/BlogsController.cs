
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ativ4Mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogRepository blogRepository;

        public BlogsController(BlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        [HttpGet]
        public IEnumerable<BlogsViewModel> Get()
        {
            return blogRepository.getBlogs()
                .Select(entidade => new BlogsViewModel() {
                    Title = entidade.title,
                    Summary = entidade.description,
                    PublishDate = DateTime.Now
                } );
        }
    }
}
