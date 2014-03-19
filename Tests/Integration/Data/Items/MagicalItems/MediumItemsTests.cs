﻿using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems
{
    [TestFixture, PercentileTable("MediumItems")]
    public class MediumItemsTests : PercentileTests
    {
        [Test]
        public void MediumArmorPercentile()
        {
            AssertContent(ItemTypeConstants.Armor, 1, 10);
        }

        [Test]
        public void MediumWeaponPercentile()
        {
            AssertContent(ItemTypeConstants.Weapon, 11, 20);
        }

        [Test]
        public void MediumPotionPercentile()
        {
            AssertContent(ItemTypeConstants.Potion, 21, 30);
        }

        [Test]
        public void MediumRingPercentile()
        {
            AssertContent(ItemTypeConstants.Ring, 31, 40);
        }

        [Test]
        public void MediumRodPercentile()
        {
            AssertContent(ItemTypeConstants.Rod, 41, 50);
        }

        [Test]
        public void MediumScrollPercentile()
        {
            AssertContent(ItemTypeConstants.Scroll, 51, 65);
        }

        [Test]
        public void MediumStaffPercentile()
        {
            AssertContent(ItemTypeConstants.Staff, 66, 68);
        }

        [Test]
        public void MediumWandPercentile()
        {
            AssertContent(ItemTypeConstants.Wand, 69, 83);
        }

        [Test]
        public void MediumWondrousItemPercentile()
        {
            AssertContent(ItemTypeConstants.WondrousItem, 84, 100);
        }
    }
}
