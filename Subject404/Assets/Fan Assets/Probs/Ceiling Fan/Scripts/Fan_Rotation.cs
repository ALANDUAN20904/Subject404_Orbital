using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Fan_Rotation : MonoBehaviour {
void Start()
	{

	}


	
void Update () {
		
		//rotation around y, changable speed, spinned normalised based on rendering speed

		transform.Rotate(0f,100*Time.deltaTime,0f, Space.Self); 
	}
}
