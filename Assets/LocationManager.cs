using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour {

	public GameObject ship;
	private bool Visible = true;
	public bool North;
	public bool South;
	public bool East;
	public bool West;

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update () {
		/* old code. Clean up from final version : function was to disable distant portions of the terrain; for now, other methods have been used.
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
		*/
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

	void OnCollisionEnter(Collision coll){
		Debug.Log("Collision!" + North.ToString() + South.ToString() + East.ToString() + West.ToString());
		if (coll.collider.Equals(ship.collider)){
			if (North){
				SendMessageUpwards("RelocateTerrain", "North");
			}
			if (South){
				SendMessageUpwards("RelocateTerrain", "South");
			}
			if (East){
				SendMessageUpwards("RelocateTerrain", "East");
			}
			if (West){
				SendMessageUpwards("RelocateTerrain", "West");
			}

		}
	}

}
