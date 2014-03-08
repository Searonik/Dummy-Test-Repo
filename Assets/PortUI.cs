using UnityEngine;
using System.Collections;

public class PortUI : MonoBehaviour {

	private bool ShowPort = false;
	private int PortWindow = 0;
	public Texture2D Shipyard;
	public Texture2D Market;
	public Texture2D Tavern;
	public Texture2D Warehouse;
	public Texture2D Docks;
	public Texture2D CloseWindow;
	private Rect ShipWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
	private Rect MarkWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
	private Rect TaveWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
	private Rect WareWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
	private Rect DockWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
	private string[] WindowNames = {"Shipyard", "Market", "Tavern", "Warehouse", "Docks"};
	public GameObject PortObject;

	void awake(){
		/*
		ShipWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
		MarkWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
		TaveWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
		WareWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
		DockWindow = new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .8f, Screen.height * .8f);
		*/
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Port")){
			PortObject.SetActive(!PortObject.activeSelf);
			ShowPort = PortObject.activeSelf;
			PortWindow = -1;
		}


	}

	void OnGUI(){
		if (ShowPort){
			if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .3f, Screen.width * .1f, Screen.height * .1f), Shipyard)){
				PortWindow = 0;
			}
			if (GUI.Button(new Rect(Screen.width * .8f, Screen.height * .25f, Screen.width * .2f, Screen.height * .2f), Market)){
				PortWindow = 1;
			}
			if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * 0f, Screen.width * .2f, Screen.height * .2f), Tavern)){
				PortWindow = 2;
			}
			if (GUI.Button(new Rect(Screen.width * .6f, Screen.height * .8f, Screen.width * .2f, Screen.height * .2f), Warehouse)){
				PortWindow = 3;
			}
			if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .8f, Screen.width * .2f, Screen.height * .2f), Docks)){
				PortWindow = 4;
			}
		
		switch (PortWindow){
			case 0:
				ShipWindow = GUI.Window(1, ShipWindow, DisplayShipyard, "Shipyard");
				break;
			case 1:
				MarkWindow = GUI.Window(2, MarkWindow, DisplayMarket, "Market");
				break;
			case 2:
				TaveWindow = GUI.Window(3, TaveWindow, DisplayTavern, "Tavern");
				break;
			case 3:
				WareWindow = GUI.Window(4, WareWindow, DisplayWarehouse, "Warehouse");
				break;
			case 4:
				DockWindow = GUI.Window(5, DockWindow, DisplayDocks, "Docks");
				break;
			}
		}
		
	}

	void DisplayShipyard(int ID){
		PortTabs(ShipWindow);
	}

	void DisplayMarket(int ID){
		PortTabs(MarkWindow);
	}

	void DisplayTavern(int ID){
		PortTabs(TaveWindow);
	}

	void DisplayWarehouse(int ID){
		PortTabs(WareWindow);
	}
	
	void DisplayDocks(int ID){
		PortTabs(DockWindow);
	}

	void PortTabs(Rect window){
		Debug.Log(window);
		PortWindow = GUI.Toolbar(new Rect(window.x, window.y + window.height * .1f, window.width * .8f, window.height * .1f), PortWindow, WindowNames);
		if (GUI.Button(new Rect(window.x + window.width * .8f, window.y, window.width * .05f, window.width * .05f), CloseWindow)){
			PortWindow = -1;
		}
	}

}
