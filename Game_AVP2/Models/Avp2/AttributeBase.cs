﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2
{
    public class AttributeBase
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int DefenceModifier { get; set; }
        public int StrengthModifier { get; set; }
    }
}