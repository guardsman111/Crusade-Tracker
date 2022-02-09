using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CrusadeTracker
{
    public class LoadCardButton : MonoBehaviour
    {
        public MainMenuWindow MainMenu;

        public TextMeshProUGUI label;

        public void LoadCard() 
        {
            MainMenu.OpenForce(this.gameObject);
        }
    } 
}
