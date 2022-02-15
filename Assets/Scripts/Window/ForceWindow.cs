using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CrusadeTracker
{
    public class ForceWindow : MonoBehaviour
    {
        public ForceDataViewModel ForceScreen;
        public UnitDataViewModel UnitScreen;

        public TMP_InputField ForceName;
        public TMP_InputField ForceFaction;
        public TMP_InputField PlayerName;
        public TextMeshProUGUI BattlesPlayed;
        public TextMeshProUGUI BattlesWon;
        public TextMeshProUGUI SupplyLimit;
        public TextMeshProUGUI SupplyUsed;

        public void SetupForceTexts(ForceDataClass unit)
        {
            ForceName.text = unit.CrusadeForceName;
            ForceFaction.text = unit.CrusadeFaction;
            PlayerName.text = unit.PlayerName;
            BattlesPlayed.text = unit.BattlesPlayed.ToString();
            BattlesWon.text = unit.BattlesWon.ToString();
            SupplyLimit.text = unit.SupplyLimit.ToString() + " CP";
            SupplyUsed.text = unit.SupplyUsed.ToString() + " CP";
        }
    }
}

