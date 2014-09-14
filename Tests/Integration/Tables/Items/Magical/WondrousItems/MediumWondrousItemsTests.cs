﻿using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class MediumWondrousItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "MediumWondrousItems"; }
        }

        [TestCase("Boots of levitation", 0, 1)]
        [TestCase("Harp of charming", 0, 2)]
        [TestCase("Amulet of natural armor", 2, 3)]
        [TestCase("Flesh golem manual", 0, 4)]
        [TestCase("Hand of glory", 0, 5)]
        [TestCase("Deep red sphere ioun stone", 0, 6)]
        [TestCase("Incandescent blue sphere ioun stone", 0, 7)]
        [TestCase("Pale blue rhomboid ioun stone", 0, 8)]
        [TestCase("Pink and green sphere ioun stone", 0, 9)]
        [TestCase("Pink rhomboid ioun stone", 0, 10)]
        [TestCase("Scarlet and blue sphere ioun stone", 0, 11)]
        [TestCase("Deck of illusions", 0, 12)]
        [TestCase("Necklace of fireballs type VI", 0, 13)]
        [TestCase("Candle of invocation", 0, 14)]
        [TestCase("Bracers of armor", 3, 15)]
        [TestCase("Cloak of resistance", 3, 16)]
        [TestCase("Decanter of endless water", 0, 17)]
        [TestCase("Necklace of adaptation", 0, 18)]
        [TestCase("3rd-level spell pearl of power", 0, 19)]
        [TestCase("Talisman of the sphere", 0, 20)]
        [TestCase("Serpentine owl figurine of wondrous power", 0, 21)]
        [TestCase("Necklace of fireballs type VII", 0, 22)]
        [TestCase("Lesser strand of prayer beads", 0, 23)]
        [TestCase("Bag of holding type IV", 0, 24)]
        [TestCase("Bronze griffon figurine of wondrous power", 0, 25)]
        [TestCase("Ebony fly figurine of wondrous power", 0, 26)]
        [TestCase("Glove of storing", 0, 27)]
        [TestCase("Dark blue rhomboid ioun stone", 0, 28)]
        [TestCase("Courser stone horse", 0, 29)]
        [TestCase("Cape of the mountebank", 0, 30)]
        [TestCase("Phylactery of undead turning", 0, 31)]
        [TestCase("Gauntlet of rust", 0, 32)]
        [TestCase("Boots of speed", 0, 33)]
        [TestCase("Goggles of night", 0, 34)]
        [TestCase("Clay golem manual", 0, 35)]
        [TestCase("Medallion of thoughts", 0, 36)]
        [TestCase("Pipes of pain", 0, 37)]
        [TestCase("Boccob's blessed book", 0, 38)]
        [TestCase("Monk's belt", 0, 39)]
        [TestCase("Gem of brightness", 0, 40)]
        [TestCase("Lyre of building", 0, 41)]
        [TestCase("Cloak of arachnida", 0, 42)]
        [TestCase("Destrier stone horse", 0, 43)]
        [TestCase("Belt of dwarvenkind", 0, 44)]
        [TestCase("Periapt of wound-closure", 0, 45)]
        [TestCase("Horn of the tritons", 0, 46)]
        [TestCase("Pearl of the sirines", 0, 47)]
        [TestCase("Onyx dog figurine of wondrous power", 0, 48)]
        [TestCase("Amulet of health", 4, 49)]
        [TestCase("Belt of giant strength", 4, 50)]
        [TestCase("Winged boots", 0, 51)]
        [TestCase("Bracers of armor", 4, 52)]
        [TestCase("Cloak of charisma", 4, 53)]
        [TestCase("Cloak of resistance", 4, 54)]
        [TestCase("Gloves of dexterity", 4, 55)]
        [TestCase("Headband of intellect", 4, 56)]
        [TestCase("4th-level spell pearl of power", 0, 57)]
        [TestCase("Periapt of wisdom", 4, 58)]
        [TestCase("Scabbard of keen edges", 0, 59)]
        [TestCase("Golden lions figurine of wondrous power", 0, 60)]
        [TestCase("Chime of interruption", 0, 61)]
        [TestCase("Broom of flying", 0, 62)]
        [TestCase("Marble elephant figurine of wondrous power", 0, 63)]
        [TestCase("Amulet of natural armor", 3, 64)]
        [TestCase("Iridescent spindle ioun stone", 0, 65)]
        [TestCase("Bracelet of friends", 0, 66)]
        [TestCase("5 ft. by 5 ft. carpet of flying", 0, 67)]
        [TestCase("Horn of blasting", 0, 68)]
        [TestCase("Pale lavender ellipsoid ioun stone", 0, 69)]
        [TestCase("Pearly white spindle ioun stone", 0, 70)]
        [TestCase("Portable hole", 0, 71)]
        [TestCase("Stone of good luck (luckstone)", 0, 72)]
        [TestCase("Ivory goats figurine of wondrous power", 0, 73)]
        [TestCase("Rope of entanglement", 0, 74)]
        [TestCase("Stone golem manual", 0, 75)]
        [TestCase("Mask of the skull", 0, 76)]
        [TestCase("Mattock of the titans", 0, 77)]
        [TestCase("Major circlet of blasting", 0, 78)]
        [TestCase("Amulet of mighty fists", 2, 79)]
        [TestCase("Minor cloak of displacement", 0, 80)]
        [TestCase("Helm of underwater action", 0, 81)]
        [TestCase("Greater bracers of archery", 0, 82)]
        [TestCase("Bracers of armor", 5, 83)]
        [TestCase("Cloak of resistance", 5, 84)]
        [TestCase("Eyes of doom", 0, 85)]
        [TestCase("5th-level spell pearl of power", 0, 86)]
        [TestCase("Maul of the titans", 0, 87)]
        [TestCase("Strand of prayer beads", 0, 88)]
        [TestCase("Cloak of the bat", 0, 89)]
        [TestCase("Iron bands of Bilarro", 0, 90)]
        [TestCase("Cube of frost resistance", 0, 91)]
        [TestCase("Helm of telepathy", 0, 92)]
        [TestCase("Periapt of proof against poison", 0, 93)]
        [TestCase("Robe of scintillating colors", 0, 94)]
        [TestCase("Manual of bodily health", 1, 95)]
        [TestCase("Manual of gainful exercise", 1, 96)]
        [TestCase("Manual of quickness in action", 1, 97)]
        [TestCase("Tome of clear thought", 1, 98)]
        [TestCase("Tome of leadership and influence", 1, 99)]
        [TestCase("Tome of understanding", 1, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, amount, roll);
        }
    }
}