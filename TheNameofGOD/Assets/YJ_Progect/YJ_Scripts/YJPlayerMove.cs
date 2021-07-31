using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJPlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

    }

    internal void DamageAction(int attackPower)
    {
        throw new NotImplementedException();
    }
}
