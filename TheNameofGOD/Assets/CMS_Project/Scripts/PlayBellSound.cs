using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBellSound : MonoBehaviour
{
    AudioSource sound;
    bool chk = false;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (!chk)
            {
                sound.Play();
                chk = true;
            }
        }

        if(chk && !sound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
