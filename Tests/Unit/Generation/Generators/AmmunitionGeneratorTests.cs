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
        private Mock<IGearTypesProvider> mockGearTypesProvider;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "ammunition name";
            result.RollToDetermineAmount = "roll";

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("Ammunition")).Returns(result);

            mockDice = new Mock<IDice>();
            mockGearTypesProvider = new Mock<IGearTypesProvider>();

            ammunitionGenerator = new AmmunitionGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object,
                mockGearTypesProvider.Object);
        }

        [Test]
        public void AmmunitionGeneratorGetsNameFromTypeAndAmountPercentileResultProvider()
        {
            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Name, Is.EqualTo(result.Type));
        }

        [Test]
        public void AmmunitionGeneratorRollsAmount()
        {
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(9266);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Quantity, Is.EqualTo(9266));
        }

        [Test]
        public void AmmunitionGeneratorGetsTypesFromProvider()
        {
            var types = new[] { "type 1", "type 2" };
            mockGearTypesProvider.Setup(p => p.GetGearTypesFor(result.Type)).Returns(types);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Types, Is.EqualTo(types));
        }
    }
}