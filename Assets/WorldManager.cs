using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	float inertia;
	public GameObject ship;
	public LocationManager[] LocationManager;


	void Awake (){
		LocationManager = gameObject.GetComponentsInChildren<LocationManager>(true);

		LocationManager[] North = new LocationManager[4];	//highest Z array
		LocationManager[] South = new LocationManager[4];	//lowest Z array
		LocationManager[] East = new LocationManager[4];	//Highest X array
		LocationManager[] West = new LocationManager[4];	//Lowest X array

		foreach (LocationManager cube in LocationManager){
			for (int i = 0; i < 4; i++){
				// Now to sort our cubes to find what our edge cubes are. 4 cubes, the corner 4, will be on 2 edges.
				// if the spot is empty, or if the spot has a smaller z value, put this in the position
				if (North[i] == null || North[i].transform.position.z < cube.transform.position.z){
					North[i] = cube;
					break;
				}
				// if the spot contains a more desired (highest here) Z value, chuck it - we know it doesn't belong
				else if  (North[i].transform.position.z > cube.transform.position.z){
					break;
				}
				// repeat for each array. this is the southern edge, lowest z
			}
			for (int i = 0; i < 4; i++){
				if (South[i] == null || South[i].transform.position.z > cube.transform.position.z){
					South[i] = cube;
					break;
				}
				else if  (South[i].transform.position.z < cube.transform.position.z){
					break;
				}
			}
			for (int i = 0; i < 4; i++){
				// now we check for the extremes in X
				if (East[i] == null || East[i].transform.position.x < cube.transform.position.x){
					East[i] = cube;
					break;
				}
				else if  (East[i].transform.position.x > cube.transform.position.x){
					break;
				}
			}
			for (int i = 0; i < 4; i++){
				// and now, we seek lowest X value
				if (West[i] == null || West[i].transform.position.x > cube.transform.position.x){
					West[i] = cube;
					break;
				}
				else if  (West[i].transform.position.x < cube.transform.position.x){
					break;
				}
			}
		}
		for(int i = 0; i < 4; i++){
			North[i].North = true;
			South[i].South = true;
			East[i].East = true;
			West[i].West = true;
		}
	}
	// Use this for initialization
	void Start () {
		inertia = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/* Make use of the rigidbody to keep the ship moving.
		 */
		//ship.rigidbody.AddForce(ship.transform.forward * (Input.GetAxis("Sails") * 1000f )* Time.deltaTime);
		// fuck physics, not working. going back to transform for now.
		inertia = Mathf.Lerp(inertia, Input.GetAxis("Sails"), Time.deltaTime);
		ship.transform.Translate(Vector3.left * (inertia * 30) * Time.deltaTime);

	}

	public void RelocateTerrain(string s){
		LocationManager[] NewEdge = new LocationManager[4];
		if (s == "North"){
			foreach (LocationManager Loc in LocationManager){
				// this cube is no longer the northern edge if it just was
				if (Loc.North){
					Loc.North = false;
				}
				// this cube is the new north edge - mode and flag it
				else if (Loc.South){
					Loc.transform.Translate(0,0,Loc.transform.localScale.z * 4);
					Loc.South = false;
					Loc.North = true;
				}
				// find the new south edges
			}
			foreach (LocationManager Loc in LocationManager){
				for (int i = 0; i < 4; i++){
				// We're already north, we can't be south!
					if (Loc.North){
						break;
					}
					else if (NewEdge[i] == null || NewEdge[i].transform.position.z > Loc.transform.position.z){
						NewEdge[i] = Loc;
						break;
					}
					else if  (NewEdge[i].transform.position.z < Loc.transform.position.z){
						break;
					}
				}
				// flag the new north edge
			}
			for (int i = 0; i < 4; i++){
				NewEdge[i].South = true;
			}
		}
		if (s == "South"){
				foreach (LocationManager Loc in LocationManager){
				// this cube is no longer a southern edge, if it was before
				if (Loc.South){
					Loc.South = false;
				}
				// this cube is now the southern edge, so move it and mark it
				else if (Loc.North){
					Loc.transform.Translate(0, 0, -1f * Loc.transform.localScale.z * 4);
					Loc.North = false;
					Loc.South = true;
				}
				}
				foreach (LocationManager Loc in LocationManager){
					// fine the new north edges
					for (int i = 0; i < 4; i++){
						// We're already south, we can't be north!
						if (Loc.South){
							break;
						}
						else if (NewEdge[i] == null || NewEdge[i].transform.position.z < Loc.transform.position.z){
							NewEdge[i] = Loc;
							break;
						}
						else if  (NewEdge[i].transform.position.z > Loc.transform.position.z){
							break;
						}
					}
				}
				// set the new north edges, now that they are sorted.
				for (int i = 0; i < 4; i++){
					NewEdge[i].North = true;
				}

		}
		if (s == "East"){
			foreach (LocationManager Loc in LocationManager){
				// this is no longer the east edge
				if (Loc.East){
					Loc.East = false;
				}
				// this is the new east edge, move and flag it
				else if (Loc.West){
					Loc.transform.Translate(Loc.transform.localScale.x * 4, 0, 0);
					Loc.West = false;
					Loc.East = true;
				}
			}
			foreach (LocationManager Loc in LocationManager){
				// find the new west edge
				for (int i = 0; i < 4; i++){
					// We're already East, we can't be west! 
					if (Loc.East){
						break;
					}
					if (NewEdge[i] == null || NewEdge[i].transform.position.x > Loc.transform.position.x){
						NewEdge[i] = Loc;
						break;
					}
					else if  (NewEdge[i].transform.position.x < Loc.transform.position.x){
						break;
					}
				}
			}
			// flag the new west edge
			for (int i = 0; i < 4; i++){
				NewEdge[i].West = true;
			}
		}
		if (s == "West"){
				foreach (LocationManager Loc in LocationManager){
					// this is no longer the west edge.
					if (Loc.West){
						Loc.West = false;
					}
					// this is the new west edge. move and flag it.
					else if (Loc.East){
						Loc.transform.Translate(-1f * Loc.transform.localScale.x * 4, 0, 0);
						Loc.East = false;
						Loc.West = true;
					}
				}
				foreach (LocationManager Loc in LocationManager){
					// find the new east edge
					for (int i = 0; i < 4; i++){
						// We're west, we can't be east!
						if (Loc.West){
							break;
						}
						// now we check for the extremes in X
						if (NewEdge[i] == null || NewEdge[i].transform.position.x < Loc.transform.position.x){
							NewEdge[i] = Loc;
							break;
						}
						else if  (NewEdge[i].transform.position.x > Loc.transform.position.x){
							break;
						}
					}
				}
				// flag the new East edge
				for (int i = 0; i < 4; i++){
					NewEdge[i].East = true;
				}
			}
	}
}
