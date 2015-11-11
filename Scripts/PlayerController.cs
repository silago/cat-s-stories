using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private GameObject player;

	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpPoseAnimation;

	private Animation _animation;

	/*public float walkMaxAnimationSpeed = 0.75f;
	public float runMaxAnimationSpeed = 1.0f;
	public float jumpAnimationSpeed = 1.15f;
	public float landAnimationSpeed = 1.0f;

	int walkSpeed = 2;
	int runSpeed = 4;

	double jumpHeight = 0.5;
	int gravity = 20;
	int speedSmoothing = 10;
	int rotateSpeed = 500;
	bool canJump = true;
	private double jumpRepeatTime = 0.05;
	private double jumpTimeout = 0.15;
	private double groundedTimeout = 0.25;

	private Vector3 moveDirection = Vector3.zero;*/
	public static float speed = 0.5f;
	public static float _speed;
	public int rotation = 250;
	public int jump = 3;
	public static float x = 0.0f;
	/*private CollisionFlags collisionFlags;
	private bool jumping = false;
	private bool jumpingReachedApex = false;
	private bool movingBack = false;
	private bool isMoving = false;
	private double walkTimeStart = 0.0;
	private double lastJumpButtonTime = -10.0;
	private double lastJumpTime = -1.0;
	private double lastJumpStartHeight = 0.0;
	private Vector3 inAirVelocity = Vector3.zero;

	private double lastGroundedTime = 0.0;
	private bool isControllable = true;*/

	// Use this for initialization
	void Start () {
		//moveDirection = transform.TransformDirection (Vector3.forward);
		_animation = GetComponent<Animation>();
		_speed = speed;
		player = (GameObject)this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			player.transform.position += player.transform.forward * speed * Time.deltaTime;
			//_animation.CrossFade (walkAnimation.name);
		} 
		if (Input.GetKey (KeyCode.S)) {
			speed = _speed/2;
			player.transform.position -= player.transform.forward * speed *Time.deltaTime;
			//_animation.CrossFade (walkAnimation.name);
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			speed = _speed * 2;
		}
		if (Input.GetKey (KeyCode.A)) {
			player.transform.position -= player.transform.right * speed * Time.deltaTime;
			//_animation.CrossFade (walkAnimation.name);
		}
		if (Input.GetKey (KeyCode.D)) {
			player.transform.position += player.transform.right * speed * Time.deltaTime;
			//_animation.CrossFade (walkAnimation.name);
		}
		if (Input.GetKey (KeyCode.Space)) {
			//player.transform.position += player.transform.up * jump * Time.deltaTime;
			_animation.CrossFade (jumpPoseAnimation.name);
			_animation.wrapMode = WrapMode.Once;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = _speed * 2;
			_animation.CrossFade (runAnimation.name);
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = _speed;
		}
		//else 
			//_animation.CrossFade (idleAnimation.name);
		
		Quaternion rotate = Quaternion.Euler (0, x, 0);
		player.transform.rotation = rotate;
	}
}
