using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScreenRate : MonoBehaviour
{
    public int targetFrameRate = 30;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
