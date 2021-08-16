using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Web.Models.Catalog;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCoursesAsync();
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<List<CourseViewModel>> GetAllCoursesByUserIdAsync(string userId);
        Task<CourseViewModel> GetCourseById(string courseId);
        Task<bool> CreateCourseAsync(CourseCreateInput course);
        Task<bool> UpdateCourseAsync(CourseUpdateInput course);
        Task<bool> DeleteCourseAsync(string courseId);
    }
}
