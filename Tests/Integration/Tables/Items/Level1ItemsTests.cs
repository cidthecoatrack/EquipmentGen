﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level1ItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level1Items"; }
        }

        [TestCase(EmptyContent, 1, 71)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Mundane, "1", 72, 95)]
        [TestCase(PowerConstants.Minor, "1", 96, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}