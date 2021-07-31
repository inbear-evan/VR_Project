using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_PlayerMove : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // 앞뒤좌우 방향을 만들고
        Vector3 direction = new Vector3(h, 0, v);
        // 내가 바라보고 있는 앞이 진짜 앞방향이 되게 하고싶다.
        direction = Camera.main.transform.TransformDirection(direction);
        // direction의 크기를 1로 만들고싶다.(Normalize)
        direction.Normalize();
        cc.Move(speed*direction * Time.deltaTime);
    }
}
