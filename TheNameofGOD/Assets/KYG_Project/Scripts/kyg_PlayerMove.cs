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
        // �յ��¿� ������ �����
        Vector3 direction = new Vector3(h, 0, v);
        // ���� �ٶ󺸰� �ִ� ���� ��¥ �չ����� �ǰ� �ϰ�ʹ�.
        direction = Camera.main.transform.TransformDirection(direction);
        // direction�� ũ�⸦ 1�� �����ʹ�.(Normalize)
        direction.Normalize();
        cc.Move(speed*direction * Time.deltaTime);
    }
}
