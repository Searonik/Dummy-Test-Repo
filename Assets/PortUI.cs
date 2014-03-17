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
		// Causes the port to display. The port Object is an image. 
		// Showport tracks if the port is open or not
		if (Input.GetButtonDown("Port")){
			PortObject.SetActive(!PortObject.activeSelf);
			ShowPort = PortObject.activeSelf;
			PortWindow = -1;
		}


	}

	void OnGUI(){
		if (ShowPort){
			/* shows 5 buttons, each button being one of the 5 places you can go in port
			 * Each button uses a Rect that takes up a % of the scrren, int he .xxf format
			 * So .-2f is 2%, 1f is 10%, etc. 
			 * The use of rects is a requirement of the GUI Buttons.
			 * This is the simple, if less easy to maintain version.
			 */
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
		
		/* Here, if a button has been pressed, we track it. 
		 * It invokes the Gui Window function for each place in port.
		 * If you don't know what that is, I suggest you read up on
		 * the Unity.GUI tutorials, it's a little wonky.
		 */
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

	// Display functions for each Port element.
	// Each one also invokes a common toolbar, meant to emulate tabs
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

	/* This is the common function that displays the quick-selection
	 * toolbar for going between places in port - like tabs in a window.
	 */
	void PortTabs(Rect window){
		Debug.Log(window);
		PortWindow = GUI.Toolbar(new Rect(window.x, window.y + window.height * .1f, window.width * .8f, window.height * .1f), PortWindow, WindowNames);
		if (GUI.Button(new Rect(window.x + window.width * .8f, window.y, window.width * .05f, window.width * .05f), CloseWindow)){
			PortWindow = -1;
		}
	}

}
