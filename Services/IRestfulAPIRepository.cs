using System;
using System.Collections.Generic;
using RestfulAPI.Entities;
using RestfulAPI.ResourceParameters;

namespace RestfulAPI.Services
{
    public interface IRestfulApiRepository
    {
        void AddCourse(Guid authorId, Course course);
        void DeleteCourse(Course course);
        Course GetCourse(Guid authorId, Guid courseId);
        IEnumerable<Course> GetCourses(Guid authorId);
        void UpdateCourse(Course course);
        void AddAuthor(Author author);
        bool AuthorExists(Guid authorId);
        void DeleteAuthor(Author author);
        Author GetAuthor(Guid authorId);
        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(AuthorsResourceParameters parameters);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        void UpdateAuthor(Author author);
        bool Save();
        void Dispose();
    }
}