using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestfulAPI.Helpers;
using RestfulAPI.Models;
using RestfulAPI.ResourceParameters;
using RestfulAPI.Services;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IRestfulApiRepository _repo;
        private readonly IMapper _mapper;

        public AuthorsController(IRestfulApiRepository repo,IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorsDto>> GetAuthors([FromQuery]AuthorsResourceParameters parameters)
        {

            var authorsFromRepo = _repo.GetAuthors(parameters);
           
            return Ok(_mapper.Map<IEnumerable<AuthorsDto>>(authorsFromRepo));
        }
        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
           
            var authorFromRepo = _repo.GetAuthor(authorId);
            if (authorFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorsDto>(authorFromRepo));
        }

    }
}
