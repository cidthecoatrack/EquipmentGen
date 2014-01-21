﻿using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items
{
    [TestFixture]
    public class Level7ItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level7Items";
        }

        [Test]
        public void Level7ItemsEmptyPercentile()
        {
            AssertEmpty(1, 51);
        }

        [Test]
        public void Level7ItemsMinorPercentile()
        {
            var content = String.Format("{0},1d3", ItemsConstants.Power.Minor);
            AssertContent(content, 52, 97);
        }

        [Test]
        public void Level7ItemsMediumPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Power.Medium);
            AssertContent(content, 98, 100);
        }
    }
}