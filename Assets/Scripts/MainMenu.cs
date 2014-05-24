using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject optionsCamObj;
	public GameObject playerShipObj;

	// Button rectangle variables - right side
	private const float LEFT_ALIGN = Screen.width * .75f;
	private const float BUTTON_WIDTH = Screen.width * .2f;
	private const float TOP_ALIGN = Screen.height * .05f;
	private const float BUTTON_HEIGHT = Screen.height * .07f;
	private const float BUTTON_VERTICAL_OFFSET = Screen.height * .11f;
	private int buttonNo = 0;
	
	void awake(){
		optionsCamObj.SetActive(false);
		playerShipObj.SetActive(false);
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
		if(GUI.Button(GenerateNextLeftAlignedRectangle(), "Continue game")){
			Debug.Log("Continue");
		}
		if(GUI.Button(GenerateNextLeftAlignedRectangle(), "New game")){
			Debug.Log("New game");
			// Instant swap to player camera For testing player movement
			playerShipObj.SetActive(true);
			optionsCamObj.SetActive (false);
			GameObject.Find("Main Camera").SetActive(false);
			//optionsCamObj.camera.enabled = false;
			Debug.Log ("Done");
			
		}
		if(GUI.Button(GenerateNextLeftAlignedRectangle(), "Load game")){
			Debug.Log("Load game");
		}
		if(GUI.Button(GenerateNextLeftAlignedRectangle(), "Options")){
			Debug.Log("Options");
			//optionsCamObj = GameObject.Find("Options Camera");
			optionsCamObj.SetActive(!optionsCamObj.activeSelf);
			//optionsCam.GetComponent<Camera>().enabled = true;
			//options = !options;
		}
		if(GUI.Button(GenerateNextLeftAlignedRectangle(), "About us")){
			Debug.Log("About us");
		}
		if(GUI.Button(GenerateNextLeftAlignedRectangle(), "Exit game")){
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

	private Rect GenerateNextLeftAlignedRectangle() {
		return new Rect(LEFT_ALIGN,
		                TOP_ALIGN + (buttonNo++ * BUTTON_VERTICAL_OFFSET),
		                BUTTON_WIDTH,
		                BUTTON_HEIGHT);
	}
	

}
