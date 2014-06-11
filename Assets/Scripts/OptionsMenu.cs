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

	Rect resolutionLabel;
	Rect resolutionWindow;
	Rect resolutionVeiw;
	Rect resolutionApply;
	Rect masterVolume;
	Rect masterVolumeDisplay;
	Rect masterVolumeMute;
	Rect soundVolume;
	Rect soundVolumeDisplay;
	Rect soundVolumeMute;
	Rect musicVolume;
	Rect musicVolumeDisplay;
	Rect musicVolumeMute;
	Rect returnToMainMenu;
	//To be used on scene loading
	void awake () {
	
	}
	
	// Use this for initialization
	void Start () {
		/* This seciton here sets up camera data
		 * Current methods find both the main camera, and the obejcts object itself
		 * The options object was once a camera, but this has changed.
		 * it also determines the proper slider values based on volume and itnern data levels
		 * See below for more into about each value
		 */
		optionsCamObj = GameObject.Find("Options Object");
		mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		sound = AudioListener.volume / master;
		music = mainCameraObj.GetComponent<AudioSource>().volume / master;
		masterBool = !mainCameraObj.GetComponent<AudioListener>().enabled;
		soundBool = AudioListener.pause;
		musicBool = mainCameraObj.GetComponent<AudioSource>().mute;

		
		
	}
	
	// Update is called once per frame
	void Update () {
		resolutionLabel = new Rect(Screen.width * .7f, Screen.height * .05f, Screen.width * .2f, Screen.height * .05f);
		resolutionWindow = new Rect(Screen.width * .6f, Screen.height * .11f, Screen.width * .2f, Screen.height * .15f);
		resolutionVeiw = new Rect(0, 0, Screen.width * .2f, Screen.width * .15f);
		resolutionApply = new Rect(Screen.width *.67f, Screen.height * .32f, Screen.width * .25f, Screen.height * .05f);
		masterVolume = new Rect(Screen.width * .5f, Screen.height * .39f, Screen.width * .4f, Screen.height * .04f);
		masterVolumeDisplay = new Rect(Screen.width * .9f, Screen.height * .39f, Screen.width * .1f, Screen.height * .5f);
		masterVolumeMute = new Rect(Screen.width * .7f, Screen.height * .44f, Screen.width * .2f, Screen.height * .05f);
		soundVolume = new Rect(Screen.width * .5f, Screen.height * .49f, Screen.width * .4f, Screen.height * .04f);
		soundVolumeDisplay = new Rect(Screen.width * .9f, Screen.height * .49f, Screen.width * .1f, Screen.height * .5f);
		soundVolumeMute = new Rect(Screen.width * .7f, Screen.height * .54f, Screen.width * .2f, Screen.height * .05f);
		musicVolume = new Rect(Screen.width * .5f, Screen.height * .59f, Screen.width * .4f, Screen.height * .04f);
		musicVolumeDisplay = new Rect(Screen.width * .9f, Screen.height * .59f, Screen.width * .1f, Screen.height * .5f);
		musicVolumeMute = new Rect(Screen.width * .7f, Screen.height * .64f, Screen.width * .2f, Screen.height * .05f);
		returnToMainMenu = new Rect(Screen.width * .1f, Screen.height * .85f, Screen.width * .2f, Screen.height * .05f);
	}
	void OnGUI(){
		
		//Grab accurate screen resolution before running.
		setRes.x = Screen.width;
		setRes.y = Screen.height;

		/*Note : all GUI objects on this area use a % of the screen, denote by .XXf
		 * So .02f is 2% of screen, .1f is 10% of the screen, etc.
		 * This makes for long lines, but if you need ot move stuff aorund, 
		 * The format is (X position, Y position, width, height) for each rect.
		 * Rects are needed by OnGUI, so just edit the constants to move stuff around.
		 * We can work on code eloquence later - this is efficent for prototyping.
		 */

		//Resolution choice box. need a lot of Polish, but functions
			GUI.Label(resolutionLabel, "Resolution");
			
			resVector = GUI.BeginScrollView(resolutionWindow , resVector, resolutionVeiw);

			//ToDo : Populate the resolution list with a reasonable selection of resolutions. then clean up this section
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
			//This is the endof the area needing ToDo attention
			
			//set resolution button

		if (GUI.Button(resolutionApply, "Apply Resolution")){
				Screen.SetResolution((int) setRes.x, (int) setRes.y, false);	
			}
			
			//Master Volume slider
			master = GUI.HorizontalSlider(masterVolume, master, 0f, 1f);
			//Display the slider as a Percent
			string masterString = (int)(master * 100) + "%";
			GUI.Label(masterVolumeDisplay,  masterString);
			//Master mute button
			masterBool = GUI.Toggle(masterVolumeMute, masterBool, "Master Mute");
			
			
			
			//Sound Volume slider and toggle
			sound = GUI.HorizontalSlider(soundVolume, sound, 0f, 1f);
			//apply Sound sldier to volume, modified by the master volume.
			AudioListener.volume = sound * master;
			//Then, display it as a percent of the slider alone
			string soundString = (int)(sound * 100) + "%";
			GUI.Label(soundVolumeDisplay, soundString);
			//mute sound button, applied in conjunction with the master mute
			soundBool = GUI.Toggle(soundVolumeMute, soundBool, "Sound Mute");
			AudioListener.pause = soundBool || masterBool;
			
			
			//Music Volume slider and toggle
			music = GUI.HorizontalSlider(musicVolume, music, 0f, 1f);
			//apply Music volume to the music source, modified by master Volume. 
			mainCameraObj.GetComponent<AudioSource>().volume = music * master;
			//Then display it as a percent of the slider alone
			string musicString = (int)(music * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .59f, Screen.width * .1f, Screen.height * .5f), musicString);
			//mute music button, applied in conjuntion with the master mute
			musicBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .64f, Screen.width * .2f, Screen.height * .05f), musicBool, "Music Mute");
			mainCameraObj.GetComponent<AudioSource>().mute = musicBool || masterBool;

			//Back to Main Menu button
			if (GUI.Button(returnToMainMenu, "Back to Menu")){
				GameObject optionsCamObj = GameObject.Find("Options Object");
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
