using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	Vector2 resVector = Vector2.zero;
	Vector2 setRes;
	public float master = 0f;
	public float sound = 0f;
	public float music = 0f;
	bool masterBool = true;
	bool soundBool = true;
	bool musicBool = true;
	bool options = false;
	
	void awake(){
		setRes.x = Screen.width;
		setRes.y = Screen.height;
	}
	// Use this for initialization
	void Start () {
		GUI.backgroundColor = Color.cyan;
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
		if (!options){
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .05f, Screen.width * .2f, Screen.height * .07f), "Continue game")){
			Debug.Log("Continue");
		}
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .16f, Screen.width * .2f, Screen.height * .07f), "New game")){
			Debug.Log("New game");
		}
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .27f, Screen.width * .2f, Screen.height * .07f), "Load game")){
			Debug.Log("Load game");
		}
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .38f, Screen.width * .2f, Screen.height * .07f), "Options")){
			Debug.Log("Options");
			options = !options;
		}
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .49f, Screen.width * .2f, Screen.height * .07f), "About us")){
			Debug.Log("About us");
		}
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .2f, Screen.height * .07f), "Exit game")){
			Debug.Log("exit");
			Application.Quit();
		}
		
		}
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
		if (options){
			
			//Resolution choice box. need a lot fo work
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
			string masterString = ""+master;
			if (masterString.Length > 4){masterString = masterString.Substring(0,4);}
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .39f, Screen.width * .1f, Screen.height * .5f),  masterString);
			masterBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .44f, Screen.width * .2f, Screen.height * .05f), masterBool, "Master Mute");
			//Sound Volume slider and toggle
			sound = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .49f, Screen.width * .4f, Screen.height * .04f), sound, 0f, 1f);
			string soundString = ""+sound;
			if (soundString.Length > 4){soundString = soundString.Substring(0,4);}
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .49f, Screen.width * .1f, Screen.height * .5f), soundString);
			soundBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .54f, Screen.width * .2f, Screen.height * .05f), soundBool, "Sound Mute");
			//Music Volume slider and toggle
			music = GUI.HorizontalSlider(new Rect(Screen.width * .5f, Screen.height * .59f, Screen.width * .4f, Screen.height * .04f), music, 0f, 1f);
			string musicString = ""+music;
			if (musicString.Length > 4){musicString = musicString.Substring(0,4);}
			GUI.Label(new Rect(Screen.width * .9f, Screen.height * .59f, Screen.width * .1f, Screen.height * .5f), musicString);
			musicBool = GUI.Toggle(new Rect(Screen.width * .7f, Screen.height * .64f, Screen.width * .2f, Screen.height * .05f), musicBool, "Music Mute");
			GUI.Button(new Rect(Screen.width * .65f, Screen.height * .7f, Screen.width * .3f, Screen.height * .05f), "Controls configuration");
			
			//Back to Main Menu button
			if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .85f, Screen.width * .2f, Screen.height * .05f), "Back to Menu")){
				options = !options;
			}
		}
	}
	

}
