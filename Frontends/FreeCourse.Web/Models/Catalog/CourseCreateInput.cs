﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FreeCourse.Web.Models.Catalog
{
    public class CourseCreateInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string UserId { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Display(Name = "Upload an Image")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
