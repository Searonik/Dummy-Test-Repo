using UnityEngine;
using System.Collections;

public class AIControl : MonoBehaviour {

	private Transform target;
	private Transform myTransform;

	public GameObject player;
	public int dropAgroDistance = 500;
	public int gainAgroDistance = 200;
	public float forwardSpeed = 8;
	public float turnRate = 2;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			if (Distance (target, myTransform) > dropAgroDistance) {
				Debug.Log("Target lost!");
				target = null;
			}
			else {
				// Chase!

				// Slerp rotates a Quaternion a certain amount towards the desired angle
				myTransform.rotation = Quaternion.Slerp(
					myTransform.rotation,
					Quaternion.LookRotation(myTransform.position - target.position),
					turnRate * Time.deltaTime
				);

				myTransform.position -= myTransform.forward * forwardSpeed * Time.deltaTime;
			}
		}
		else {
			if (player.activeInHierarchy && Distance (player.transform, myTransform) < gainAgroDistance) {
				Debug.Log("Target acquired!");
				target = player.transform;
			}
			else {
				// Wander
			}
		}
	}

	private double Distance (Transform t1, Transform t2) {
		return Vector3.Distance(t1.position, t2.position);
	}

	private void OnCollisionEnter(Collision thing){
		AttackControl incoming = thing.gameObject.GetComponent<AttackControl>();
		if (incoming != null){
			SendMessageUpwards("takeDamage", incoming);
			Destroy(incoming.gameObject);
		}
	}
}
