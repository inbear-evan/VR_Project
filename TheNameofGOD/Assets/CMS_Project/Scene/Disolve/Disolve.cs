using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolve : MonoBehaviour
{
    public Material disolveMaterial;
    public float speed, max;
    float currentY, startTime;
    public bool UpOrDown = false; // false : Up2Down || true : Down2Up
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (UpOrDown)
        {
            if (currentY < max)
            {
                disolveMaterial.SetFloat("_DisolveY", currentY);
                currentY += Time.deltaTime * speed;
            }
        }
        else
        {
            if (currentY > max)
            {
                disolveMaterial.SetFloat("_DisolveY", currentY);
                currentY -= Time.deltaTime * speed;
            }
        }

        //if (Input.GetKeyDown(KeyCode.E))
        //    TriggerEffect();
    }

    void TriggerEffect()
    {
        startTime = Time.time;
        currentY = 0;
    }
}
