﻿using EquipmentGen.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public class TreasureGeneratorTests : StressTests
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedTreasureGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var treasure = TreasureGenerator.GenerateAtLevel(level);

                Assert.That(treasure.Coin, Is.Not.Null, "coin");
                Assert.That(treasure.Goods, Is.Not.Null, "goods");
                Assert.That(treasure.Items, Is.Not.Null, "items");
            }

            AssertIterations();
        }
    }
}