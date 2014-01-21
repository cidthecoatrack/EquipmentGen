﻿using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level17ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level17Items";
        }

        [Test]
        public void Level17ItemsEmptyPercentile()
        {
            AssertEmpty(1, 33);
        }

        [Test]
        public void Level17ItemsMediumPercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Power.Medium);
            AssertContent(content, 34, 83);
        }

        [Test]
        public void Level17ItemsMajorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Major);
            AssertContent(content, 84, 100);
        }
    }
}