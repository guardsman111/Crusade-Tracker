using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CrusadeTracker {

    /// <summary>
    /// A class that can carry mutliple types of data
    /// </summary>
    public class DataCarrier : MonoBehaviour
    {
        public TMP_InputField name;
        public TMP_InputField quantity;
        public string UID;
        public GameObject GO;
    }
}
