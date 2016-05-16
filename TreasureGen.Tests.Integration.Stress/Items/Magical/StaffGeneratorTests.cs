﻿using Ninject;
using NUnit.Framework;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class StaffGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Staff)]
        public MagicalItemGenerator StaffGenerator { get; set; }

        [TestCase("Staff generator")]
        public override void Stress(string thingToStress)
        {
            Stress();
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Staff; }
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower(allowMinor: false);
            return StaffGenerator.GenerateAtPower(power);
        }

        protected override void MakeAssertionsAgainst(Item staff)
        {
            Assert.That(staff.Name, Does.StartWith("Staff of "));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Contents, Is.Empty);
            Assert.That(staff.IsMagical, Is.True);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Magic.Bonus, Is.Not.Negative);
            Assert.That(staff.Magic.Charges, Is.InRange(1, 50));
            Assert.That(staff.Magic.Curse, Is.Not.Null);
            Assert.That(staff.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Traits, Is.Not.Null);
        }

        [Test]
        public override void TraitsHappen()
        {
            base.TraitsHappen();
        }

        [Test]
        public override void CursesHappen()
        {
            AssertCursesHappen();
        }

        [Test]
        public override void SpecificCursesHappen()
        {
            AssertSpecificCursesHappen();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        [Test]
        public override void SpecificCursedItemsAreNotDecorated()
        {
            AssertSpecificCursedItemsAreNotDecorated();
        }

        [Test]
        public override void SpecificCursedItemsHaveTraits()
        {
            AssertSpecificCursedItemsHaveTraits();
        }

        [Test]
        public override void SpecificCursedItemsDoNotHaveSpecialMaterials()
        {
            AssertSpecificCursedItemsDoNotHaveSpecialMaterials();
        }
    }
}