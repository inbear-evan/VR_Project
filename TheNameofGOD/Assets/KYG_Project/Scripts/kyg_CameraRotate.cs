using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스를 회전하면 카메라를 회전하고 싶다.
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
        // 사용자가 마우스를 회전하면
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        rx += my * rotSpeed * Time.deltaTime;
        ry += mx * rotSpeed * Time.deltaTime;

        // rx의 회전값을 제한하고싶다.
        rx = Mathf.Clamp(rx, -90, 90);

        // 카메라를 회전하고 싶다.
        transform.eulerAngles = new Vector3(-rx, ry, 0);

        float t = ac.Evaluate(Time.time * 0.5f) - 0.5f;
        transform.localPosition = Vector3.up * t * 0.05f;
    }
    public static float Clamp(float value, float min, float max)
    {
        // 만약 value가 min 보다 작다면 min을 반환하고싶다.
        if (value < min)
        {
            return min;
        }
        // 만약 value가 max 보다 크다면 max를 반환하고싶다.
        if (value > max)
        {
            return max;
        }
        // value를 반환하고싶다.
        return value;
    }

}