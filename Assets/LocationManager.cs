using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour {

	public GameObject ship;
	bool Visible = true;

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update () {
	
		if (ship.activeSelf){
			if (Visible && BeyondDistance(ship)){
				Visible = false;
				this.renderer.enabled = false;
				this.collider.enabled = false;
			}
			else if (!Visible && !BeyondDistance(ship)){
				Visible = true;
				this.renderer.enabled = true;
				this.collider.enabled = true;
			}
		}

	}

	private bool BeyondDistance(GameObject thing){
		/* This is the pythagorean theroem. 
		 * Position is thankfully the center, so we just crunch.
		 * Also, to save on math processing, we compare vs distance squared.
		 */

		if ((Mathf.Pow((thing.transform.position.x - this.transform.position.x), 2f) + Mathf.Pow((thing.transform.position.z - this.transform.position.z), 2f)) > 250000){
				return true;
		}
		else{
				return false;
		}
	}
}
