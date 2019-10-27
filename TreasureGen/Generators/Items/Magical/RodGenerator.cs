﻿using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Selectors.Selections;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Generators.Items.Magical
{
    internal class RodGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly Generator generator;
        private readonly JustInTimeFactory justInTimeFactory;

        public RodGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionSelector collectionsSelector,
            IChargesGenerator chargesGenerator,
            ITreasurePercentileSelector percentileSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            Generator generator,
            JustInTimeFactory justInTimeFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.percentileSelector = percentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.generator = generator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateFrom(string power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = result.Type;
            rod.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, rod.Name);
            rod.IsMagical = true;
            rod.Magic.Bonus = result.Amount;
            tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            rod.Attributes = collectionsSelector.SelectFrom(tablename, rod.Name);

            if (rod.Attributes.Contains(AttributeConstants.Charged))
                rod.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Rod, rod.Name);

            if (rod.Name == RodConstants.Absorption)
            {
                var containsSpellLevels = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels);
                if (containsSpellLevels)
                {
                    var maxCharges = chargesGenerator.GenerateFor(ItemTypeConstants.Rod, RodConstants.FullAbsorption);
                    var containedSpellLevels = (maxCharges - rod.Magic.Charges) / 2;
                    rod.Contents.Add($"{containedSpellLevels} spell levels");
                }
            }

            rod = GetWeapon(rod);

            return rod;
        }

        private Item GetWeapon(Item rod)
        {
            var weapons = WeaponConstants.GetBaseNames();
            if (!weapons.Intersect(rod.BaseNames).Any())
                return rod;

            var template = new Weapon();
            template.Name = weapons.Intersect(rod.BaseNames).First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var mundaneWeapon = mundaneWeaponGenerator.GenerateFrom(template);

            rod.Attributes = rod.Attributes.Union(mundaneWeapon.Attributes);
            rod.CloneInto(mundaneWeapon);

            if (mundaneWeapon.IsMagical)
                mundaneWeapon.Traits.Add(TraitConstants.Masterwork);

            return mundaneWeapon;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var rod = template.Clone();
            rod.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, rod.Name);
            rod.IsMagical = true;
            rod.Quantity = 1;
            rod.ItemType = ItemTypeConstants.Rod;

            var results = GetAllResults();
            var result = results.First(r => rod.NameMatches(r.Type));
            rod.Magic.Bonus = result.Amount;

            var tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            rod.Attributes = collectionsSelector.SelectFrom(tablename, rod.Name);

            rod.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(rod.Magic.SpecialAbilities);

            rod = GetWeapon(rod);

            return rod.SmartClone();
        }

        private IEnumerable<TypeAndAmountSelection> GetAllResults()
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            var mediumResults = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Rod);
            var majorResults = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            return mediumResults.Union(majorResults);
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var rod = generator.Generate(
                () => GenerateFrom(power),
                r => subset.Any(n => r.NameMatches(n)),
                () => CreateDefaultRod(subset),
                r => $"{r.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Rod from [{string.Join(", ", subset)}]");

            foreach (var trait in traits)
                rod.Traits.Add(trait);

            return rod;
        }

        private Item CreateDefaultRod(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var defaultRod = GenerateFrom(template);
            return defaultRod;
        }
    }
}