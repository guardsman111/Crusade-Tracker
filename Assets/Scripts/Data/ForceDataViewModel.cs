using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrusadeTracker
{
    public class ForceDataViewModel : MonoBehaviour
    {
        public ForceWindow ForceWindow;
        public ForceDataEventHandler eventHandler;
        public UnitDataViewModel UnitScreen;

        private ForceDataClass ForceData;
        public Dictionary<GameObject, UnitDataClass> UnitDataDictionary = new Dictionary<GameObject, UnitDataClass>();

        public GameObject UnitsContentHome;
        public List<GameObject> UnitCards = new List<GameObject>();
        public CardUpdater CurrentCardUpdater;
        public GameObject PrefabUnitCard;

        public void OnApplicationQuit()
        {
            SaveForce();
        }

        public void SaveForce()
        {
            SaveData.SaveForceData(ForceData);
        }

        public void LoadForce(string path)
        {
            ForceData = SaveData.LoadForceData(path);
            if (ForceData != null)
            {
                ForceWindow.SetupForceTexts(ForceData);
                foreach(UnitDataCard unitData in ForceData.UnitCards)
                {
                    LoadUnit(unitData.unitData, ForceData.UnitCards.IndexOf(unitData));
                }
            }
            else
            {
                NewForce();
            }
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

        public void AddNewUnit()
        {
            if (ForceData.UnitCards == null)
                ForceData.UnitCards = new List<UnitDataCard>();
            GameObject newUnit = Instantiate(PrefabUnitCard, UnitsContentHome.transform);
            newUnit.transform.localPosition = new Vector3(0, -270 * ForceData.UnitCards.Count);
            DataCarrier carrier = newUnit.GetComponent<DataCarrier>();
            carrier.GO = newUnit;

            UnitDataCard newUnitData = new UnitDataCard();
            newUnitData.unitData = new UnitDataClass();

            ForceData.UnitCards.Add(newUnitData);
            UnitDataDictionary.Add(newUnit, newUnitData.unitData);
            UnitCards.Add(newUnit);

            CurrentCardUpdater = carrier.GetComponent<CardUpdater>();
            CurrentCardUpdater.ForceScreen = this;

            RectTransform UnitsContent = UnitsContentHome.transform.parent.GetComponent<RectTransform>();
            UnitsContent.sizeDelta = new Vector2(UnitsContent.sizeDelta.x, 270 * ForceData.UnitCards.Count);
        }

        public void LoadUnit(UnitDataClass unit, int index)
        {
            if (ForceData.UnitCards == null)
                ForceData.UnitCards = new List<UnitDataCard>();
            GameObject newUnit = Instantiate(PrefabUnitCard, UnitsContentHome.transform);
            newUnit.transform.localPosition = new Vector3(0, -270 * index);
            DataCarrier carrier = newUnit.GetComponent<DataCarrier>();
            carrier.GO = newUnit;

            UnitDataCard newUnitData = new UnitDataCard();
            newUnitData.unitData = unit;
            UnitDataDictionary.Add(newUnit, newUnitData.unitData);
            UnitCards.Add(newUnit);

            CurrentCardUpdater = carrier.GetComponent<CardUpdater>();
            CurrentCardUpdater.ForceScreen = this;
            CurrentCardUpdater.unitName.text = unit.UnitName;
            CurrentCardUpdater.unitPL.text = unit.PowerRating.ToString() + " PL";
            CurrentCardUpdater.unitCP.text = unit.CrusadePoints.ToString() + " CP";
        }

        public void OpenUnit(DataCarrier carrier) 
        {
            SaveForce();
            if (UnitDataDictionary.ContainsKey(carrier.gameObject)) 
            {
                UnitDataClass unitData;
                UnitDataDictionary.TryGetValue(carrier.GO, out unitData);
                CurrentCardUpdater = carrier.GetComponent<CardUpdater>();
                OpenUnitScreen(unitData);
            }
        }

        public void OpenUnitScreen(UnitDataClass unitData)
        {
            RectTransform UnitsContent = UnitsContentHome.transform.parent.GetComponent<RectTransform>();

            UnitsContent.sizeDelta = new Vector2(UnitsContent.sizeDelta.x, 270 * ForceData.UnitCards.Count);
            UnitScreen.CurrentUnitData = unitData;
            UnitScreen.gameObject.SetActive(true);
            ForceWindow.gameObject.SetActive(false);
            UnitScreen.OpenUnit(unitData);
        }
    }
}
