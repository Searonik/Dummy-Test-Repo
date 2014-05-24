using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	int HP;
	int maxHP;

	// Use this for initialization
	void Start () {
		maxHP = 100;
		HP = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .15f, Screen.height * .05f), HP + "/" + maxHP);
	}

	public void takeDamage(AttackControl incoming){
		HP -= incoming.Damage();
	}
}
