using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CrusadeTracker
{
    public class CardUpdater : MonoBehaviour
    {
        public ForceDataViewModel ForceScreen;
        public UnitTallyViewData TallyScreen;

        public TextMeshProUGUI unitName;
        public TextMeshProUGUI unitPL;
        public TextMeshProUGUI unitCP;

        public void OpenCardDetails() 
        {
            ForceScreen.OpenUnit(GetComponent<DataCarrier>());
        }

        public void OpenCardTallies()
        {
            ForceScreen.OpenUnitTallies(GetComponent<DataCarrier>());
        }
    }
}
