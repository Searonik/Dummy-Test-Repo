using UnityEngine;
using System.Collections;

public class DialougeDisplay : MonoBehaviour {

	public string dialogue;
	private bool display;
	public Texture2D background;
	public Texture2D portrait;


	// Use this for initialization
	void Start () {
		display = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Temporary invocation for the dialouge. Hit "Tab" to open and close
		if (Input.GetButtonDown("Target") && !display){
			startText(dialogue);
		}
		else if (Input.GetButtonDown("Target") && display){
			closeText();
		}
	}

	void OnGUI () {
		if (display){
			/*	Prototype Display box. Frist draws a background.
			 * Then, it draws the placeholder portriat for who is talking
			 * Finally, it shows the display text. 
			 * since it is public, it can be edited via the inspector
			 */

			GUI.Label(new Rect (Screen.width * .05f, Screen.height * .65f, Screen.width * .9f, Screen.height * .25f), background);
			GUI.Label(new Rect (Screen.width * .075f, Screen.height * .675f, Screen.width * .2f, Screen.height * .2f), portrait);
			GUI.Label(new Rect (Screen.width * .3f, Screen.height * .7f, Screen.width * .65f, Screen.height * .25f), dialogue);

		}
	}

	// Function to invoking the display - ideally, in the future, you'll
	// send it the dialouge you want
	public void startText(string s){
		dialogue = s;
		display = true;
	}

	// method for closing the dialogue box
	public void closeText(){
		display = false;
	}
}
