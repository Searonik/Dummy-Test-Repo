using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
	
	Vector2 resVector = Vector2.zero;
	Vector2 setRes;
	public float master = 1f;
	public float sound = 1f;
	public float music = 1f;
	public bool masterBool = true;
	public bool soundBool = true;
	public bool musicBool = true;
	GameObject optionsCamObj;
	GameObject mainCameraObj;	
	private bool controlConfig = false;
	private Rect windowRect = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
	//Assign a string for the names of the buttons that are configuable
	string [] buttonConfig = {"Rudder", "Sails", "Mouse Scroll", "Ready Port Cannons", 
		"Ready Stoarboard Cannons", "Ready Fore Cannons", "Ready Aft Cannons", 
		"Fire Cannons", "Launch Longboats", "Choose Target", "Menu", "Map", 
		"Inventory", "Assign Crew", "Enter Port"};
	int buttonInt = 0;


	//To be used on scene loading
	void awake () {
	
	}
	
	// Use this for initialization
	void Start () {
		optionsCamObj = GameObject.Find("Options Camera");
		optionsCamObj.GetComponent<AudioListener>().enabled = false;
		mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		sound = AudioListener.volume / master;
		music = mainCameraObj.GetComponent<AudioSource>().volume / master;
		masterBool = !mainCameraObj.GetComponent<AudioListener>().enabled;
		soundBool = AudioListener.pause;
		musicBool = mainCameraObj.GetComponent<AudioSource>().mute;

		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		
		//Grab accurate screen resolution before running.
		setRes.x = Screen.width;
		setRes.y = Screen.height;
		
		//Resolution choice box. need a lot of work
			GUI.Label(new Rect(Screen.width * .7f, Screen.height * .05f, Screen.width * .2f, Screen.height * .05f), "Resolution");
			
			resVector = GUI.BeginScrollView(new Rect(Screen.width * .6f, Screen.height * .11f, Screen.width * .2f, Screen.height * .15f) , resVector, new Rect(0, 0, Screen.width * .2f, Screen.width * .15f));
			if (GUI.Button(new Rect(0,0, Screen.width * .15f, Screen.height * .05f), "640x480")){
				setRes = new Vector2(640f, 480f);	
			}
			if (GUI.Button(new Rect(0, Screen.height * .05f, Screen.width * .15f, Screen.height * .05f), "800x600")){
				setRes = new Vector2(800f, 600f);
			}
			if (GUI.Button(new Rect(0, Screen.height * .1f, Screen.width * .15f, Screen.height * .05f), "1024x768")){
				setRes = new Vector2(1024f, 768f);
			}
			GUI.EndScrollView();
			
			//set resolution button
			if (GUI.Button(new Rect(Screen.width *.67f, Screen.height * .32f, Screen.width * .25f, Screen.height * .05f), "Apply Resolution")){
				Screen.SetResolution((int) setRes.x, (int) setRes.y, false);	
			}
			
			//Master Volume slider
			master = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .39f, Screen.width * .4f, Screen.height * .04f), master, 0f, 1f);
			//Display the slider as a Percent
			string masterString = (int)(master * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .39f, Screen.width * .1f, Screen.height * .5f),  masterString);
			//Master mute button
			masterBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .44f, Screen.width * .2f, Screen.height * .05f), masterBool, "Master Mute");
			
			
			
			//Sound Volume slider and toggle
			sound = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .49f, Screen.width * .4f, Screen.height * .04f), sound, 0f, 1f);
			//apply Sound sldier to volume, modified by the master volume.
			AudioListener.volume = sound * master;
			//Then, display it as a percent of the slider alone
			string soundString = (int)(sound * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .49f, Screen.width * .1f, Screen.height * .5f), soundString);
			//mute sound button, applied in conjunction with the master mute
			soundBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .54f, Screen.width * .2f, Screen.height * .05f), soundBool, "Sound Mute");
			AudioListener.pause = soundBool || masterBool;
			
			
			//Music Volume slider and toggle
			music = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .59f, Screen.width * .4f, Screen.height * .04f), music, 0f, 1f);
			//apply Music volume to the music source, modified by master Volume. 
			mainCameraObj.GetComponent<AudioSource>().volume = music * master;
			//Then display it as a percent of the slider alone
			string musicString = (int)(music * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .59f, Screen.width * .1f, Screen.height * .5f), musicString);
			//mute music button, applied in conjuntion with the master mute
			musicBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .64f, Screen.width * .2f, Screen.height * .05f), musicBool, "Music Mute");
			mainCameraObj.GetComponent<AudioSource>().mute = musicBool || masterBool;

			//Back to Main Menu button
			if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .85f, Screen.width * .2f, Screen.height * .05f), "Back to Menu")){
				GameObject optionsCamObj = GameObject.Find("Options Camera");
				optionsCamObj.SetActive(false);
			}

			/*****
			 * Aborted contols configuation attempt. May return if we develop our own input management. 
			 * Hooks into the GUI via a GUI window.

			//Controls configuration button.
			if (GUI.Button(new Rect(Screen.width * .65f, Screen.height * .7f, Screen.width * .3f, Screen.height * .05f), "Controls configuration")){
				controlConfig = !controlConfig;
			}
			

		
			//Controls configuration - lets players set the controls
			if (controlConfig){
				windowRect = GUI.Window(0, windowRect, controlsConfigWindow, "Controls Configuration");
			}*/
			
	}


	/*	aborted Configuration controls menu
		void controlsConfigWindow(int winID){
		buttonInt = GUI.SelectionGrid(new Rect(windowRect.width * .25f, windowRect.height * .05f, windowRect.width * .25f, windowRect.height * .9f), buttonInt, buttonConfig, 1);
		GUI.Label(new Rect(windowRect.width * .55f, windowRect.height * .05f, windowRect.width * .25f, windowRect.height *.05), "Rudder");
	}*/
	
}
