﻿using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class MagicalArmorGeneratorTests
    {
        private IMagicalGearGenerator magicalArmorGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<ISpecialMaterialGenerator> mockMaterialsSelector;
        private Mock<IMagicalItemTraitsGenerator> mockMagicItemTraitsGenerator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private Mock<IDice> mockDice;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "armor type";
            result.AmountToRoll = "9266";

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(42);

            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("powerArmors", 42)).Returns(result);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMaterialsSelector = new Mock<ISpecialMaterialGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();

            magicalArmorGenerator = new MagicalArmorGenerator(mockTypeAndAmountPercentileSelector.Object,
                mockPercentileSelector.Object, mockAttributesSelector.Object, mockSpecialAbilitiesGenerator.Object,
                mockMaterialsSelector.Object, mockMagicItemTraitsGenerator.Object, mockIntelligenceGenerator.Object,
                mockSpecificGearGenerator.Object, mockDice.Object);
        }

        [Test]
        public void ThrowErrorIfMundane()
        {
            Assert.That(() => magicalArmorGenerator.GenerateAtPower(PowerConstants.Mundane), Throws.ArgumentException);
        }

        [Test]
        public void GetBonusFromSelector()
        {
            var armor = magicalArmorGenerator.GenerateAtPower("power");
            var bonus = Convert.ToInt32(armor.Magic[Magic.Bonus]);
            Assert.That(bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetNameFromPercentileResultSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(result.Type + "Types", 42)).Returns("armor name");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(result.Type + "Types", 42)).Returns("armor name");

            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("armor name", "ArmorAttributes")).Returns(attributes);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSpecificItemsFromGenerator()
        {
            var specificResult = new TypeAndAmountPercentileResult();
            specificResult.Type = "SpecificArmor";
            specificResult.AmountToRoll = "0";
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("powerArmors", 42)).Returns(specificResult);

            var specificArmor = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom("power", specificResult.Type)).Returns(specificArmor);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor, Is.EqualTo(specificArmor));
        }

        [Test]
        public void GetAbilitiesFromGenerator()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.AmountToRoll = "1";
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom("powerArmors", 42))
                .Returns(abilityResult).Returns(result);
            mockDice.Setup(d => d.Roll(abilityResult.AmountToRoll)).Returns(90210);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateWith(It.IsAny<IEnumerable<String>>(), "power", It.IsAny<Int32>(), 90210))
                .Returns(abilities);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            var armorAbilities = armor.Magic[Magic.Abilities] as IEnumerable<SpecialAbility>;
            Assert.That(armorAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void DoNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetSpecialMaterialFromMaterialSelector()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Contains.Item("special material"));
        }

        [Test]
        public void GetTraitsFromGenerator()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockMagicItemTraitsGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Armor)).Returns(traits);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            foreach (var trait in traits)
                Assert.That(armor.Traits, Contains.Item(trait));
        }

        [Test]
        public void GetIntelligenceFromGenerator()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.Armor, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Dictionary<Magic, Object>>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Dictionary<Magic, Object>>()))
                .Returns(intelligence);

            var armor = magicalArmorGenerator.GenerateAtPower("power");
            var armorIntelligence = armor.Magic[Magic.Intelligence] as Intelligence;
            Assert.That(armorIntelligence, Is.EqualTo(intelligence));
        }
    }
}