using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {
	public bool showMenu;
	public int window;
	public GameObject camera;
	public moveCam _moveCam;
	public GameObject music;


	void Start () {
		showMenu = false;
		window = 0;
		camera = GameObject.Find ("Main Camera");
		_moveCam = camera.GetComponent<moveCam> ();
	}
	
	void Update () {
		if(Input.GetKeyUp ("escape") && !showMenu){ 
			/*if (!showMenu){*/
			Cursor.visible = true;
			showMenu = true; 
			window = 1; 
			_moveCam.enabled = false;
			Time.timeScale = 0;
			/*{ 
			else if (showMenu) {
				Cursor.visible = false;
				showMenu = false;
				window = 0;
			}*/
		} 

		else if (Input.GetKeyUp ("escape") && showMenu){
			Cursor.visible = false;
			showMenu = false;
			window = 0;
			_moveCam.enabled = true;
			Time.timeScale = 1;
		}
	}

	void OnGUI (){

			if (window == 1) {
				GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 220), "Меню");

				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Новая игра")) {   
					Application.LoadLevel (0);
				}   
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2, 180, 30), "Об игре")) {   
					window = 2; 
				}   
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Назад")) { 
					window = 0;
					showMenu = false;
					Cursor.visible = false;
					_moveCam.enabled = true;
					//moveKitten.enabled = true;
					Time.timeScale = 1;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), "Выход"))   			
					window = 3;
			}

			if (window == 2) {
				GUI.Label (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 40), "Инфа о разрабе");   
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 100, 180, 30), "назад")) {   
					window = 1;   
				}   
			}

			if (window == 3) {
				GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 120), "Выход?"); 
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 20, 180, 30), "Да")) {   
					Application.Quit (); //Выход из игры 
				}   
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 20, 180, 30), "Нет")) {   
					window = 1;   
				}   
			}

			useGUILayout = false;  
		
	}
}
