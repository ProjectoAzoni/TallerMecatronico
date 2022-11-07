using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandeler : MonoBehaviour
{
    SettingsManager sm;
    
    void Start()
    {
        sm = FindObjectOfType<SettingsManager>(true);
        sm.SetStartData();
    }

}
