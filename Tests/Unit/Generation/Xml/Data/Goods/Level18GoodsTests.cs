﻿using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level18GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level18Goods";
        }

        [Test]
        public void Level18EmptyPercentile()
        {
            AssertEmpty(1, 4);
        }

        [Test]
        public void Level18GemPercentile()
        {
            var content = String.Format("{0},3d12", GoodsConstants.Gem);
            AssertContent(content, 5, 54);
        }

        [Test]
        public void Level18ArtPercentile()
        {
            var content = String.Format("{0},3d10", GoodsConstants.Art);
            AssertContent(content, 55, 100);
        }
    }
}