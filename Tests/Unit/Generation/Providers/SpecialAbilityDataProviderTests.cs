﻿using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class SpecialAbilityDataProviderTests
    {
        private ISpecialAbilityDataProvider provider;
        private Mock<ITypesProvider> mockTypesProvider;
        private Mock<ISpecialAbilityDataXmlParser> mockParser;

        private Dictionary<String, SpecialAbilityDataObject> data;
        private SpecialAbilityDataObject specialAbilityData;

        [SetUp]
        public void Setup()
        {
            mockTypesProvider = new Mock<ITypesProvider>();

            data = new Dictionary<String, SpecialAbilityDataObject>();
            specialAbilityData = new SpecialAbilityDataObject();
            specialAbilityData.CoreName = "core name";
            specialAbilityData.BonusEquivalent = 92;
            specialAbilityData.Strength = 66;
            data.Add("ability name", specialAbilityData);

            mockParser = new Mock<ISpecialAbilityDataXmlParser>();
            mockParser.Setup(p => p.Parse("SpecialAbilityData.xml")).Returns(data);

            provider = new SpecialAbilityDataProvider(mockParser.Object, mockTypesProvider.Object);
        }

        [Test]
        public void SpecialAbilityDataProviderGetsDataFromXmlParser()
        {
            var result = provider.GetDataFor("ability name");
            Assert.That(result.Name, Is.EqualTo("ability name"));
            Assert.That(result.CoreName, Is.EqualTo(specialAbilityData.CoreName));
            Assert.That(result.BonusEquivalent, Is.EqualTo(specialAbilityData.BonusEquivalent));
            Assert.That(result.Strength, Is.EqualTo(specialAbilityData.Strength));
        }

        [Test]
        public void SpecialAbilityDataProviderGetsTypeRequirements()
        {
            var types = new[] { "type 1" };
            mockTypesProvider.Setup(p => p.GetTypesFor("core name", "SpecialAbilityTypes")).Returns(types);

            var result = provider.GetDataFor("ability name");
            Assert.That(result.TypeRequirements, Is.EqualTo(types));
        }

        [Test]
        public void SpecialAbilityDataProviderCachesTable()
        {
            provider.GetDataFor("ability name");
            provider.GetDataFor("ability name");
            mockParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }
    }
}