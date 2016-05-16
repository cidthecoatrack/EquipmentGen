﻿using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests
    {
        private MagicalItemGenerator magicalArmorGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<IMagicalItemTraitsGenerator> mockMagicItemTraitsGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private TypeAndAmountPercentileResult result;
        private string power;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            magicalArmorGenerator = new MagicalArmorGenerator(mockTypeAndAmountPercentileSelector.Object, mockPercentileSelector.Object, mockAttributesSelector.Object, mockSpecialAbilitiesGenerator.Object, mockSpecificGearGenerator.Object);

            result = new TypeAndAmountPercentileResult();
            result.Type = "armor type";
            result.Amount = 9266;
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(result);
        }

        [Test]
        public void GetArmor()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GetBonusFromSelector()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetNameFromPercentileSelector()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            var attributes = new[] { "type 1", "type 2" };
            tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, "armor name")).Returns(attributes);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSpecificArmorsFromGenerator()
        {
            result.Amount = 0;

            var specificArmor = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, result.Type)).Returns(specificArmor);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor, Is.EqualTo(specificArmor));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns(abilityResult).Returns(abilityResult).Returns(result);

            var attributes = new[] { "type 1", "type 2" };
            tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, It.IsAny<String>())).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9266, 2)).Returns(abilities);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }
    }
}