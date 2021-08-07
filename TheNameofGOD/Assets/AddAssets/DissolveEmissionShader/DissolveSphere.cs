using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour
{

    Material mat;
    float nums = 0;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        nums += Time.deltaTime;
        //mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
        mat.SetFloat("_DissolveAmount", nums);
        //print(Mathf.Sin(Time.time) / 2 + 0.5f);
    }
}