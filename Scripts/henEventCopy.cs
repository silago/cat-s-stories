using UnityEngine;
using System.Collections;

public class henEventCopy : MonoBehaviour {
	public NavMeshAgent nav;
	
	private Animation hen_animation;
	public AnimationClip henIdleAnimation;
	public AnimationClip henWalkAnimation;
	public AnimationClip henPickupunAnimation;
	
	private GameObject hen;
	//private Transform target; 
	private GameObject[] target;
	private Vector3 defaultPosition;
	private Vector3 secondPosition;
	//public int distance = 0; 
	public int i;
	public bool isInDestinPoint = true;
	private int _random = 0;
	
	public static float speed = 0.5f;
	//public static float _speed;
	public int rotation = 250;
	private float nextFire = 0.0f;
	private float fireRate = 10.0f;
	private bool isPicking = false;
	private bool isMoving = false;
	private float y = 0.0f;
	private bool getRandom = false;
	
	// Use this for initialization
	void Start () {
		hen_animation = GetComponent<Animation>();
		hen = (GameObject)this.gameObject;
		//target = GameObject.FindGameObjectWithTag ("HenDestination").transform;
		//defaultPosition = hen.transform.position;
		target = GameObject.FindGameObjectsWithTag ("HenDestination");		
		i = Random.Range (0, 4);
	}
	
	// Update is called once per frame
	void Update () {
		/*for ( i = 0; i < 5; i++){
			i += 1;*/
		//yield return new WaitForSeconds(5);
		/*StartCoroutine(_Wait());
		hen_animation.CrossFade (henIdleAnimation.name);*/
		
		
		//if (isInDestinPoint/* && !isMoving*/) {
		//if (isInDestinPoint) {
		hen_animation.CrossFade (henIdleAnimation.name);
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (!isMoving/* && !isPicking*/) {
				_random = Random.Range (0, 100);
				//Debug.Log (_random);
				/*if (_random > 10){					
					i = Random.Range (0,4);	
					hen_Move();*/
			}
		}
		//}
		
		if (_random > 50 /*&& !isMoving&& !getRandom&& isInDestinPoint*/) {
			//if (isInDestinPoint)
			//if (getRandom)
			//if (isMoving && isInDestinPoint)
			//if (!isPicking && !isMoving)
			i = Random.Range (0,4);	
			getRandom = false;
			hen_Move();	
			//getRandom = true;
		}
		/*if (getRandom){
			i = Random.Range (0,4);	
			getRandom = false;
			hen_Move();	
			//isMoving = true;
		}
				isMoving = true;
				return;
		
		//}
				//hen_animation [henIdleAnimation.name].layer = 1;
			//}
			
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//if (!isInDestinPoint){
			nav.enabled = true;
			hen_animation.CrossFade (henWalkAnimation.name);
			//hen_animation [henWalkAnimation.name].speed = nav.velocity.magnitude / speed * 1.2f;
			nav.speed = speed;

			nav.SetDestination (target [i].transform.position);
			if ((Mathf.Abs (hen.transform.position.x) == Mathf.Abs (target [i].transform.position.x)) & (Mathf.Abs (hen.transform.position.z) == Mathf.Abs (target [i].transform.position.z))) {
			//if ((hen.transform.position.x == target[i].transform.position.x)&(hen.transform.position.z == target[i].transform.position.z))
				isInDestinPoint = true;
				i = Random.Range (0, 4);
				hen_animation.Play (henPickupunAnimation.name);
				hen_animation [henPickupunAnimation.name].layer = 1;
				hen_animation [henPickupunAnimation.name].wrapMode = WrapMode.Once;
			}
			Debug.Log (Time.time);
			//}
			//}
		//}
		
		if (isInDestinPoint) {
			i = Random.Range (0, 1);
			isInDestinPoint = false;
		}
		

		if (Vector3.Distance(transform.position, defaultPosition) <= distance) {
			hen.transform.position += hen.transform.forward * speed * Time.deltaTime;
			hen_animation.CrossFade (henWalkAnimation.name);			
		}	*/
		
	}
	
	void hen_Move (){
		
		//i = Random.Range (0, 4);
		if (hen_animation.IsPlaying (henPickupunAnimation.name)) {
			//isInDestinPoint = false;
			isPicking = true;
			//Quaternion rotate = Quaternion.Euler (0, y, 0);
			//hen.transform.rotation = Quaternion.identity;
			return;
		}
		else
			isPicking = false;
		if (!isMoving /*&& isInDestinPoint*/) {
			
			//i = Random.Range (0,4);
			nav.enabled = true;			
			isMoving = true;
			//isInDestinPoint = false;
			hen_animation.CrossFade (henWalkAnimation.name);
			hen_animation [henWalkAnimation.name].layer = 1;
			//y = hen.transform.rotation.y;
			//isPicking = false;
			
			nav.speed = speed;
			nav.SetDestination (target [i].transform.position);		
			Debug.Log (i);
			Debug.Log (target[i].transform.position);
			Debug.Log (hen.transform.position);
		}
		if ((Mathf.Abs (hen.transform.position.x) == Mathf.Abs (target [i].transform.position.x)) && (Mathf.Abs (hen.transform.position.z) == Mathf.Abs (target [i].transform.position.z))) {
			//Debug.Log ("EXTERMINATION");
			//_random = 0;
			isMoving = false;
			isInDestinPoint = true;
			//i = Random.Range (0, 4);
			hen_animation.Stop (henWalkAnimation.name);
			hen_animation.Play (henPickupunAnimation.name);
			hen_animation [henPickupunAnimation.name].speed = 2;
			hen_animation [henPickupunAnimation.name].layer = 1;
			hen_animation [henPickupunAnimation.name].wrapMode = WrapMode.Once;
			//Update ();
			//getRandom = false;
			getRandom = false;
		}
		else 
			isInDestinPoint = false;	
		
	}
}
