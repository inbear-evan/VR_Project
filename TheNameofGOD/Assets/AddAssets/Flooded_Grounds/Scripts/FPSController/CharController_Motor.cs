using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour {

	public float speed = 10.0f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	public GameObject cam;
	
	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;


	void Start(){
		//LockCursor ();
		character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}
	}


	void CheckForWaterHeight(){
		//if (transform.position.y < WaterHeight) {
		//	gravity = 0f;			
		//} else {
			gravity = -9.8f;
		//}
	}



	void Update(){
        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        //rotX = Input.GetAxis("Mouse X") * sensitivity;
        //rotY = Input.GetAxis("Mouse Y") * sensitivity;

        //rotX = cam.transform.rotation.x * sensitivity;
        //rotY = cam.transform.rotation.y * sensitivity;
        CheckForWaterHeight();

        //Vector3 movement = new Vector3 (moveFB, gravity, moveLR);

        //if (webGLRightClickRotation)
        //{
        //    if (Input.GetKey(KeyCode.Mouse0))
        //    {
        //        CameraRotation(cam, rotX, rotY);
        //    }
        //}
        //else if (!webGLRightClickRotation)
        //{
        //    CameraRotation(cam, rotX, rotY);
        //}

        //CameraRotation(cam, rotX, -rotY);
        //movement = cam.transform.rotation * movement;
        //character.Move (movement * Time.deltaTime);

        Vector3 dir = new Vector3(moveFB, 0, moveLR);
        //Vector3 dir = new Vector3(moveLR, 0, moveFB);

        dir = cam.transform.TransformDirection(dir);
		dir.y = 0;
		character.Move(dir * Time.deltaTime);
	}
	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}




}
