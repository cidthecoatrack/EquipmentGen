﻿using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("Ammunitions")]
    public class AmmunitionsTests : PercentileTests
    {
        [Test]
        public void ArrowPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.Arrow);
            AssertContent(content, 1, 50);
        }

        [Test]
        public void CrossbowBoltPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.CrossbowBolt);
            AssertContent(content, 51, 80);
        }

        [Test]
        public void SlingBulletPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.SlingBullet);
            AssertContent(content, 81, 100);
        }
    }
}