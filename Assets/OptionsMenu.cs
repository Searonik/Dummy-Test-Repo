using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
	
	Vector2 resVector = Vector2.zero;
	Vector2 setRes;
	public float master = 0f;
	public float sound = 0f;
	public float music = 0f;
	public bool masterBool = true;
	public bool soundBool = true;
	public bool musicBool = true;
	GameObject optionsCamObj;
	GameObject mainCameraObj;	
	//bool options = false;
	
	//To be used on scene loading
	void awake () {
	
	}
	
	// Use this for initialization
	void Start () {
		optionsCamObj = GameObject.Find("Options Camera");
		optionsCamObj.GetComponent<AudioListener>().enabled = false;
		mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		master = 1;
		sound = AudioListener.volume / master;
		music = mainCameraObj.GetComponent<AudioSource>().volume / master;
		optionsCamObj.SetActive(false);
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
			
			//Master Volume slider and toggle
			master = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .39f, Screen.width * .4f, Screen.height * .04f), master, 0f, 1f);
			
			//convert the slider value to a string and truncate it to a maximum of 5, or 3 digits right of the decimal, then display it
			string masterString = (int)(master * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .39f, Screen.width * .1f, Screen.height * .5f),  masterString);
			//toggle mute button
			masterBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .44f, Screen.width * .2f, Screen.height * .05f), masterBool, "Master Mute");
			mainCameraObj.GetComponent<AudioListener>().enabled = !masterBool;
			
			
			
			//Sound Volume slider and toggle
			sound = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .49f, Screen.width * .4f, Screen.height * .04f), sound, 0f, 1f);
			AudioListener.volume = sound * master;
			string soundString = (int)(sound * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .49f, Screen.width * .1f, Screen.height * .5f), soundString);
			//toggle sound button
			soundBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .54f, Screen.width * .2f, Screen.height * .05f), soundBool, "Sound Mute");
			AudioListener.pause = soundBool;
			
			
			//Music Volume slider and toggle
			music = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .59f, Screen.width * .4f, Screen.height * .04f), music, 0f, 1f);
			mainCameraObj.GetComponent<AudioSource>().volume = music * master;
			string musicString = (int)(music * 100) + "%";
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .59f, Screen.width * .1f, Screen.height * .5f), musicString);
			//toogle music button
			musicBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .64f, Screen.width * .2f, Screen.height * .05f), musicBool, "Music Mute");
			mainCameraObj.GetComponent<AudioSource>().mute = musicBool;
			
		
			//Controls configuration button. (not yet implemented)
			GUI.Button(new Rect(Screen.width * .65f, Screen.height * .7f, Screen.width * .3f, Screen.height * .05f), "Controls configuration");
			
			//Back to Main Menu button
			if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .85f, Screen.width * .2f, Screen.height * .05f), "Back to Menu")){
				//options = !options;
				//GameObject.find("Options Camera").GetComponent<Camera>().enabled = false;
				GameObject optionsCamObj = GameObject.Find("Options Camera");
				optionsCamObj.SetActive(false);
				//Camera derp = herp.GetComponent<Camera>();
				//derp.enabled = false;
			}
	}
	
}
