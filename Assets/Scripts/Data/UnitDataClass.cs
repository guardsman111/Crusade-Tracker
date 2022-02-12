using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrusadeTracker
{
    public class EquipmentData
    {
        public string UID;
        public string EquipmentName;
        public int Quantity;
    }

    public enum BattlefieldRole
    {
        HQ,
        Troop,
        Elite,
        FastAttack,
        Flyer,
        HeavySupport,
        Fortification,
        DedicatedTransport,
        LordOfWar,
    }

    public enum Rank 
    { 
        BattleReady,
        Blooded,
        BattleHardened,
        Heroic,
        Legendary
    }

    public class UnitDataClass
    {
        public string UnitName;
        public BattlefieldRole UnitBattlefieldRole;
        public string CrusadeFaction, SelectableKeywords;
        public int PowerRating, CrusadePoints, ExperiencePoints;
        public string UnitType;
        public List<EquipmentData> Equipment;
        public string PsychicPowers,WarlordTraits, Relics;
        public string OtherAbilities;

        public int BattlesPlayed, BattlesSurvived;
        public int EnemyUnitsDestroyedThisBattle, EnemyUnitsDestroyedTotal;
        public int EnemyUnitsDestroyedWithPsychicThisBattle, EnemyUnitsDestroyedWithPsychicTotal;
        public int EnemyUnitsDestroyedWithRangedThisBattle, EnemyUnitsDestroyedWithRangedTotal;
        public int EnemyUnitsDestroyedWithMeleeThisBattle, EnemyUnitsDestroyedWithMeleeTotal;

        public int Agenda1Tally, Agenda2Tally, Agenda3Tally;

        public Rank UnitRank;
        public string BattleHonours, BattleScars;
    }
}
