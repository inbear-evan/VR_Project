using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJPlayer : MonoBehaviour
{

    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(-90, 0, 0);
       
        cc.gameObject.transform.eulerAngles = dir;
    }
}
