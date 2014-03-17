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
		/*Since the Sails axis represents the Sails on the ship, 
		 * We calculate the speed of the ship via the use or Math.Lerp,
		 * And then we move it at it's current speed.
		 */
		inertia = Mathf.Lerp(inertia, Input.GetAxis("Sails"), Time.deltaTime);
		transform.Translate(ship.transform.right * (inertia * 10) * Time.deltaTime);


	}
}
