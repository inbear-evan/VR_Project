using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMDRotate : MonoBehaviour
{
    public GameObject cam;
    public Transform body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    int prevAngle;
    // Update is called once per frame
    void Update()
    {
        //print("LocalRotation : " + cam.transform.localRotation.y);
        //print("Rotation : " + cam.transform.rotation.y);
        //print("eulerAngles   : " + (-360.0f + cam.transform.eulerAngles.y));
        float angle = (-360.0f + cam.transform.eulerAngles.y);

        body.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
    }
}
