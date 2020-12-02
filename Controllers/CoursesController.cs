using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Models;
using RestfulAPI.Services;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IRestfulApiRepository _repo;
        private readonly IMapper _mapper;

        public CoursesController(IRestfulApiRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public ActionResult<IEnumerable<CoursesDto>> GetCoursesForAuthor(Guid authorId)
        {
            if (!_repo.AuthorExists(authorId))
            {
                return NotFound();
            }

            var coursesFromRepo = _repo.GetCourses(authorId);
            return Ok(_mapper.Map<IEnumerable<CoursesDto>>(coursesFromRepo));
        }
        [HttpGet("{courseId}")]
        public ActionResult<CoursesDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            if (!_repo.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseFromRepo = _repo.GetCourse(authorId, courseId);
            if (courseFromRepo ==null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CoursesDto>(courseFromRepo));
        }
    }
}