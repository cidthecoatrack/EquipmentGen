﻿using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level1Goods")]
    public class Level1GoodsTests : PercentileTests
    {
        [Test]
        public void Level1EmptyPercentile()
        {
            AssertEmpty(1, 90);
        }

        [Test]
        public void Level1GemPercentile()
        {
            var content = String.Format("{0},1", GoodsConstants.Gem);
            AssertContent(content, 91, 95);
        }

        [Test]
        public void Level1ArtPercentile()
        {
            var content = String.Format("{0},1", GoodsConstants.Art);
            AssertContent(content, 96, 100);
        }
    }
}