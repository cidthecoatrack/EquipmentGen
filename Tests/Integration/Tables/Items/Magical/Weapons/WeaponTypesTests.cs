﻿using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class WeaponTypesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "WeaponTypes"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("CommonMelee", 1, 70)]
        [TestCase("Uncommon", 71, 80)]
        [TestCase("CommonRanged", 81, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}