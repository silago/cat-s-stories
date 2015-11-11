using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

	public bool isEsc = false;
	public moveCam 	CamEsc;
	public GameObject _Camera; 

	void Start () {

		_Camera = GameObject.Find ("Main Camera");
		CamEsc = _Camera.GetComponent<moveCam> ();
		Cursor.visible = false;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt)) {
			if (!isEsc){
				isEsc = true;
				Cursor.visible = true;
			}
			else if (isEsc){
				isEsc = false;
				Cursor.visible = false;
			}
		}
		CamEsc._isEsc = isEsc;
	}

}
