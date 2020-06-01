﻿using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public MagicalItemGenerator WeaponGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [TestCase(WeaponConstants.Arrow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Arrow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Arrow, PowerConstants.Major)]
        [TestCase(WeaponConstants.AssassinsDagger, PowerConstants.Medium)]
        [TestCase(WeaponConstants.AssassinsDagger, PowerConstants.Major)]
        [TestCase(WeaponConstants.BastardSword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.BastardSword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.BastardSword, PowerConstants.Major)]
        [TestCase(WeaponConstants.Battleaxe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Battleaxe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Battleaxe, PowerConstants.Major)]
        [TestCase(WeaponConstants.BerserkingSword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.BerserkingSword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.BerserkingSword, PowerConstants.Major)]
        [TestCase(WeaponConstants.Bolas, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Bolas, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Bolas, PowerConstants.Major)]
        [TestCase(WeaponConstants.Club, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Club, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Club, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeLongbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeLongbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeLongbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus0, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus0, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus0, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus0, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus0, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus0, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus1, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus1, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus1, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus1, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus1, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus1, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus2, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus2, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus2, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus2, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus2, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus2, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus3, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus3, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus3, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus4, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus4, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus4, PowerConstants.Major)]
        [TestCase(WeaponConstants.CompositeShortbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CompositeShortbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CompositeShortbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.CrossbowBolt, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CrossbowBolt, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CrossbowBolt, PowerConstants.Major)]
        [TestCase(WeaponConstants.CursedBackbiterSpear, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CursedBackbiterSpear, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CursedBackbiterSpear, PowerConstants.Major)]
        [TestCase(WeaponConstants.CursedMinus2Sword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.CursedMinus2Sword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.CursedMinus2Sword, PowerConstants.Major)]
        [TestCase(WeaponConstants.Dagger, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Dagger, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Dagger, PowerConstants.Major)]
        [TestCase(WeaponConstants.DaggerOfVenom, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Dart, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Dart, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Dart, PowerConstants.Major)]
        [TestCase(WeaponConstants.DireFlail, PowerConstants.Minor)]
        [TestCase(WeaponConstants.DireFlail, PowerConstants.Medium)]
        [TestCase(WeaponConstants.DireFlail, PowerConstants.Major)]
        [TestCase(WeaponConstants.DwarvenThrower, PowerConstants.Major)]
        [TestCase(WeaponConstants.DwarvenUrgrosh, PowerConstants.Minor)]
        [TestCase(WeaponConstants.DwarvenUrgrosh, PowerConstants.Medium)]
        [TestCase(WeaponConstants.DwarvenUrgrosh, PowerConstants.Major)]
        [TestCase(WeaponConstants.DwarvenWaraxe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.DwarvenWaraxe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.DwarvenWaraxe, PowerConstants.Major)]
        [TestCase(WeaponConstants.Falchion, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Falchion, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Falchion, PowerConstants.Major)]
        [TestCase(WeaponConstants.Flail, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Flail, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Flail, PowerConstants.Major)]
        [TestCase(WeaponConstants.FlameTongue, PowerConstants.Medium)]
        [TestCase(WeaponConstants.FlameTongue, PowerConstants.Major)]
        [TestCase(WeaponConstants.FrostBrand, PowerConstants.Major)]
        [TestCase(WeaponConstants.Gauntlet, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Gauntlet, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Gauntlet, PowerConstants.Major)]
        [TestCase(WeaponConstants.Glaive, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Glaive, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Glaive, PowerConstants.Major)]
        [TestCase(WeaponConstants.GnomeHookedHammer, PowerConstants.Minor)]
        [TestCase(WeaponConstants.GnomeHookedHammer, PowerConstants.Medium)]
        [TestCase(WeaponConstants.GnomeHookedHammer, PowerConstants.Major)]
        [TestCase(WeaponConstants.Greataxe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Greataxe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Greataxe, PowerConstants.Major)]
        [TestCase(WeaponConstants.Greatclub, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Greatclub, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Greatclub, PowerConstants.Major)]
        [TestCase(WeaponConstants.GreaterSlayingArrow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Greatsword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Greatsword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Greatsword, PowerConstants.Major)]
        [TestCase(WeaponConstants.Guisarme, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Guisarme, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Guisarme, PowerConstants.Major)]
        [TestCase(WeaponConstants.Halberd, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Halberd, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Halberd, PowerConstants.Major)]
        [TestCase(WeaponConstants.Handaxe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Handaxe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Handaxe, PowerConstants.Major)]
        [TestCase(WeaponConstants.HandCrossbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.HandCrossbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.HandCrossbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.HeavyCrossbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.HeavyCrossbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.HeavyCrossbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.HeavyFlail, PowerConstants.Minor)]
        [TestCase(WeaponConstants.HeavyFlail, PowerConstants.Medium)]
        [TestCase(WeaponConstants.HeavyFlail, PowerConstants.Major)]
        [TestCase(WeaponConstants.HeavyMace, PowerConstants.Minor)]
        [TestCase(WeaponConstants.HeavyMace, PowerConstants.Medium)]
        [TestCase(WeaponConstants.HeavyMace, PowerConstants.Major)]
        [TestCase(WeaponConstants.HeavyPick, PowerConstants.Minor)]
        [TestCase(WeaponConstants.HeavyPick, PowerConstants.Medium)]
        [TestCase(WeaponConstants.HeavyPick, PowerConstants.Major)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.HolyAvenger, PowerConstants.Major)]
        [TestCase(WeaponConstants.Javelin, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Javelin, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Javelin, PowerConstants.Major)]
        [TestCase(WeaponConstants.JavelinOfLightning, PowerConstants.Minor)]
        [TestCase(WeaponConstants.JavelinOfLightning, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Kama, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Kama, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Kama, PowerConstants.Major)]
        [TestCase(WeaponConstants.Kukri, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Kukri, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Kukri, PowerConstants.Major)]
        [TestCase(WeaponConstants.Lance, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Lance, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Lance, PowerConstants.Major)]
        [TestCase(WeaponConstants.LifeDrinker, PowerConstants.Major)]
        [TestCase(WeaponConstants.LightCrossbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.LightCrossbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LightCrossbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.LightHammer, PowerConstants.Minor)]
        [TestCase(WeaponConstants.LightHammer, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LightHammer, PowerConstants.Major)]
        [TestCase(WeaponConstants.LightMace, PowerConstants.Minor)]
        [TestCase(WeaponConstants.LightMace, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LightMace, PowerConstants.Major)]
        [TestCase(WeaponConstants.LightPick, PowerConstants.Minor)]
        [TestCase(WeaponConstants.LightPick, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LightPick, PowerConstants.Major)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.Longbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Longbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Longbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.Longspear, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Longspear, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Longspear, PowerConstants.Major)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major)]
        [TestCase(WeaponConstants.LuckBlade, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LuckBlade, PowerConstants.Major)]
        [TestCase(WeaponConstants.LuckBlade0, PowerConstants.Medium)]
        [TestCase(WeaponConstants.LuckBlade0, PowerConstants.Major)]
        [TestCase(WeaponConstants.LuckBlade1, PowerConstants.Major)]
        [TestCase(WeaponConstants.LuckBlade2, PowerConstants.Major)]
        [TestCase(WeaponConstants.LuckBlade3, PowerConstants.Major)]
        [TestCase(WeaponConstants.MaceOfBlood, PowerConstants.Minor)]
        [TestCase(WeaponConstants.MaceOfBlood, PowerConstants.Medium)]
        [TestCase(WeaponConstants.MaceOfBlood, PowerConstants.Major)]
        [TestCase(WeaponConstants.MaceOfSmiting, PowerConstants.Major)]
        [TestCase(WeaponConstants.MaceOfTerror, PowerConstants.Major)]
        [TestCase(WeaponConstants.Morningstar, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Morningstar, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Morningstar, PowerConstants.Major)]
        [TestCase(WeaponConstants.Net, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Net, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Net, PowerConstants.Major)]
        [TestCase(WeaponConstants.NetOfSnaring, PowerConstants.Minor)]
        [TestCase(WeaponConstants.NetOfSnaring, PowerConstants.Medium)]
        [TestCase(WeaponConstants.NetOfSnaring, PowerConstants.Major)]
        [TestCase(WeaponConstants.NineLivesStealer, PowerConstants.Medium)]
        [TestCase(WeaponConstants.NineLivesStealer, PowerConstants.Major)]
        [TestCase(WeaponConstants.Nunchaku, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Nunchaku, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Nunchaku, PowerConstants.Major)]
        [TestCase(WeaponConstants.Oathbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Oathbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.OrcDoubleAxe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.OrcDoubleAxe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.OrcDoubleAxe, PowerConstants.Major)]
        [TestCase(WeaponConstants.PincerStaff, PowerConstants.Minor)]
        [TestCase(WeaponConstants.PincerStaff, PowerConstants.Medium)]
        [TestCase(WeaponConstants.PincerStaff, PowerConstants.Major)]
        [TestCase(WeaponConstants.PunchingDagger, PowerConstants.Minor)]
        [TestCase(WeaponConstants.PunchingDagger, PowerConstants.Medium)]
        [TestCase(WeaponConstants.PunchingDagger, PowerConstants.Major)]
        [TestCase(WeaponConstants.Quarterstaff, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Quarterstaff, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Quarterstaff, PowerConstants.Major)]
        [TestCase(WeaponConstants.Ranseur, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Ranseur, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Ranseur, PowerConstants.Major)]
        [TestCase(WeaponConstants.Rapier, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Rapier, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Rapier, PowerConstants.Major)]
        [TestCase(WeaponConstants.RapierOfPuncturing, PowerConstants.Major)]
        [TestCase(WeaponConstants.Sai, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Sai, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Sai, PowerConstants.Major)]
        [TestCase(WeaponConstants.Sap, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Sap, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Sap, PowerConstants.Major)]
        [TestCase(WeaponConstants.Scimitar, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Scimitar, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Scimitar, PowerConstants.Major)]
        [TestCase(WeaponConstants.ScreamingBolt, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Scythe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Scythe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Scythe, PowerConstants.Major)]
        [TestCase(WeaponConstants.Shatterspike, PowerConstants.Medium)]
        [TestCase(WeaponConstants.ShiftersSorrow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.ShiftersSorrow, PowerConstants.Major)]
        [TestCase(WeaponConstants.Shortbow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Shortbow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Shortbow, PowerConstants.Major)]
        [TestCase(WeaponConstants.Shortspear, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Shortspear, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Shortspear, PowerConstants.Major)]
        [TestCase(WeaponConstants.ShortSword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.ShortSword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.ShortSword, PowerConstants.Major)]
        [TestCase(WeaponConstants.Shuriken, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Shuriken, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Shuriken, PowerConstants.Major)]
        [TestCase(WeaponConstants.Siangham, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Siangham, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Siangham, PowerConstants.Major)]
        [TestCase(WeaponConstants.Sickle, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Sickle, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Sickle, PowerConstants.Major)]
        [TestCase(WeaponConstants.Dagger_Silver, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Dagger_Adamantine, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Dagger_Adamantine, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Battleaxe_Adamantine, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Battleaxe_Adamantine, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SlayingArrow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.SlayingArrow, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SleepArrow, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Sling, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Sling, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Sling, PowerConstants.Major)]
        [TestCase(WeaponConstants.SlingBullet, PowerConstants.Minor)]
        [TestCase(WeaponConstants.SlingBullet, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SlingBullet, PowerConstants.Major)]
        [TestCase(WeaponConstants.Spear, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Spear, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Spear, PowerConstants.Major)]
        [TestCase(WeaponConstants.SpikedChain, PowerConstants.Minor)]
        [TestCase(WeaponConstants.SpikedChain, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SpikedChain, PowerConstants.Major)]
        [TestCase(WeaponConstants.SpikedGauntlet, PowerConstants.Minor)]
        [TestCase(WeaponConstants.SpikedGauntlet, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SpikedGauntlet, PowerConstants.Major)]
        [TestCase(WeaponConstants.SunBlade, PowerConstants.Major)]
        [TestCase(WeaponConstants.SwordOfLifeStealing, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SwordOfLifeStealing, PowerConstants.Major)]
        [TestCase(WeaponConstants.SwordOfSubtlety, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SwordOfSubtlety, PowerConstants.Major)]
        [TestCase(WeaponConstants.SwordOfThePlanes, PowerConstants.Medium)]
        [TestCase(WeaponConstants.SwordOfThePlanes, PowerConstants.Major)]
        [TestCase(WeaponConstants.SylvanScimitar, PowerConstants.Major)]
        [TestCase(WeaponConstants.ThrowingAxe, PowerConstants.Minor)]
        [TestCase(WeaponConstants.ThrowingAxe, PowerConstants.Medium)]
        [TestCase(WeaponConstants.ThrowingAxe, PowerConstants.Major)]
        [TestCase(WeaponConstants.Trident, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Trident, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Trident, PowerConstants.Major)]
        [TestCase(WeaponConstants.TridentOfFishCommand, PowerConstants.Medium)]
        [TestCase(WeaponConstants.TridentOfFishCommand, PowerConstants.Major)]
        [TestCase(WeaponConstants.TridentOfWarning, PowerConstants.Medium)]
        [TestCase(WeaponConstants.TwoBladedSword, PowerConstants.Minor)]
        [TestCase(WeaponConstants.TwoBladedSword, PowerConstants.Medium)]
        [TestCase(WeaponConstants.TwoBladedSword, PowerConstants.Major)]
        [TestCase(WeaponConstants.Warhammer, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Warhammer, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Warhammer, PowerConstants.Major)]
        [TestCase(WeaponConstants.Whip, PowerConstants.Minor)]
        [TestCase(WeaponConstants.Whip, PowerConstants.Medium)]
        [TestCase(WeaponConstants.Whip, PowerConstants.Major)]
        public void GenerateWeapon(string itemName, string power)
        {
            var isOfPower = WeaponGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = WeaponGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }

        [Test]
        public void AllWeaponsCanBeGenerated()
        {
            var weapons = WeaponConstants.GetAllWeapons(true, true);

            foreach (var weapon in weapons)
            {
                var isMinor = WeaponGenerator.IsItemOfPower(weapon, PowerConstants.Minor);
                var isMedium = WeaponGenerator.IsItemOfPower(weapon, PowerConstants.Medium);
                var isMajor = WeaponGenerator.IsItemOfPower(weapon, PowerConstants.Major);

                Assert.That(true, Is.EqualTo(isMinor)
                    .Or.EqualTo(isMedium)
                    .Or.EqualTo(isMajor), weapon);
            }
        }

        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Colossal)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Gargantuan)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Huge)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Large)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Medium)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Small)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Minor, TraitConstants.Sizes.Tiny)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Colossal)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Gargantuan)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Huge)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Large)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Medium)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Small)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Medium, TraitConstants.Sizes.Tiny)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Colossal)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Gargantuan)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Huge)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Large)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Medium)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Small)]
        [TestCase(WeaponConstants.Longsword, PowerConstants.Major, TraitConstants.Sizes.Tiny)]
        public void GenerateWeaponOfSize(string itemName, string power, string size)
        {
            var isOfPower = WeaponGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = WeaponGenerator.Generate(power, itemName, "my trait", size);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon), $"{weapon.Name} {weapon.Magic.Curse}");
            Assert.That(weapon.NameMatches(itemName), Is.True, $"{weapon.Name} {weapon.Magic.Curse}");
            Assert.That(weapon.Size, Is.EqualTo(size), $"{weapon.Name} {weapon.Magic.Curse}");
            Assert.That(weapon.Traits, Does.Not.Contain(size)
                .And.Contains("my trait"), $"{weapon.Name} {weapon.Magic.Curse}");
        }

        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeLongbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeLongbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeLongbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeLongbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeLongbow_StrengthPlus3, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeLongbow_StrengthPlus4, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeShortbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeShortbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeShortbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.CompositeShortbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.HandCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Minor, WeaponConstants.HeavyCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Minor, WeaponConstants.HeavyRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Minor, WeaponConstants.LightCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Minor, WeaponConstants.LightRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Minor, WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.Shortbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Minor, WeaponConstants.Sling, WeaponConstants.SlingBullet)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeLongbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeLongbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeLongbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeLongbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeLongbow_StrengthPlus3, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeLongbow_StrengthPlus4, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeShortbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeShortbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeShortbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.CompositeShortbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.HandCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Medium, WeaponConstants.HeavyCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Medium, WeaponConstants.HeavyRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Medium, WeaponConstants.LightCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Medium, WeaponConstants.LightRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Medium, WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.Shortbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Medium, WeaponConstants.Sling, WeaponConstants.SlingBullet)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeLongbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeLongbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeLongbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeLongbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeLongbow_StrengthPlus3, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeLongbow_StrengthPlus4, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeShortbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeShortbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeShortbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.CompositeShortbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.HandCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Major, WeaponConstants.HeavyCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Major, WeaponConstants.HeavyRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Major, WeaponConstants.LightCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Major, WeaponConstants.LightRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(PowerConstants.Major, WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.Shortbow, WeaponConstants.Arrow)]
        [TestCase(PowerConstants.Major, WeaponConstants.Sling, WeaponConstants.SlingBullet)]
        public void GenerateWeaponWithAmmunition(string power, string weaponName, string ammunition)
        {
            var item = WeaponGenerator.Generate(power, weaponName);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Weapon>(), item.Name);

            var weapon = item as Weapon;
            Assert.That(weapon.Ammunition, Is.EqualTo(ammunition), item.Name);
        }
    }
}
