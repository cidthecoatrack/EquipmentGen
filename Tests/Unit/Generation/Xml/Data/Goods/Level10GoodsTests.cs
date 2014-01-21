﻿using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level10GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level10Goods";
        }

        [Test]
        public void Level10EmptyPercentile()
        {
            AssertEmpty(1, 35);
        }

        [Test]
        public void Level10GemPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Gem);
            AssertContent(content, 36, 79);
        }

        [Test]
        public void Level10ArtPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Art);
            AssertContent(content, 80, 100);
        }
    }
}