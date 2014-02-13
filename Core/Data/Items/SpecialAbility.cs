﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Data.Items
{
    public class SpecialAbility
    {
        public String Name { get; set; }
        public String CoreName { get; set; }
        public Int32 Strength { get; set; }
        public IEnumerable<String> TypeRequirements { get; set; }
        public Int32 BonusEquivalent { get; set; }

        public SpecialAbility()
        {
            TypeRequirements = Enumerable.Empty<String>();
        }
    }
}