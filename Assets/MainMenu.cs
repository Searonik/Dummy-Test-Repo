using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject optionsCamObj;
	
	void awake(){
		optionsCamObj = GameObject.Find("Options Camera");
		optionsCamObj.SetActive(false);
		GameObject.Find("MainCamera").GetComponent<AudioSource>().ignoreListenerVolume = true;
		GameObject.Find("MainCamera").GetComponent<AudioSource>().ignoreListenerPause = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnGUI(){
	
		/*
		 * Menu buttons for each menu option. 
		 * Each value is currently scaled against the screen size for convience.
		 * Feel free to change this
		 * The options menu is invoked via the "options" boolean, see Options if block for details
		 * 
		 * */
		//if (!options){
		if(GUI.Button(new Rect(Screen.width * .75f, Screen.height * .05f, Screen.width * .2f, Screen.height * .07f), "Continue game")){
			Debug.Log("Continue");
		}
		if(GUI.Button(new Rect(Screen.width * .75f, Screen.height * .16f, Screen.width * .2f, Screen.height * .07f), "New game")){
			Debug.Log("New game");
			// Instant swap to player camera For testing player movement
			GameObject.Find("PlayerCamera").camera.enabled = true;
			GameObject.Find("Main Camera").camera.enabled = false;
			GameObject.Find ("Main Camera").SetActive (false);
			GameObject.Find ("PlayerCamera").SetActive (true);
			optionsCamObj.SetActive (false);
			optionsCamObj.camera.enabled = false;
			Debug.Log ("Done");
			
		}
		if(GUI.Button(new Rect(Screen.width * .75f, Screen.height * .27f, Screen.width * .2f, Screen.height * .07f), "Load game")){
			Debug.Log("Load game");
		}
		if(GUI.Button(new Rect(Screen.width * .75f, Screen.height * .38f, Screen.width * .2f, Screen.height * .07f), "Options")){
			Debug.Log("Options");
			//optionsCamObj = GameObject.Find("Options Camera");
			optionsCamObj.SetActive(!optionsCamObj.activeSelf);
			//optionsCam.GetComponent<Camera>().enabled = true;
			//options = !options;
		}
		if(GUI.Button(new Rect(Screen.width * .75f, Screen.height * .49f, Screen.width * .2f, Screen.height * .07f), "About us")){
			Debug.Log("About us");
		}
		if(GUI.Button(new Rect(Screen.width * .75f, Screen.height * .6f, Screen.width * .2f, Screen.height * .07f), "Exit game")){
			Debug.Log("exit");
			Application.Quit();
		}
		
		//}
		/*
		 * Ugly code, but it looks decent for now
		 * 
		 * All rects take float arguments, so all the numbers are converted via multiplcation
		 * with a float value, so sake of inline conversion
		 * 
		 * The Resolution function is not there for now. Button and label exist as placeholders
		 * 
		 * The values of the sliders for the MAster sound, music, and sound effects are converted 
		 * to strings, and then trunctaed if more than 3 digits past the decimal, then displayed in-line witht he slider
		 * 
		 * Control Configuration is blank for now, button exists
		 * 
		 * Yes, I know the starting locations are a mess, This is a rough display.
		 * 
		 * */
		//if (options){
			
			
		//}
	}
	

}
