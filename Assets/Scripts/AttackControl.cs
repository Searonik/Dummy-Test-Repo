using UnityEngine;
using System.Collections;

public class AttackControl : MonoBehaviour {

	private int damage = 10;
	public float duration;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, duration);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public int Damage(){
		return damage;
	}


}
