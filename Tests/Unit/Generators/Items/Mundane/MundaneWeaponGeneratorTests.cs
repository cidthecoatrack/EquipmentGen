﻿using Moq;
using NUnit.Framework;
using RollGen;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Mundane;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests
    {
        private IMundaneItemGenerator mundaneWeaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAmmunitionGenerator> mockAmmunitionGenerator;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private String expectedTableName;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockDice = new Mock<IDice>();
            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileSelector.Object, mockAmmunitionGenerator.Object, mockAttributesSelector.Object, mockBooleanPercentileSelector.Object, mockDice.Object);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons)).Returns("weapon type");
            expectedTableName = String.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns("weapon name");
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void GenerateMasterworkWeapon()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork))
                .Returns(true);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateNonMasterworkWeapon()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork))
                .Returns(false);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Is.Not.Contains(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAmmunition()
        {
            var ammo = new Item();
            mockPercentileSelector.Setup(p => p.SelectFrom(expectedTableName)).Returns(AttributeConstants.Ammunition);
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            var expectedAttributesName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockAttributesSelector.Setup(p => p.SelectFrom(expectedAttributesName, "weapon name")).Returns(attributes);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void ThrownWeaponReceivesQuantity()
        {
            mockAttributesSelector.Setup(
                s => s.SelectFrom(TableNameConstants.Attributes.Set.AmmunitionAttributes, AttributeConstants.Thrown))
                .Returns(new[] { "other weapon", "weapon name" });
            mockDice.Setup(d => d.Roll(1).d20()).Returns(9266);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Quantity, Is.EqualTo(9266));
        }
    }
}