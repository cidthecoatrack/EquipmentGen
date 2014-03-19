﻿using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneItemGeneratorTests
    {
        private IMundaneItemGenerator mundaneItemGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IAlchemicalItemGenerator> mockAlchemicalItemGenerator;
        private Mock<IMundaneGearGeneratorFactory> mockGearGeneratorFactory;
        private Mock<IToolGenerator> mockToolGenerator;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems", 9266)).Returns(ItemTypeConstants.AlchemicalItem);

            mockAlchemicalItemGenerator = new Mock<IAlchemicalItemGenerator>();
            mockGearGeneratorFactory = new Mock<IMundaneGearGeneratorFactory>();
            mockToolGenerator = new Mock<IToolGenerator>();

            mundaneItemGenerator = new MundaneItemGenerator(mockPercentileResultProvider.Object, mockAlchemicalItemGenerator.Object,
                mockGearGeneratorFactory.Object, mockToolGenerator.Object, mockDice.Object);
        }

        [Test]
        public void MundaneItemGeneratorProducesAlchemicalItems()
        {
            var item = new Item();
            mockAlchemicalItemGenerator.Setup(f => f.Generate()).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems", 9266)).Returns(ItemTypeConstants.AlchemicalItem);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemGeneratorProducesArmor()
        {
            var item = new Item();
            var mockArmorGenerator = new Mock<IMundaneGearGenerator>();
            mockArmorGenerator.Setup(f => f.Generate()).Returns(item);
            mockGearGeneratorFactory.Setup(f => f.CreateWith(ItemTypeConstants.Armor)).Returns(mockArmorGenerator.Object);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems", 9266)).Returns(ItemTypeConstants.Armor);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemGeneratorProducesWeapons()
        {
            var item = new Item();
            var mockWeaponGenerator = new Mock<IMundaneGearGenerator>();
            mockWeaponGenerator.Setup(f => f.Generate()).Returns(item);
            mockGearGeneratorFactory.Setup(f => f.CreateWith(ItemTypeConstants.Weapon)).Returns(mockWeaponGenerator.Object);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems", 9266)).Returns(ItemTypeConstants.Weapon);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemGeneratorProducesTools()
        {
            var item = new Item();
            mockToolGenerator.Setup(f => f.Generate()).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems", 9266)).Returns(ItemTypeConstants.Tool);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }
    }
}