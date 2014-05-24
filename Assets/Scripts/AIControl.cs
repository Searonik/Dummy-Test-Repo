using UnityEngine;
using System.Collections;

public class AIControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision thing){
		AttackControl incoming = thing.gameObject.GetComponent<AttackControl>();
		if (incoming != null){
			SendMessageUpwards("takeDamage", incoming);
			Destroy(incoming.gameObject);
		}
	}
}
