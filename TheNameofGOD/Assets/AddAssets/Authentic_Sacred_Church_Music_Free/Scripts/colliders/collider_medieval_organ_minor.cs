﻿using UnityEngine;
using System.Collections;

public class collider_medieval_organ_minor : MonoBehaviour {

	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Medieval_Organ_Minor_OnClick ();
	}
}
