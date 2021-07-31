using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    float rx, ry;
    public float rotSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        //rx = transform.eulerAngles.x;
        //ry = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseH = Input.GetAxis("Mouse X");
        float mouseV = Input.GetAxis("Mouse Y");
        rx += mouseV * rotSpeed * Time.deltaTime;
        ry += mouseH * rotSpeed * Time.deltaTime;
        rx = Mathf.Clamp(rx, -90, 90);
        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }
}
