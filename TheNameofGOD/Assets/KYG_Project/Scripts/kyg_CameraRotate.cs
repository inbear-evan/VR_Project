using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ���콺�� ȸ���ϸ� ī�޶� ȸ���ϰ� �ʹ�.
public class kyg_CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    float rx, ry;
    public float rotSpeed = 200;
    public AnimationCurve ac;
    void Update()
    {
        // ����ڰ� ���콺�� ȸ���ϸ�
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        rx += my * rotSpeed * Time.deltaTime;
        ry += mx * rotSpeed * Time.deltaTime;

        // rx�� ȸ������ �����ϰ�ʹ�.
        rx = Mathf.Clamp(rx, -90, 90);

        // ī�޶� ȸ���ϰ� �ʹ�.
        transform.eulerAngles = new Vector3(-rx, ry, 0);

        float t = ac.Evaluate(Time.time * 0.5f) - 0.5f;
        transform.localPosition = Vector3.up * t * 0.05f;
    }
    public static float Clamp(float value, float min, float max)
    {
        // ���� value�� min ���� �۴ٸ� min�� ��ȯ�ϰ�ʹ�.
        if (value < min)
        {
            return min;
        }
        // ���� value�� max ���� ũ�ٸ� max�� ��ȯ�ϰ�ʹ�.
        if (value > max)
        {
            return max;
        }
        // value�� ��ȯ�ϰ�ʹ�.
        return value;
    }

}