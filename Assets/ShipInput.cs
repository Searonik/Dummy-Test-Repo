using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour {


	public GameObject mainCameraObj;

	void awake(){
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// Makes the ship turn based on the "Rudder" Axis
		transform.Rotate(Vector3.up * Input.GetAxis("Rudder"));

		//transform.rotation = (Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.up), Time.deltaTime));
			/*physics don't work doing something wrong.
		rigidbody.AddTorque(Vector3.left * Input.GetAxis("Rudder") * 20f);
		rigidbody.AddTorque(Vector3.up * 100f);
			*/
		// Return to main menu upon hitting menu button - a temporary method
		if (Input.GetButton("Menu")){
			mainCameraObj.SetActive(true);
			GameObject.Find ("galleon").SetActive(false);
		}


	}
}
