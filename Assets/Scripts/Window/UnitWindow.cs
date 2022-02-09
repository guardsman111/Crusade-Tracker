using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CrusadeTracker
{
    public class UnitWindow : MonoBehaviour
    {
        public TMP_InputField UnitName;
        public TMP_InputField CrusadeFaction;
        public TMP_InputField SelectableKeywords;
        public TMP_InputField UnitType;
        public TextMeshProUGUI PowerLevel;
        public TextMeshProUGUI CrusadePoints;
        public TMP_InputField PsychicPowers;
        public TMP_InputField WarlordTraits;
        public TMP_InputField Relics;

        public TMP_Dropdown BattlefieldRole;

        public void SetupUnitTexts(UnitDataClass unit) 
        {
            UnitName.text = unit.UnitName;
            CrusadeFaction.text = unit.CrusadeFaction;
            SelectableKeywords.text = unit.SelectableKeywords;
            UnitType.text = unit.UnitType;
            PowerLevel.text = unit.PowerRating.ToString() + " PL";
            CrusadePoints.text = unit.CrusadePoints.ToString() + " CP";
            PsychicPowers.text = unit.PsychicPowers;
            WarlordTraits.text = unit.WarlordTraits;
            Relics.text = unit.Relics;

            switch(unit.UnitBattlefieldRole)
            {
                case CrusadeTracker.BattlefieldRole.HQ:
                    BattlefieldRole.value = 0;
                    break;
                case CrusadeTracker.BattlefieldRole.Troop:
                    BattlefieldRole.value = 1;
                    break;
                case CrusadeTracker.BattlefieldRole.Elite:
                    BattlefieldRole.value = 2;
                    break;
                case CrusadeTracker.BattlefieldRole.FastAttack:
                    BattlefieldRole.value = 3;
                    break;
                case CrusadeTracker.BattlefieldRole.Flyer:
                    BattlefieldRole.value = 4;
                    break;
                case CrusadeTracker.BattlefieldRole.HeavySupport:
                    BattlefieldRole.value = 5;
                    break;
                case CrusadeTracker.BattlefieldRole.Fortification:
                    BattlefieldRole.value = 6;
                    break;
                case CrusadeTracker.BattlefieldRole.DedicatedTransport:
                    BattlefieldRole.value = 7;
                    break;
                case CrusadeTracker.BattlefieldRole.LordOfWar:
                    BattlefieldRole.value = 8;
                    break;
                default:
                    BattlefieldRole.value = 0;
                    break;
            }
        }
    }
}
