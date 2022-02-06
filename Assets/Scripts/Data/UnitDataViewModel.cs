using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CrusadeTracker
{
    public class UnitDataViewModel : MonoBehaviour
    {
        public UnitDataEventHandler eventHandler;

        public UnitDataClass CurrentUnitData;
        private Dictionary<string, UnitDataClass> UnitCards; // int GUI links to the UnitDataClass

        public GameObject EquipmentContentHome;
        public GameObject PrefabEquipmentCard;

        public void Start()
        {
            NewUnit();
        }

        public void NewUnit()
        {
            CurrentUnitData = new UnitDataClass();
        }

        public void SetUnitName(string newName)
        {
            CurrentUnitData.UnitName = newName;
        }

        public void SetBattlefieldRole(Dropdown BattlefieldRoleDropdown)
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
            CurrentUnitData.UnitName = newType;
        }
        public void NewEquipment()
        {
            if (CurrentUnitData.Equipment == null)
                CurrentUnitData.Equipment = new List<EquipmentData>();
            GameObject newEquip = Instantiate(PrefabEquipmentCard, EquipmentContentHome.transform);
            newEquip.transform.localPosition = new Vector3(0, -180 * CurrentUnitData.Equipment.Count);
            DataCarrier carrier = newEquip.GetComponent<DataCarrier>();
            carrier.UID = Random.Range(0, 10000000000).ToString();
            bool duplicate = CheckDuplicateEquipmentUID(carrier);

            RectTransform EquipmentContent = EquipmentContentHome.transform.parent.GetComponent<RectTransform>();

            while (duplicate)
            {
                carrier.UID = Random.Range(0, 10000000000).ToString();
                duplicate = CheckDuplicateEquipmentUID(carrier);
            }

            EquipmentData newEquipData = new EquipmentData();
            newEquipData.UID = carrier.UID;
            newEquipData.EquipmentName = "";
            newEquipData.Quantity = 0;

            CurrentUnitData.Equipment.Add(newEquipData);

            EquipmentContent.sizeDelta = new Vector2(EquipmentContent.sizeDelta.x, 180 * CurrentUnitData.Equipment.Count);
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
