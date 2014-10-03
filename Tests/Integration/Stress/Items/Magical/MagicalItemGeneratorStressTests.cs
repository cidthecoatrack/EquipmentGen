﻿using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public abstract class MagicalItemGeneratorStressTests : StressTests
    {
        [Inject]
        public InterestCalculator InterestCalculator { get; set; }
        [Inject]
        public InterestFormatter InterestFormatter { get; set; }

        protected abstract String itemType { get; }
        protected IEnumerable<String> materials;

        private Item mostInterestingItem;
        private Int32 mostInterestingScore;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
            mostInterestingScore = 0;
        }

        [TearDown]
        public void TearDown()
        {
            if (mostInterestingItem != null)
            {
                var output = InterestFormatter.MakeOutput(mostInterestingItem);
                Assert.Pass(output);
            }
        }

        protected override void MakeAssertions()
        {
            var item = GenerateItem();

            //INFO: This is in case the generator produces a specific cursed item
            if (item.ItemType != itemType)
                return;

            MakeAssertionsAgainst(item);

            var score = InterestCalculator.CalculateInterest(item);
            if (score > mostInterestingScore)
            {
                mostInterestingScore = score;
                mostInterestingItem = item;
            }
        }

        protected abstract Item GenerateItem();
        protected abstract void MakeAssertionsAgainst(Item item);

        public virtual void IntelligenceHappens()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && item.Magic.Intelligence.Ego == 0)
                item = GenerateItem();

            Assert.That(item.Magic.Intelligence.Ego, Is.GreaterThan(0), type);
            AssertIterations();
        }

        public abstract void CursesHappen();

        protected void AssertCursesHappen()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && (String.IsNullOrEmpty(item.Magic.Curse) || item.Magic.Curse == "This is a specific cursed item"))
                item = GenerateItem();

            Assert.That(item.Magic.Curse, Is.Not.Empty, type);
            AssertIterations();
        }

        public abstract void SpecificCursesHappen();

        protected void AssertSpecificCursesHappen()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && item.Magic.Curse != "This is a specific cursed item")
                item = GenerateItem();

            Assert.That(item.Magic.Curse, Is.EqualTo("This is a specific cursed item"), type);
            AssertIterations();
        }

        public abstract void SpecificCursedItemsAreIntelligent();

        protected void AssertSpecificCursedItemsAreIntelligent()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && (item.Magic.Curse != "This is a specific cursed item" || item.Magic.Intelligence.Ego == 0))
                item = GenerateItem();

            Assert.That(item.Magic.Curse, Is.EqualTo("This is a specific cursed item"), type);
            Assert.That(item.Magic.Intelligence.Ego, Is.Positive);
            AssertIterations();
        }

        public abstract void SpecificCursedItemsHaveTraits();

        protected void AssertSpecificCursedItemsHaveTraits()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && (item.Magic.Curse != "This is a specific cursed item") || !item.Traits.Except(materials).Any())
                item = GenerateItem();

            var traits = item.Traits.Except(materials);
            Assert.That(item.Magic.Curse, Is.EqualTo("This is a specific cursed item"), type);
            Assert.That(traits, Is.Not.Empty, type);
            AssertIterations();
        }

        public abstract void SpecificCursedItemsHaveSpecialMaterials();

        protected void AssertSpecificCursedItemsHaveSpecialMaterials()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && (item.Magic.Curse != "This is a specific cursed item" || !item.Traits.Intersect(materials).Any()))
                item = GenerateItem();

            var itemMaterials = item.Traits.Intersect(materials);
            Assert.That(item.Magic.Curse, Is.EqualTo("This is a specific cursed item"), type);
            Assert.That(itemMaterials, Is.Not.Empty, type);
            AssertIterations();
        }

        public abstract void SpecificCursedItemsAreNotDecorated();

        protected void AssertSpecificCursedItemsAreNotDecorated()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && (item.Magic.Curse != "This is a specific cursed item" || item.Traits.Any() || item.Magic.Curse.Any() || item.Magic.Intelligence.Ego > 0))
                item = GenerateItem();

            Assert.That(item.Magic.Curse, Is.EqualTo("This is a specific cursed item"), type);
            Assert.That(item.Traits, Is.Empty, type);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0), type);
            AssertIterations();
        }

        public virtual void TraitsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && !item.Traits.Except(materials).Any());

            var traits = item.Traits.Except(materials);
            Assert.That(traits, Is.Not.Empty, type);
            AssertIterations();
        }

        public virtual void SpecialMaterialsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && !item.Traits.Intersect(materials).Any());

            var itemMaterials = item.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Not.Empty, type);
            AssertIterations();
        }

        public abstract void NoDecorationsHappen();

        protected void AssertNoDecorationsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && (item.Traits.Any() || item.Magic.Curse.Any() || item.Magic.Intelligence.Ego > 0));

            Assert.That(item.Traits, Is.Empty, type);
            Assert.That(item.Magic.Curse, Is.Empty, type);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0), type);
            AssertIterations();
        }
    }
}