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
		//transform.Rotate(new Vector3(0, 0,  Time.deltaTime * -3f * (Mathf.PI * Input.GetAxis("Rudder"))));
		transform.Rotate(Vector3.up * Input.GetAxis("Rudder") * .2f);
		if (Input.GetButton("Menu")){
			mainCameraObj.SetActive(true);
			GameObject.Find ("galleon").SetActive(false);
		}


	}
}
