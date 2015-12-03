using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class doorTrigger : MonoBehaviour {

	private bool inTrigger = false;
	public GameObject cube;
	public Text _Text;

	// Use this for initialization
	void Start () {
		//text = GetComponent <Text> ();
		cube = (GameObject)this.gameObject;	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			inTrigger = true;
		}
	}
	
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			inTrigger = false;
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (inTrigger) {
			//Debug.Log ("Cat in Cube!!!!");
			_Text.text = "Press E to open";	
		}
	}
}
