﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.GameModels.Tables
{
    public class Story
    {
        [Key]
        public int StoryId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsBattle { get; set; }
        public int NextText { get; set; }
    }
}