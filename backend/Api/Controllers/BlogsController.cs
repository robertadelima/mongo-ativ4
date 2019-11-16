
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Domain;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ativ4Mongo.backend.Api.Controllers
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


        //TODO não está mapeando o atributo do tipo Owner para a view model direito
        //
        [HttpGet]
        [Route("")]
        public IEnumerable<BlogsViewModel> Get()
        {
            return blogRepository.getBlogs()
                .Select(entidade => new BlogsViewModel() {
                    Id = entidade._id,
                    Title = entidade.title,
                    Owner = entidade.owner,
                    /*OwnerName = entidade.owner.name,
                    OwnerUsername = entidade.owner.username,
                    OwnerPassword = entidade.owner.password,*/

                    /*Owner = new Domain.Owner() {
                        name = entidade.owner.name != null ? entidade.owner.name : "",
                        username = entidade.owner.username != null ? entidade.owner.username : "",
                        password = entidade.owner.password != null ? entidade.owner.password : ""
                    },*/
                    Description = entidade.description,
                    
                } );
        }

        //feito para deixar estrutura pronta
        //provavelmente será getById
        [HttpGet]
        [Route("{title}")]
        public IEnumerable<BlogsViewModel> GetByTitle(string title)
        {
            //falta considerar caso em que o titulo não existe
            return blogRepository.getBlogsByTitle(title)
                .Select(entidade => new BlogsViewModel() {
                    Id = entidade._id,
                    Title = entidade.title,
                    Owner = entidade.owner, //NOT WORKING
                    /*OwnerName = entidade.owner.name,              //WORKS BUT NOT EMBEDDED
                    OwnerUsername = entidade.owner.username,
                    OwnerPassword = entidade.owner.password,*/

                        /*Owner = new Domain.Owner() {               //NOT WORKING
                        name = entidade.owner.name != null ? entidade.owner.name : "",
                        username = entidade.owner.username != null ? entidade.owner.username : "",
                        password = entidade.owner.password != null ? entidade.owner.password : ""*/
                    Description = entidade.description,
                    
                } );
        }     
 


    }
}
