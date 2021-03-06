﻿using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Items.Magical
{
    public static class PotionConstants
    {
        public const string Aid = "Potion of aid";
        public const string Barkskin = "Potion of barkskin";
        public const string BearsEndurance = "Potion of bear's endurance";
        public const string BlessWeapon = "Oil of bless weapon";
        public const string Blur = "Potion of blur";
        public const string BullsStrength = "Potion of bull's strength";
        public const string CatsGrace = "Potion of cat's grace";
        public const string CureLightWounds = "Potion of cure light wounds";
        public const string CureModerateWounds = "Potion of cure moderate wounds";
        public const string CureSeriousWounds = "Potion of cure serious wounds";
        public const string Darkness = "Oil of darkness";
        public const string Darkvision = "Potion of darkvision";
        public const string Daylight = "Oil of daylight";
        public const string DelayPoison = "Potion of delay poison";
        public const string Displacement = "Potion of displacement";
        public const string EaglesSplendor = "Potion of eagle's splendor";
        public const string EndureElements = "Potion of endure elements";
        public const string EnlargePerson = "Potion of enlarge person";
        public const string FlameArrow = "Oil of flame arrow";
        public const string Fly = "Potion of fly";
        public const string FoxsCunning = "Potion of fox's cunning";
        public const string GaseousForm = "Potion of gaseous form";
        public const string GoodHope = "Potion of good hope";
        public const string Haste = "Potion of haste";
        public const string Heroism = "Potion of heroism";
        public const string HideFromAnimals = "Potion of hide from animals";
        public const string HideFromUndead = "Potion of hide from undead";
        public const string Invisibility_Oil = "Oil of invisibility";
        public const string Invisibility_Potion = "Potion of invisibility";
        public const string Jump = "Potion of jump";
        public const string KeenEdge = "Oil of keen edge";
        public const string Levitate_Oil = "Oil of levitate";
        public const string Levitate_Potion = "Potion of levitate";
        public const string MageArmor = "Potion of mage armor";
        public const string MagicCircleAgainstPARTIALALIGNMENT = "Potion of magic circle against PARTIALALIGNMENT";
        public const string MagicCircleAgainstChaos = "Potion of magic circle against Chaos";
        public const string MagicCircleAgainstLaw = "Potion of magic circle against Law";
        public const string MagicCircleAgainstGood = "Potion of magic circle against Good";
        public const string MagicCircleAgainstEvil = "Potion of magic circle against Evil";
        public const string MagicFang = "Potion of magic fang";
        public const string MagicFang_Greater = "Potion of greater magic fang";
        public const string MagicStone = "Oil of magic stone";
        public const string MagicVestment = "Oil of magic vestment";
        public const string MagicWeapon = "Oil of magic weapon";
        public const string MagicWeapon_Greater = "Oil of greater magic weapon";
        public const string Misdirection = "Potion of misdirection";
        public const string NeutralizePoison = "Potion of neutralize poison";
        public const string Nondetection = "Potion of nondetection";
        public const string OwlsWisdom = "Potion of owl's wisdom";
        public const string PassWithoutTrace = "Potion of pass without trace";
        public const string Poison = "Potion of poison";
        public const string ProtectionFromPARTIALALIGNMENT = "Potion of protection from PARTIALALIGNMENT";
        public const string ProtectionFromChaos = "Potion of protection from Chaos";
        public const string ProtectionFromLaw = "Potion of protection from Law";
        public const string ProtectionFromGood = "Potion of protection from Good";
        public const string ProtectionFromEvil = "Potion of protection from Evil";
        public const string ProtectionFromArrows_10 = "Potion of protection from arrows 10/magic";
        public const string ProtectionFromArrows_15 = "Potion of protection from arrows 15/magic";
        public const string ProtectionFromENERGY = "Potion of protection from ENERGY";
        public const string ProtectionFromAcid = "Potion of protection from Acid";
        public const string ProtectionFromCold = "Potion of protection from Cold";
        public const string ProtectionFromElectricity = "Potion of protection from Electricity";
        public const string ProtectionFromFire = "Potion of protection from Fire";
        public const string ProtectionFromSonic = "Potion of protection from Sonic";
        public const string Rage = "Potion of rage";
        public const string RemoveBlindnessDeafness = "Potion of remove blindness/deafness";
        public const string RemoveCurse = "Potion of remove curse";
        public const string RemoveDisease = "Potion of remove disease";
        public const string ReducePerson = "Potion of reduce person";
        public const string RemoveFear = "Potion of remove fear";
        public const string RemoveParalysis = "Potion of remove paralysis";
        public const string ResistENERGY_10 = "Potion of resist ENERGY 10";
        public const string ResistAcid_10 = "Potion of resist Acid 10";
        public const string ResistCold_10 = "Potion of resist Cold 10";
        public const string ResistElectricity_10 = "Potion of resist Electricity 10";
        public const string ResistFire_10 = "Potion of resist Fire 10";
        public const string ResistSonic_10 = "Potion of resist Sonic 10";
        public const string ResistENERGY_20 = "Potion of resist ENERGY 20";
        public const string ResistAcid_20 = "Potion of resist Acid 20";
        public const string ResistCold_20 = "Potion of resist Cold 20";
        public const string ResistElectricity_20 = "Potion of resist Electricity 20";
        public const string ResistFire_20 = "Potion of resist Fire 20";
        public const string ResistSonic_20 = "Potion of resist Sonic 20";
        public const string ResistENERGY_30 = "Potion of resist ENERGY 30";
        public const string ResistAcid_30 = "Potion of resist Acid 30";
        public const string ResistCold_30 = "Potion of resist Cold 30";
        public const string ResistElectricity_30 = "Potion of resist Electricity 30";
        public const string ResistFire_30 = "Potion of resist Fire 30";
        public const string ResistSonic_30 = "Potion of resist Sonic 30";
        public const string Restoration_Lesser = "Potion of lesser restoration";
        public const string Sanctuary = "Potion of sanctuary";
        public const string ShieldOfFaith = "Potion of shield of faith";
        public const string Shillelagh = "Oil of shillelagh";
        public const string SpiderClimb = "Potion of spider climb";
        public const string Tongues = "Potion of tongues";
        public const string UndetectableAlignment = "Potion of undetectable alignment";
        public const string WaterBreathing = "Potion of water breathing";
        public const string WaterWalk = "Potion of water walk";

        public static IEnumerable<string> GetAllPotions(bool includeTemplates)
        {
            var potions = new[]
            {
                Aid,
                Barkskin,
                BearsEndurance,
                BlessWeapon,
                Blur,
                BullsStrength,
                CatsGrace,
                CureLightWounds,
                CureModerateWounds,
                CureSeriousWounds,
                Darkness,
                Darkvision,
                Daylight,
                DelayPoison,
                Displacement,
                EaglesSplendor,
                EndureElements,
                EnlargePerson,
                FlameArrow,
                Fly,
                FoxsCunning,
                GaseousForm,
                GoodHope,
                Haste,
                Heroism,
                HideFromAnimals,
                HideFromUndead,
                Invisibility_Oil,
                Invisibility_Potion,
                Jump,
                KeenEdge,
                Levitate_Oil,
                Levitate_Potion,
                MageArmor,
                MagicCircleAgainstChaos,
                MagicCircleAgainstEvil,
                MagicCircleAgainstGood,
                MagicCircleAgainstLaw,
                MagicFang,
                MagicFang_Greater,
                MagicStone,
                MagicVestment,
                MagicWeapon,
                MagicWeapon_Greater,
                Misdirection,
                NeutralizePoison,
                Nondetection,
                OwlsWisdom,
                PassWithoutTrace,
                Poison,
                ProtectionFromAcid,
                ProtectionFromChaos,
                ProtectionFromCold,
                ProtectionFromElectricity,
                ProtectionFromEvil,
                ProtectionFromFire,
                ProtectionFromGood,
                ProtectionFromLaw,
                ProtectionFromSonic,
                ProtectionFromArrows_10,
                ProtectionFromArrows_15,
                Rage,
                RemoveBlindnessDeafness,
                RemoveCurse,
                RemoveDisease,
                ReducePerson,
                RemoveFear,
                RemoveParalysis,
                ResistAcid_10,
                ResistAcid_20,
                ResistAcid_30,
                ResistCold_10,
                ResistCold_20,
                ResistCold_30,
                ResistElectricity_10,
                ResistElectricity_20,
                ResistElectricity_30,
                ResistFire_10,
                ResistFire_20,
                ResistFire_30,
                ResistSonic_10,
                ResistSonic_20,
                ResistSonic_30,
                Restoration_Lesser,
                Sanctuary,
                ShieldOfFaith,
                Shillelagh,
                SpiderClimb,
                Tongues,
                UndetectableAlignment,
                WaterBreathing,
                WaterWalk,
            };

            var templates = new[]
            {
                MagicCircleAgainstPARTIALALIGNMENT,
                ProtectionFromENERGY,
                ProtectionFromPARTIALALIGNMENT,
                ResistENERGY_10,
                ResistENERGY_20,
                ResistENERGY_30,
            };

            if (includeTemplates)
                return potions.Union(templates);

            return potions;
        }
    }
}