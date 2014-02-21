﻿using D20Dice;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class AmmunitionGeneratorTests
    {
        private IAmmunitionGenerator ammunitionGenerator;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IDice> mockDice;
        private Mock<IAttributesProvider> mockTypesProvider;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "ammunition name";
            result.Amount = 9266;

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom("Ammunition")).Returns(result);

            mockDice = new Mock<IDice>();
            mockTypesProvider = new Mock<IAttributesProvider>();

            ammunitionGenerator = new AmmunitionGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object,
                mockTypesProvider.Object);
        }

        [Test]
        public void AmmunitionGeneratorGetsNameAndQuantityFromTypeAndAmountPercentileResultProvider()
        {
            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Name, Is.EqualTo(result.Type));
            Assert.That(ammunition.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void AmmunitionGeneratorGetsTypesFromProvider()
        {
            var types = new[] { "type 1", "type 2" };
            mockTypesProvider.Setup(p => p.GetAttributesFor(result.Type, "AmmunitionTypes")).Returns(types);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Attributes, Is.EqualTo(types));
        }
    }
}