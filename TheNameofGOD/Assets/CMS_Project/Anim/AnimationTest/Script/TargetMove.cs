using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float speed = 5f;
    public float minusDistance = -7;
    public float plusDistance = 7;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(direction, 0, 0);
        if (transform.position.x <= minusDistance) direction = 1;
        else if (transform.position.x >= plusDistance) direction = -1;
        transform.position += dir * speed * Time.deltaTime;
    }
}
