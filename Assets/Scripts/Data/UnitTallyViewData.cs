using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CrusadeTracker
{
    public class UnitTallyViewData : MonoBehaviour
    {
        public UnitTallyEventHandler eventHandler;
        public UnitDataViewModel UnitScreen;
        [SerializeField] ForceDataViewModel ForceScreen;

        public UnitDataClass CurrentUnitData;

        public void OpenUnit(UnitDataClass unit)
        {
            CurrentUnitData = unit;

            GetComponent<TallyWindow>().SetupUnitTallies(unit);
        }

        public void UpdateExperience(int value)
        {
            CurrentUnitData.ExperiencePoints += value;
            eventHandler.UpdateExperience.Invoke(CurrentUnitData.ExperiencePoints.ToString());
        }

        public void SetRank(TMP_Dropdown BattlefieldRoleDropdown)
        {
            switch (BattlefieldRoleDropdown.value)
            {
                case 0:
                    CurrentUnitData.UnitRank = Rank.BattleReady;
                    break;
                case 1:
                    CurrentUnitData.UnitRank = Rank.Blooded;
                    break;
                case 2:
                    CurrentUnitData.UnitRank = Rank.BattleHardened;
                    break;
                case 3:
                    CurrentUnitData.UnitRank = Rank.Heroic;
                    break;
                case 4:
                    CurrentUnitData.UnitRank = Rank.Legendary;
                    break;
                default:
                    CurrentUnitData.UnitRank = Rank.BattleReady;
                    break;
            }
        }

        public void UpdateBattlesPlayed(int value)
        {
            CurrentUnitData.BattlesPlayed += value;
            eventHandler.UpdateBattlesPlayed.Invoke(CurrentUnitData.BattlesPlayed.ToString());
        }

        public void UpdateBattlesSurvived(int value)
        {
            CurrentUnitData.BattlesSurvived += value;
            eventHandler.UpdateBattlesSurvived.Invoke(CurrentUnitData.BattlesSurvived.ToString());
        }

        public void UpdateEnemiesDestroyedPsychic(int value)
        {
            CurrentUnitData.EnemyUnitsDestroyedWithPsychicTotal += value;
            eventHandler.UpdateEnemiesPsychic.Invoke(CurrentUnitData.EnemyUnitsDestroyedWithPsychicTotal.ToString());
            UpdateEnemiesDestroyedTotal(value);
        }

        public void UpdateEnemiesDestroyedRanged(int value)
        {
            CurrentUnitData.EnemyUnitsDestroyedWithRangedTotal += value;
            eventHandler.UpdateEnemiesRanged.Invoke(CurrentUnitData.EnemyUnitsDestroyedWithRangedTotal.ToString());
            UpdateEnemiesDestroyedTotal(value);
        }

        public void UpdateEnemiesDestroyedMelee(int value)
        {
            CurrentUnitData.EnemyUnitsDestroyedWithMeleeTotal += value;
            eventHandler.UpdateEnemiesMelee.Invoke(CurrentUnitData.EnemyUnitsDestroyedWithMeleeTotal.ToString());
            UpdateEnemiesDestroyedTotal(value);
        }

        public void UpdateEnemiesDestroyedTotal(int value)
        {
            CurrentUnitData.EnemyUnitsDestroyedTotal += value;
            eventHandler.UpdateEnemiesTotal.Invoke(CurrentUnitData.EnemyUnitsDestroyedTotal.ToString());
        }

        public void SetBattleHonours(string newHonours)
        {
            CurrentUnitData.BattleHonours = newHonours;
        }

        public void SetBattleScars(string newScars)
        {
            CurrentUnitData.BattleScars = newScars;
        }
    }
}
