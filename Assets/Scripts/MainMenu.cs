using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject optionsCamObj;
	public GameObject playerShipObj;
	private Rect continueGame;
	private Rect newGame;
	private Rect loadGame;
	private Rect options;
	private Rect about;
	private Rect quit;

	void awake(){
		optionsCamObj.SetActive(false);
		playerShipObj.SetActive(false);
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		continueGame = new Rect(Screen.width * .75f, Screen.height * .05f, Screen.width * .2f, Screen.height * .07f);
		newGame = new Rect(Screen.width * .75f, Screen.height * .16f, Screen.width * .2f, Screen.height * .07f);
		loadGame = new Rect(Screen.width * .75f, Screen.height * .27f, Screen.width * .2f, Screen.height * .07f);
		options = new Rect(Screen.width * .75f, Screen.height * .38f, Screen.width * .2f, Screen.height * .07f);
		about = new Rect(Screen.width * .75f, Screen.height * .49f, Screen.width * .2f, Screen.height * .07f);
		quit = new Rect(Screen.width * .75f, Screen.height * .6f, Screen.width * .2f, Screen.height * .07f);
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
		if(GUI.Button(continueGame, "Continue game")){
			Debug.Log("Continue");
		}
		if(GUI.Button(newGame, "New game")){
			Debug.Log("New game ");
			// Instant swap to player camera For testing player movement
			playerShipObj.SetActive(true);
			optionsCamObj.SetActive (false);
			GameObject.Find("Main Camera").SetActive(false);
			//optionsCamObj.camera.enabled = false;
			Debug.Log ("Done");
			
		}
		if(GUI.Button(loadGame, "Load game")){
			Debug.Log("Load game");
		}
		if(GUI.Button(options, "Options")){
			Debug.Log("Options");
			//optionsCamObj = GameObject.Find("Options Camera");
			optionsCamObj.SetActive(!optionsCamObj.activeSelf);
			//optionsCam.GetComponent<Camera>().enabled = true;
			//options = !options;
		}
		if(GUI.Button(about, "About us")){
			Debug.Log("About us");
		}
		if(GUI.Button(quit, "Exit game")){
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
