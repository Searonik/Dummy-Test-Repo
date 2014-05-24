using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour {


	public GameObject mainCameraObj;
	public Rigidbody CannonBall;
	Transform FireFrom;
	private float reload = 2f;

	void awake(){

	}

	// Use this for initialization
	void Start () {
		FireFrom = GameObject.Find("ForeCannons").transform;
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
		if (Input.GetButtonDown("Menu")){
			mainCameraObj.SetActive(true);
			this.gameObject.SetActive(false);
		}
		reload -= Time.deltaTime;
		if (Input.GetButton("Fire") && reload <= 0){
			reload = 2f;
			Rigidbody Attack;
			Attack  = Instantiate(CannonBall, FireFrom.position, FireFrom.rotation) as Rigidbody;
			Attack.gameObject.SetActive(true);
			Attack.AddForce(FireFrom.forward * 10000);

		}
	}

	private void OnCollisionEnter(Collision thing){
		AttackControl incoming = thing.gameObject.GetComponent<AttackControl>();
		if (incoming != null){
			SendMessageUpwards("takeDamage", incoming);
			Destroy(incoming.gameObject);
		}
	}
}
