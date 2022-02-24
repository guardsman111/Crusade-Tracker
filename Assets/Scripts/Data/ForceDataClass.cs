using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrusadeTracker
{
    public class UnitDataCard 
    {
        public UnitDataClass unitData;
    }

    public class ForceDataClass
    {
        public string CrusadeForceName, CrusadeFaction, PlayerName;
        public int BattlesPlayed, BattlesWon;

        public int SupplyLimit;
        public int SupplyUsed;
        public List<UnitDataCard> UnitCards; // int UID links to the UnitDataClass

        public List<string> Goals, Information, NotableVictories;
    }
}
