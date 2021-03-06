﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoLife.Models
{
    public class News
    {
        private ICollection<Comment> comments;

        public News()
        {
            this.comments = new HashSet<Comment>();
        }

        public News(
            string title, 
            string text, 
            string imageUrl,
            User author,
            Category category,
            DateTime datePublished)
        {
            this.Title = title;
            this.Text = text;
            this.ImageUrl = imageUrl;
            this.Author = author;
            this.Category = category;
            this.Views = 0;
            this.DatePublished = datePublished;
        }

        [Key]
        public int NewsId { get; set; }

        public DateTime DatePublished { get; set; }

        public int Views { get; set; }

        [ForeignKey("Author")]
        public string UserId { get; set; }
    
        public virtual User Author { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }
        
        public string ImageUrl { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
