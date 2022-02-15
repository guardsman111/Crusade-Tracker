using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CrusadeTracker
{
    public class TallyWindow : MonoBehaviour
    {
        public TextMeshProUGUI UnitName;
        public TextMeshProUGUI ExperiencePoints;
        public TMP_Dropdown Rank;
        public TextMeshProUGUI BattlesPlayed;
        public TextMeshProUGUI BattlesSurvived;
        public TextMeshProUGUI EnemiesDestroyedPsychic;
        public TextMeshProUGUI EnemiesDestroyedRanged;
        public TextMeshProUGUI EnemiesDestroyedMelee;
        public TextMeshProUGUI EnemiesDestroyedTotal;
        public TMP_InputField BattleHonours;
        public TMP_InputField BattleScars;

        public void SetupUnitTallies(UnitDataClass unitData)
        {
            UnitName.text = unitData.UnitName;
            ExperiencePoints.text = unitData.ExperiencePoints.ToString();
            BattlesPlayed.text = unitData.BattlesPlayed.ToString();
            BattlesSurvived.text = unitData.BattlesSurvived.ToString();
            EnemiesDestroyedPsychic.text = unitData.EnemyUnitsDestroyedWithPsychicTotal.ToString();
            EnemiesDestroyedRanged.text = unitData.EnemyUnitsDestroyedWithRangedTotal.ToString();
            EnemiesDestroyedMelee.text = unitData.EnemyUnitsDestroyedWithMeleeTotal.ToString();
            EnemiesDestroyedTotal.text = unitData.EnemyUnitsDestroyedTotal.ToString();
            BattleHonours.text = unitData.BattleHonours;
            BattleScars.text = unitData.BattleScars;

            switch (unitData.UnitRank)
            {
                case CrusadeTracker.Rank.BattleReady:
                    Rank.value = 0;
                    break;
                case CrusadeTracker.Rank.Blooded:
                    Rank.value = 1;
                    break;
                case CrusadeTracker.Rank.BattleHardened:
                    Rank.value = 2;
                    break;
                case CrusadeTracker.Rank.Heroic:
                    Rank.value = 3;
                    break;
                case CrusadeTracker.Rank.Legendary:
                    Rank.value = 4;
                    break;
                default:
                    Rank.value = 0;
                    break;
            }
        }
    }
}
