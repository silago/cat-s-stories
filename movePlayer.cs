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
	//public AnimationClip IdleSitAnimation;
	public AnimationClip Sit_downAnimation;
	public AnimationClip Stand_upAnimation;
	public AnimationClip sitAnimation;
	public AudioSource meow;
	public AudioSource run;
	public Text _Text;

	private bool isMoving = false;
	private bool isSiting = false;
	private bool isRuning = false;
	private Animation _animation;

	private bool onGroud = false;
	/*private double lastJumpTime = -10.0;
	private double jumpRepeatTime = 0.01;*/
	// Use this for initialization
	
	void SetInitialValues() {
		var animation_list = new List<string>
		{
			 idleAnimation.name;
			 walkAnimation.name;
			 runAnimation.name;
			 jumpPoseAnimation.name;
			 ItchingAnimation.name;
			 MeowAnimation.name;
			 IdleSitAnimation.name;
			 Sit_downAnimation.name;
			 Stand_upAnimation.name;
			 sitAnimation.name;
		};

		foreach (string animation_name in animation_list) {
			 _animation [animation_name].layer = 1;
			 _animation [animation_name].wrapMode = WrapMode.Once;
		}

		_animation = GetComponent<Animation>();
		_speed = speed;
		player = (GameObject)this.gameObject;
	}

	void Start () {
		_animation = GetComponent<Animation>();
		_speed = speed;
		player = (GameObject)this.gameObject;	
        SetInitialValues();
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
		isMoving = false;
		//isSiting = false;
		//isRuning = false;
		//_Text.text = "Welcome!";
		if (!isSiting) {
			if (Input.GetKey (KeyCode.W)) {
				player.transform.position += player.transform.forward * speed * Time.deltaTime;
				//run.Play();
				//_animation.CrossFade (walkAnimation.name);
			}
			if (Input.GetKey (KeyCode.S)) {
				//speed = _speed/2;
				player.transform.position -= player.transform.forward * speed * Time.deltaTime;
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

			if (Input.GetKey (KeyCode.R)) {
				meow.Play ();
			}
		}

		if ((Input.GetAxis ("Vertical") != 0.0f) && !Input.GetKey (KeyCode.Space)) {
			isMoving = true;
			/*if (!run.isPlaying)
				run.Play();*/
			if (speed == _speed * 2){				
				isRuning = true;
				_animation.CrossFade (runAnimation.name);
			}
			else {
				isRuning = false;
				_animation.CrossFade (walkAnimation.name);

			}
		} else if (Input.GetKey (KeyCode.C)) {
			_animation.Play (ItchingAnimation.name);
		} else if (Input.GetKey (KeyCode.R)) {			
			_animation.Play (MeowAnimation.name);
		} else if (Input.GetKeyUp (KeyCode.F)) {	
			SittingKitten ();
		} else if ((Input.GetKey (KeyCode.Space))&& onGroud == false) {
			_animation.Play (jumpPoseAnimation.name);
			_animation [jumpPoseAnimation.name].wrapMode = WrapMode.ClampForever;
		} else if (onGroud == true) {
			_animation.Stop (jumpPoseAnimation.name);
			_animation.CrossFade (idleAnimation.name);
		} else 
			_animation.CrossFade (idleAnimation.name);
	

		if (isMoving) {
			player.transform.rotation = Quaternion.Euler (0, x, 0);
			if (!run.isPlaying){
				run.Play();
			}
		}
		else run.Stop();
	}


	void SittingKitten () {
		//Debug.Log (isSiting);
		if (!isSiting) {
			_animation.Play (sitAnimation.name);
			_animation.Play (Sit_downAnimation.name);
		} else if (isSiting) {
			_animation.Stop (sitAnimation.name);
			_animation.Play (Stand_upAnimation.name);
		}
		isSiting=!isSiting
	}
}
