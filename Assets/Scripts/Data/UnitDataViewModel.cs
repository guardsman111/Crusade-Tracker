using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CrusadeTracker
{
    public class UnitDataViewModel : MonoBehaviour
    {
        public UnitDataEventHandler eventHandler;
        [SerializeField] ForceDataViewModel ForceScreen;

        public RectTransform EquipmentContent;

        public UnitDataClass CurrentUnitData;
        private Dictionary<string, UnitDataClass> UnitCards; // int GUI links to the UnitDataClass

        public GameObject EquipmentContentHome;
        public List<GameObject> EquipmentCards = new List<GameObject>();
        public GameObject PrefabEquipmentCard;

        public void NewUnit()
        {
            CurrentUnitData = new UnitDataClass();
        }

        public void OpenUnit(UnitDataClass unit) 
        {
            CurrentUnitData = unit;
            ClearEquipment();

            GetComponent<UnitWindow>().SetupUnitTexts(unit);

            foreach (EquipmentData equipData in unit.Equipment)
            {
                GameObject newEquip = CreateEquipmentCard();
                DataCarrier carrier = newEquip.GetComponent<DataCarrier>();
                carrier.UID = equipData.UID;
                carrier.name.text = equipData.EquipmentName;
                carrier.quantity.text = equipData.Quantity.ToString();
                carrier.UnitScreen = this;

                EquipmentCards.Add(newEquip);
            }

            EquipmentContent.sizeDelta = new Vector2(EquipmentContent.sizeDelta.x, 180 * CurrentUnitData.Equipment.Count);
        }

        public void ClearEquipment()
        {
            for (int i = EquipmentCards.Count; i > 0; i--)
            {
                Destroy(EquipmentCards[0]);
                EquipmentCards.RemoveAt(0);
            }
        }

        public void SetUnitName(string newName)
        {
            CurrentUnitData.UnitName = newName;
            ForceScreen.CurrentCardUpdater.unitName.text = newName;
        }

        public void SetBattlefieldRole(TMP_Dropdown BattlefieldRoleDropdown)
        {
            switch (BattlefieldRoleDropdown.value) 
            {
                case 0:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.HQ;
                    break;
                case 1:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.Troop;
                    break;
                case 2:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.Elite;
                    break;
                case 3:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.FastAttack;
                    break;
                case 4:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.Flyer;
                    break;
                case 5:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.HeavySupport;
                    break;
                case 6:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.Fortification;
                    break;
                case 7:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.DedicatedTransport;
                    break;
                case 8:
                    CurrentUnitData.UnitBattlefieldRole = BattlefieldRole.LordOfWar;
                    break;
            }
        }

        public void SetFactionName(string newName)
        {
            CurrentUnitData.CrusadeFaction = newName;
        }

        public void SetKeywords(string newKeywords)
        {
            CurrentUnitData.SelectableKeywords = newKeywords;
        }

        public void SetUnitType(string newType)
        {
            CurrentUnitData.UnitType = newType;
        }

        public void UpdatePowerLevel(int value)
        {
            CurrentUnitData.PowerRating += value;
            eventHandler.UpdatePowerLevel.Invoke(CurrentUnitData.PowerRating.ToString() + " PL");
            ForceScreen.CurrentCardUpdater.unitPL.text = CurrentUnitData.PowerRating.ToString() + " PL";
        }

        public void UpdateCrusadePoints(int value)
        {
            CurrentUnitData.CrusadePoints += value;
            ForceScreen.UpdateSupplyUsed(value);
            eventHandler.UpdateCrusadePoints.Invoke(CurrentUnitData.CrusadePoints.ToString() + " CP");
            ForceScreen.CurrentCardUpdater.unitCP.text = CurrentUnitData.CrusadePoints.ToString() + " CP";
        }

        public void NewEquipment()
        {
            if (CurrentUnitData.Equipment == null)
                CurrentUnitData.Equipment = new List<EquipmentData>();

            GameObject newEquip = CreateEquipmentCard();
            DataCarrier carrier = newEquip.GetComponent<DataCarrier>();
            carrier.UID = Random.Range(0, 10000000000).ToString();
            bool duplicate = CheckDuplicateEquipmentUID(carrier);

            while (duplicate)
            {
                carrier.UID = Random.Range(0, 10000000000).ToString();
                duplicate = CheckDuplicateEquipmentUID(carrier);
            }

            EquipmentData newEquipData = new EquipmentData();
            newEquipData.UID = carrier.UID;
            newEquipData.EquipmentName = "";
            newEquipData.Quantity = 0;
            carrier.UnitScreen = this;

            CurrentUnitData.Equipment.Add(newEquipData);
            EquipmentCards.Add(newEquip);

            EquipmentContent.sizeDelta = new Vector2(EquipmentContent.sizeDelta.x, 180 * CurrentUnitData.Equipment.Count);
        }

        public GameObject CreateEquipmentCard()
        {
            GameObject newEquip = Instantiate(PrefabEquipmentCard, EquipmentContentHome.transform);
            newEquip.transform.localPosition = new Vector3(0, -180 * EquipmentCards.Count);

            return newEquip;
        }

        private bool CheckDuplicateEquipmentUID(DataCarrier carrier)
        {
            foreach (EquipmentData equip in CurrentUnitData.Equipment)
            {
                if (equip.UID == carrier.UID)
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateEquipment(DataCarrier carrier)
        {
            foreach (EquipmentData equip in CurrentUnitData.Equipment) 
            {
                if (equip.UID == carrier.UID) 
                {
                    equip.EquipmentName = carrier.name.text;
                    equip.Quantity = int.Parse(carrier.quantity.text);
                }
            }
        }

        public void SetPsychicPowers(string newPowers)
        {
            CurrentUnitData.PsychicPowers = newPowers;
        }

        public void SetWarlordTraits(string newTraits)
        {
            CurrentUnitData.WarlordTraits = newTraits;
        }

        public void SetRelics(string newRelics)
        {
            CurrentUnitData.Relics = newRelics;
        }

        public void SetOtherUpgrades(string newOther)
        {
            CurrentUnitData.OtherAbilities = newOther;
        }
    }
}
