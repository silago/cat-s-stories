using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movePlayer : MonoBehaviour {

	private GameObject player;

	public static float speed = 2;
	public static float _speed;
	public int rotation = 250;
	public int jump = 3;

	public static float x = 0.0f;

	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpPoseAnimation;
	public AnimationClip ItchingAnimation;	
	public AnimationClip MeowAnimation;
	public AnimationClip IdleSitAnimation;
	public AudioSource meow;
	public AudioSource run;
	public Text _Text;
	
	private Animation _animation;

	private bool onGroud = false;
	/*private double lastJumpTime = -10.0;
	private double jumpRepeatTime = 0.01;*/
	// Use this for initialization
	void Start () {
		_animation = GetComponent<Animation>();
		_speed = speed;
		player = (GameObject)this.gameObject;
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Terrain") {
			onGroud = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Terrain") {
			onGroud = false;
		}
	}

	// Update is called once per frame
	void Update () {

		//_Text.text = "Welcome!";

		if (Input.GetKey (KeyCode.W)) {
			player.transform.position += player.transform.forward * speed * Time.deltaTime;
			run.Play();
			//_animation.CrossFade (walkAnimation.name);
		}
		if (Input.GetKey (KeyCode.S)) {
			//speed = _speed/2;
			player.transform.position -= player.transform.forward * speed *Time.deltaTime;
		}
		/*if (Input.GetKeyUp (KeyCode.S)) {
			speed = _speed * 2;
		}*/
		if (Input.GetKey (KeyCode.A)) {
			player.transform.position -= player.transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			player.transform.position += player.transform.right * speed * Time.deltaTime;
		}
		if ((Input.GetKey (KeyCode.Space))/*&& (lastJumpTime + jumpRepeatTime < Time.time)*/) {
			player.transform.position += player.transform.up * jump * Time.deltaTime;
			//lastJumpTime = Time.time;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = _speed * 2;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = _speed;
		}
		if (Input.GetKey (KeyCode.R)){
			meow.Play ();
		}

		if ((Input.GetAxis ("Vertical") != 0.0f) && !Input.GetKey (KeyCode.Space)) {
			if (speed == _speed * 2)
				_animation.CrossFade (runAnimation.name);
			else/* {
				if (_animation.IsPlaying (IdleSitAnimation.name)){
				_Text.text = "sit is playing";
				_animation.Stop (IdleSitAnimation.name);
			}*/
				_animation.CrossFade (walkAnimation.name);
			//}
		} else if (Input.GetKey (KeyCode.C)) {
			_animation.Play (ItchingAnimation.name);
			_animation [ItchingAnimation.name].layer = 1;
			_animation [ItchingAnimation.name].wrapMode = WrapMode.Once;
		} else if (Input.GetKey (KeyCode.R)) {			
			_animation.Play (MeowAnimation.name);
			_animation [MeowAnimation.name].layer = 1;
			_animation [MeowAnimation.name].wrapMode = WrapMode.Once;
		} else if (Input.GetKey (KeyCode.F)) {			
			_animation.Play (IdleSitAnimation.name);
			_animation [IdleSitAnimation.name].layer = 1;
			_animation [IdleSitAnimation.name].wrapMode = WrapMode.ClampForever;
		} else if ((Input.GetKey (KeyCode.Space))&& onGroud == false) {
			_animation.Play (jumpPoseAnimation.name);
			_animation [jumpPoseAnimation.name].wrapMode = WrapMode.ClampForever;
		} else if (onGroud == true) {
			_animation.Stop (jumpPoseAnimation.name);
			_animation.CrossFade (idleAnimation.name);
		} else
			_animation.CrossFade (idleAnimation.name);
	

		Quaternion rotate = Quaternion.Euler (0, x, 0);
		player.transform.rotation = rotate;
	}
}
