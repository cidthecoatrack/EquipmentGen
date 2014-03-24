﻿using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Minor
{
    [TestFixture, PercentileTable("MinorShieldSpecialAbilities")]
    public class MinorShieldSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void ArrowCatchingPercentile()
        {
            AssertContent(SpecialAbilityConstants.ArrowCatching, 1, 20);
        }

        [Test]
        public void BashingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Bashing, 21, 40);
        }

        [Test]
        public void BlindingPercentile()
        {
            AssertContent(SpecialAbilityConstants.Blinding, 41, 50);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent(SpecialAbilityConstants.LightFortification, 51, 75);
        }

        [Test]
        public void ArrowDeflectionPercentile()
        {
            AssertContent(SpecialAbilityConstants.ArrowDeflection, 76, 92);
        }

        [Test]
        public void AnimatedPercentile()
        {
            AssertContent(SpecialAbilityConstants.Animated, 93, 97);
        }

        [Test]
        public void SpellResistance13Percentile()
        {
            AssertContent(SpecialAbilityConstants.SpellResistance13, 98, 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility", 100);
        }
    }
}