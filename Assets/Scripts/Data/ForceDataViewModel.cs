using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrusadeTracker
{
    public class ForceDataViewModel : MonoBehaviour
    {
        public ForceDataEventHandler eventHandler;

        private ForceDataClass ForceData;
        public Dictionary<int, UnitDataClass> UnitDataDictionary;

        private void Start()
        {
            NewForce();
        }

        public void NewForce() 
        {
            ForceData = new ForceDataClass();
            ForceData.SupplyLimit = 50;
        }

        public void SetForceName(string newName) 
        {
            ForceData.CrusadeForceName = newName;
        }

        public void SetForceFaction(string newName)
        {
            ForceData.CrusadeFaction = newName;
        }

        public void SetPlayerName(string newName)
        {
            ForceData.PlayerName = newName;
        }

        public void UpdateBattlesPlayed(int value)
        {
            if(value > 0)
                ForceData.BattlesPlayed += value;
            else
                ForceData.BattlesPlayed += value;

            eventHandler.UpdateBattlesPlayed.Invoke(ForceData.BattlesPlayed.ToString());
        }

        public void UpdateBattlesWon(int value)
        {
            if (value > 0)
                ForceData.BattlesWon += value;
            else
                ForceData.BattlesWon += value;
            eventHandler.UpdateBattlesWon.Invoke(ForceData.BattlesWon.ToString());
        }

        public void UpdateSupplyLimit(int value)
        {
            if (value > 0)
                ForceData.SupplyLimit += value;
            else
                ForceData.SupplyLimit += value;
            eventHandler.UpdateSupplyLimit.Invoke(ForceData.SupplyLimit.ToString());
        }

        public void UpdateSupplyUsed(int value)
        {
            if (value > 0)
            {
                ForceData.SupplyUsed += value;
            }
            else
                ForceData.SupplyUsed += value;
            eventHandler.UpdateSupplyUsed.Invoke(ForceData.SupplyUsed.ToString());
        }
    }
}
