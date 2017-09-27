﻿using DnDGen.Core.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class SpecialMaterialGenerator : ISpecialMaterialGenerator
    {
        private readonly ICollectionSelector collectionsSelector;
        private readonly ITreasurePercentileSelector percentileSelector;

        public SpecialMaterialGenerator(ICollectionSelector collectionsSelector, ITreasurePercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
        }

        public bool CanHaveSpecialMaterial(string itemType, IEnumerable<string> attributes, IEnumerable<string> traits)
        {
            if (itemType != ItemTypeConstants.Weapon && itemType != ItemTypeConstants.Armor)
                return false;

            var attributesWithType = attributes.Union(new[] { itemType });
            return percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.HasSpecialMaterial)
                   && AttributesAllowForSpecialMaterials(attributesWithType)
                   && TraitsAllowForSpecialMaterials(attributesWithType, traits);
        }

        private bool AttributesAllowForSpecialMaterials(IEnumerable<string> attributes)
        {
            var allowedMaterials = GetAllowedMaterials(attributes);
            return allowedMaterials.Any();
        }

        private bool TraitsAllowForSpecialMaterials(IEnumerable<string> attributes, IEnumerable<string> traits)
        {
            var allMaterials = TraitConstants.SpecialMaterials.All();
            var materials = traits.Intersect(allMaterials);

            var numberOfMaterialsAlreadyHad = materials.Count();
            if (numberOfMaterialsAlreadyHad > 1)
                return false;

            var numberOfAllowedMaterials = GetAllowedMaterials(attributes).Count();
            if (numberOfAllowedMaterials <= numberOfMaterialsAlreadyHad)
                return false;

            if (numberOfMaterialsAlreadyHad > 0)
                return attributes.Contains(AttributeConstants.DoubleWeapon);

            return true;
        }

        private Dictionary<string, IEnumerable<string>> GetSpecialMaterialAttributes()
        {
            var specialMaterialAttributeRequirements = new Dictionary<string, IEnumerable<string>>();
            var allMaterials = TraitConstants.SpecialMaterials.All();

            foreach (var material in allMaterials)
            {
                var attributeRequirements = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecialMaterials, material);
                specialMaterialAttributeRequirements.Add(material, attributeRequirements);
            }

            return specialMaterialAttributeRequirements;
        }

        private IEnumerable<string> GetAllowedMaterials(IEnumerable<string> attributes)
        {
            var specialMaterialAttributeRequirements = GetSpecialMaterialAttributes();
            var allowedMaterialEntries = specialMaterialAttributeRequirements.Where(kvp => AllAttributeRequirementsMet(attributes, kvp.Value));

            return allowedMaterialEntries.Select(kvp => kvp.Key);
        }

        private bool AllAttributeRequirementsMet(IEnumerable<string> attributes, IEnumerable<string> requirements)
        {
            var missingRequirements = requirements.Except(attributes);
            return !missingRequirements.Any();
        }

        public string GenerateFor(string itemType, IEnumerable<string> attributes, IEnumerable<string> traits)
        {
            if (itemType != ItemTypeConstants.Weapon && itemType != ItemTypeConstants.Armor)
                throw new ArgumentException(itemType);

            var attributesWithType = attributes.Union(new[] { itemType });
            if (!AttributesAllowForSpecialMaterials(attributesWithType))
                throw new ArgumentException(string.Join(",", attributesWithType));

            if (!TraitsAllowForSpecialMaterials(attributesWithType, traits))
                throw new ArgumentException(string.Join(",", traits));

            var filteredSpecialMaterials = GetAllowedMaterials(attributesWithType);
            var allowedSpecialMaterials = filteredSpecialMaterials.Except(traits);

            var specialMaterial = collectionsSelector.SelectRandomFrom(allowedSpecialMaterials);
            return specialMaterial;
        }
    }
}