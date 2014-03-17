using UnityEngine;
using System.Collections;

public class CameraFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*
		/ This code purely exists to make the music valume and mute work 
		/ seperately in the options.
		*/
		this.audio.ignoreListenerPause = true;
		this.audio.ignoreListenerVolume = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
