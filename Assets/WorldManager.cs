using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	float inertia;
	public GameObject ship;

	// Use this for initialization
	void Start () {
		inertia = 0;
	}
	
	// Update is called once per frame
	void Update () {

		inertia = Mathf.Lerp(inertia, Input.GetAxis("Sails"), Time.deltaTime);
		transform.Translate(ship.transform.right * (inertia * 10) * Time.deltaTime);


	}
}
