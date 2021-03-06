﻿using DnDGen.RollGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using System;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class ScrollGenerator : MagicalItemGenerator
    {
        private readonly Dice dice;
        private readonly ISpellGenerator spellGenerator;

        public ScrollGenerator(Dice dice, ISpellGenerator spellGenerator)
        {
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var scroll = template.Clone();
            scroll.IsMagical = true;
            scroll.Quantity = 1;
            scroll.ItemType = ItemTypeConstants.Scroll;
            scroll.Attributes = new[] { AttributeConstants.OneTimeUse };
            scroll.BaseNames = new[] { ItemTypeConstants.Scroll };

            return scroll.SmartClone();
        }

        public Item GenerateRandom(string power)
        {
            var spellType = spellGenerator.GenerateType();
            var scroll = new Item();
            scroll.Name = ItemTypeConstants.Scroll;
            scroll.BaseNames = new[] { ItemTypeConstants.Scroll };
            scroll.ItemType = ItemTypeConstants.Scroll;
            scroll.IsMagical = true;
            scroll.Attributes = new[] { AttributeConstants.OneTimeUse };
            scroll.Traits.Add(spellType);

            var quantity = GetQuantity(power);
            while (quantity-- > 0)
            {
                var level = spellGenerator.GenerateLevel(power);
                var spell = spellGenerator.Generate(spellType, level);
                var spellWithLevel = $"{spell} ({level})";
                scroll.Contents.Add(spellWithLevel);
            }

            return scroll;
        }

        public Item Generate(string power, string itemName, params string[] traits)
        {
            var scroll = GenerateRandom(power);
            scroll.Name = itemName;

            foreach (var trait in traits)
                scroll.Traits.Add(trait);

            return scroll;
        }

        private int GetQuantity(string power)
        {
            switch (power)
            {
                case PowerConstants.Minor: return dice.Roll().d3().AsSum();
                case PowerConstants.Medium: return dice.Roll().d4().AsSum();
                case PowerConstants.Major: return dice.Roll().d6().AsSum();
                default: throw new ArgumentException();
            }
        }
    }
}