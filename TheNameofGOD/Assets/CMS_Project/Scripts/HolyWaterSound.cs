using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterSound : MonoBehaviour
{
    public static HolyWaterSound instance;
    
    private void Awake()
    {
        instance = this;
    }

    public AudioSource sound;
    public bool soundPlayCheck = false;
    // Update is called once per frame
    void Update()
    {
        if (soundPlayCheck)
        {
            sound.Play();
            soundPlayCheck = false;
        }
    }
}
