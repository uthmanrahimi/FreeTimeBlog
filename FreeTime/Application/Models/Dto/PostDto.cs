﻿using System;

namespace FreeTime.Web.Application.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; }
    }
}
