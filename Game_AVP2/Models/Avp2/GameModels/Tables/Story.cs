using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //First text in episode
        [Required]
        public bool IsFirst { get; set; }
        //last story - then nextepisode
        [Required]
        public bool IsLast { get; set; }
        //not implemented yet
        public bool IsDialogue { get; set; }

        public int? NextText { get; set; }

        [Required]
        public byte EpisodeId { get; set; }

        [ForeignKey("EpisodeId")]
        public virtual Episode Episode { get; set; }

    }
}