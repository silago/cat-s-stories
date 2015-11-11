using UnityEngine;
using System.Collections;

public class AnimatePlayer : MonoBehaviour {

	/*public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation; 
	public AnimationClip jumpPoseAnimation;
	public AnimationClip ItchingPoseAnimation;
	public AnimationClip MeowPoseAnimation;
*/
	private Animation _animation;

	/*public enum CharacterState {
		Idle = 0,
		Walking = 1,
		Trotting = 2,
		Running = 3,
		Jumping = 4,
	}*/

	// Use this for initialization
	void Start () {
		_animation = GetComponent<Animation>();
		_animation.wrapMode = WrapMode.Loop;
		/*
		_animation [jumpPoseAnimation.name].wrapMode = WrapMode.Once;
		_animation [ItchingPoseAnimation.name].wrapMode = WrapMode.Once;
		_animation [MeowPoseAnimation.name].wrapMode = WrapMode.Once;

		_animation.Stop ();*/
		//_animation.CrossFade (idleAnimation.name);

		//animation.WrapMode = WrapMode.Loop;
		_animation["Jump"].wrapMode = WrapMode.Once;

	}
	
	// Update is called once per frame
	void Update () {
		
		if ((Input.GetAxis ("Vertical") != 0.0f) && (Input.GetAxis ("Horizontal") != 0.0f)) {
			if (movePlayer.speed == movePlayer._speed * 2)
				//_animation.CrossFade (runAnimation.name);
				_animation.CrossFade ("Run");
			else
				//_animation.CrossFade (walkAnimation.name);
				_animation.CrossFade ("Walk");
		} else if (Input.GetKey (KeyCode.Space)) {
			//_animation.Play (jumpPoseAnimation.name);
			_animation.CrossFade ("Jump");
		} else 
			//_animation.CrossFade (idleAnimation.name);
			_animation.CrossFade ("Idle");
	}
}
