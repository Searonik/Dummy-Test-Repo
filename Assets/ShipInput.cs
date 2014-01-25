using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour {

	float inertia;
	// Use this for initialization
	void Start () {
		inertia = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(new Vector3(0, 0,  Time.deltaTime * -3f * (Mathf.PI * Input.GetAxis("Rudder"))));
		inertia = Mathf.Lerp(inertia, Input.GetAxis("Sails"), Time.deltaTime);
		transform.Rotate(Vector3.up * Input.GetAxis("Rudder"));
		transform.Translate(Vector3.forward * inertia * Time.deltaTime);
	}
}
