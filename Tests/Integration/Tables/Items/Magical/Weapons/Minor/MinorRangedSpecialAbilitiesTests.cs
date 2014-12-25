﻿using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons.Minor
{
    [TestFixture]
    public class MinorRangedSpecialAbilitiesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERATTRIBUTESpecialAbilities, PowerConstants.Minor, AttributeConstants.Ranged); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(SpecialAbilityConstants.DESIGNATEDFOEbane, 1, 12)]
        [TestCase(SpecialAbilityConstants.Distance, 13, 25)]
        [TestCase(SpecialAbilityConstants.Flaming, 26, 40)]
        [TestCase(SpecialAbilityConstants.Frost, 41, 55)]
        [TestCase(SpecialAbilityConstants.Merciful, 56, 60)]
        [TestCase(SpecialAbilityConstants.Returning, 61, 68)]
        [TestCase(SpecialAbilityConstants.Shock, 69, 83)]
        [TestCase(SpecialAbilityConstants.Seeking, 84, 93)]
        [TestCase(SpecialAbilityConstants.Thundering, 94, 99)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("BonusSpecialAbility", 100)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}