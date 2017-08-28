﻿using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items
{
    internal interface ISpecificGearGenerator
    {
        Item GenerateRandomPrototypeFrom(string power, string specificGearType);
        Item GenerateFrom(Item template);
        bool IsSpecific(Item template);
    }
}