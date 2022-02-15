using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CrusadeTracker
{
    public class UnitTallyEventHandler : MonoBehaviour
    {
        public UnityEvent<string> UpdateExperience, UpdateBattlesPlayed, UpdateBattlesSurvived, UpdateEnemiesPsychic, UpdateEnemiesRanged, UpdateEnemiesMelee, UpdateEnemiesTotal;
    }
}
