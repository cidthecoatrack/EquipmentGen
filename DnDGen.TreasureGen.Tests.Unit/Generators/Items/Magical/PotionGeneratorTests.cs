﻿using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests
    {
        private MagicalItemGenerator potionGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private string power;
        private ItemVerifier itemVerifier;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private Generator generator;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            generator = new IterativeGeneratorWithoutLogging(5);
            potionGenerator = new PotionGenerator(mockTypeAndAmountPercentileSelector.Object, mockCollectionsSelector.Object, generator);
            itemVerifier = new ItemVerifier();

            var result = new TypeAndAmountSelection();
            result.Amount = 9266;
            result.Type = "potion";
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(result);
        }

        [Test]
        public void GeneratePotion()
        {
            var potion = potionGenerator.GenerateFrom(power);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Name, Is.EqualTo("potion"));
            Assert.That(potion.BaseNames.Single(), Is.EqualTo("potion"));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }

        [Test]
        public void GenerateCustomPotion()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var potion = potionGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(potion, template);
            Assert.That(potion.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
            Assert.That(potion.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GenerateRandomCustomPotion()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var potion = potionGenerator.GenerateFrom(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(potion, template);
            Assert.That(potion.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
            Assert.That(potion.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong potion", Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "potion", Amount = 90210 })
                .Returns(new TypeAndAmountSelection { Type = "other potion", Amount = 42 });

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 666, Type = "wrong potion" },
                new TypeAndAmountSelection { Amount = 42, Type = "other potion" },
                new TypeAndAmountSelection { Amount = 90210, Type = "potion" },
            });

            var subset = new[] { "other potion", "potion" };

            var potion = potionGenerator.GenerateFrom(power, subset);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Name, Is.EqualTo("potion"));
            Assert.That(potion.BaseNames.Single(), Is.EqualTo("potion"));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong potion", Amount = 9266 });
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 666, Type = "wrong potion" },
                new TypeAndAmountSelection { Amount = 42, Type = "other potion" },
                new TypeAndAmountSelection { Amount = 90210, Type = "potion" },
            });

            var subset = new[] { "other potion", "potion" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var potion = potionGenerator.GenerateFrom(power, subset);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Name, Is.EqualTo("potion"));
            Assert.That(potion.BaseNames.Single(), Is.EqualTo("potion"));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }

        [Test]
        public void GenerateDefaultFromSubsetWithDifferentPower()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong potion", Amount = 9266 });
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 666, Type = "wrong potion" },
                new TypeAndAmountSelection { Amount = 42, Type = "other potion" },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 666, Type = "wrong potion" },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 42, Type = "other potion" },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 90210, Type = "potion" },
            });

            var subset = new[] { "other potion", "potion" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var potion = potionGenerator.GenerateFrom(power, subset);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Name, Is.EqualTo("potion"));
            Assert.That(potion.BaseNames.Single(), Is.EqualTo("potion"));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }
    }
}