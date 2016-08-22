﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class Attribute
    {
        [Key, ForeignKey("StaticCharacter")]
        public int StaticCharacterId { get; set; }
        //[ForeignKey("StaticCharacter")]
        //[Column(Order = 1)]
        //[Required]
        //public int StaticCharacterId { get; set; }

        //[ForeignKey("Character")]
        //[Column(Order = 2)]

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int DefenceModifier { get; set; }
        public int StrengthModifier { get; set; }

        public virtual StaticCharacter StaticCharacter { get; set; }
    }
}