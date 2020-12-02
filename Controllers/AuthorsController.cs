using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulAPI.Services;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IRestfulApiRepository _repo;

        public AuthorsController(IRestfulApiRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _repo.GetAuthors();
            return Ok(authorsFromRepo);
        }
        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
           
            var authorFromRepo = _repo.GetAuthor(authorId);
            if (authorFromRepo == null)
            {
                return NotFound();
            }
            return Ok(authorFromRepo);
        }

    }
}
