﻿using System;
using System.Collections.Generic;

namespace EquipmentGen.Common.Items
{
    public class Intelligence
    {
        public Int32 IntelligenceStat { get; set; }
        public Int32 WisdomStat { get; set; }
        public Int32 CharismaStat { get; set; }
        public List<String> Powers { get; set; }
        public String SpecialPurpose { get; set; }
        public String DedicatedPower { get; set; }
        public Int32 Ego { get; set; }
        public String Communication { get; set; }
        public String Senses { get; set; }
        public String Alignment { get; set; }

        public Intelligence()
        {
            Powers = new List<String>();
            SpecialPurpose = String.Empty;
            DedicatedPower = String.Empty;
            Communication = String.Empty;
            Senses = String.Empty;
            Alignment = String.Empty;
        }
    }
}