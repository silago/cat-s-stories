using UnityEngine;
using System.Collections;

public class KittEvents : MonoBehaviour {

	public AnimationClip MeowAnimation;
	public AnimationClip ItchingAnimation;
	public AudioSource meow;

	private Animation _animation;

	// Use this for initialization
	void Start () {
		_animation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.C)) {
			//player.transform.position = player.transform.position;
			_animation.CrossFade (ItchingAnimation.name);
			_animation [ItchingAnimation.name].wrapMode = WrapMode.Once;
		}
		if (Input.GetKey (KeyCode.X)){
			_animation.CrossFade (MeowAnimation.name);
			_animation [MeowAnimation.name].wrapMode = WrapMode.Once;
			meow.Play ();
		}
	}
}
