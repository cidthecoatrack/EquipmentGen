﻿using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class SpecialAbilityCollectionsSelectorTests
    {
        private ISpecialAbilityAttributesSelector selector;
        private Mock<ICollectionsSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionsSelector>();
            selector = new SpecialAbilityAttributesSelector(mockInnerSelector.Object);
        }

        [Test]
        public void ReturnSpecialAbilityAttributesResult()
        {
            var attributes = new[] { "42", "base name", "9266" };
            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributes, "name")).Returns(attributes);

            var result = selector.SelectFrom("name");
            Assert.That(result.BaseName, Is.EqualTo("base name"));
            Assert.That(result.BonusEquivalent, Is.EqualTo(42));
            Assert.That(result.Power, Is.EqualTo(9266));
        }

        [Test]
        public void ThrowErrorIfFewerThan3Attributes()
        {
            var attributes = new[] { "base name", "42" };
            mockInnerSelector.Setup(s => s.SelectFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(attributes);
            Assert.That(() => selector.SelectFrom("name"), Throws.Exception.With.Message.EqualTo("Attributes are not formatted for special abilities"));
        }

        [Test]
        public void IsSpecialAbility()
        {
            mockInnerSelector.Setup(s => s.Exists(TableNameConstants.Collections.Set.SpecialAbilityAttributes, "name")).Returns(true);
            var isSpecialAbility = selector.IsSpecialAbility("name");
            Assert.That(isSpecialAbility, Is.True);
        }

        [Test]
        public void IsNotSpecialAbility()
        {
            mockInnerSelector.Setup(s => s.Exists(TableNameConstants.Collections.Set.SpecialAbilityAttributes, "name")).Returns(false);
            var isSpecialAbility = selector.IsSpecialAbility("name");
            Assert.That(isSpecialAbility, Is.False);
        }
    }
}