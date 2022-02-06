using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitDataEventHandler : MonoBehaviour
{
    public UnityEvent<string> UpdateBattlesPlayed, UpdateBattlesWon, UpdateSupplyLimit, UpdateSupplyUsed;
}
