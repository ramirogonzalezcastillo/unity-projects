using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private float batTime = 1f;
    private float batRepeatRate = 1f;
    private Light flashLight;
    void Start()
    {
        flashLight = GetComponent<Light>();
        InvokeRepeating("Battery", batTime, batRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Battery()
    {
        flashLight.intensity--;
        if (flashLight.intensity == 0)
        {
            CancelInvoke("Battery");
        }
    }
}
