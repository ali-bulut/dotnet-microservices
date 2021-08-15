using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FreeCourse.Web.Models.Catalog
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string UserId { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        [Display(Name = "Upload an Image")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
