using UnityEngine;
using System.Collections;

public class henEventCopy : MonoBehaviour {
	public NavMeshAgent nav;
	
	private Animation hen_animation;
	public AnimationClip henIdleAnimation;
	public AnimationClip henWalkAnimation;
	public AnimationClip henPickupunAnimation;
	
	private GameObject hen; 
	private GameObject[] target;
	private Vector3 defaultPosition;
	private Vector3 secondPosition;
	public int i;
	public bool isInDestinPoint = true;
	//private int _random = 0;
	
	public static float speed = 1.5f;
	public int rotation = 250;
	private float nextFire = 0.0f;
	private float fireRate = 10.0f;
	private bool isPicking = false;
	private bool isMoving = false;
//	private float y = 0.0f;
	//private bool getRandom = false;
	private static float minTargetDistance = 1.0f;

	void Start () {
		hen_animation = GetComponent<Animation>();
		hen = (GameObject)this.gameObject;
		target = GameObject.FindGameObjectsWithTag ("HenDestination");		
		nav.speed = speed;
		//i = Random.Range (0, 4);
	}
	

	void Update () {

		// is picking animation playing - let it play 
		if (hen_animation.IsPlaying (henPickupunAnimation.name)) {
			return;
		}

		if (isMoving) {
			hen_animation.CrossFade (henWalkAnimation.name);
		} else {
			hen_animation.CrossFade (henIdleAnimation.name);
		}

		if (isMoving) {
			check_dest();
		}

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (!isMoving/* && !isPicking*/) {				
				if (Random.Range (0, 10) > 1 ) {
					/*i = Random.Range (0,4);	
					getRandom = false;
					hen_Move();	*/
					hen_Move(Random.Range (0,(target.Length-1))); 
				}	
				//_random = Random.Range (0, 100);
			}
		}
			
	}

	void check_dest (){
		if (
			(Mathf.Abs(hen.transform.position.x - target [i].transform.position.x) < minTargetDistance)
			&&
			(Mathf.Abs(hen.transform.position.z - target [i].transform.position.z) < minTargetDistance)
			) {
			isMoving = false;
			play_pickup();
		}
		nav.enabled = false; 
	}

	void play_pickup (){
		hen_animation.Stop (henWalkAnimation.name);
		hen_animation.Play (henPickupunAnimation.name);
		hen_animation [henPickupunAnimation.name].speed = 2;
		hen_animation [henPickupunAnimation.name].layer = 1;
		hen_animation [henPickupunAnimation.name].wrapMode = WrapMode.Once;
		isPicking = true;
	}

	void hen_Move (int target_number){

		/*if (hen_animation.IsPlaying (henPickupunAnimation.name)) {
			isPicking = true;
			return;
		}
		else
			isPicking = false;*/
		i = target_number;
		isMoving = true;
		/*if (!isMoving) {	

			nav.enabled = true;			
			isMoving = true;
			hen_animation.CrossFade (henWalkAnimation.name);
			hen_animation [henWalkAnimation.name].layer = 1;			
			nav.speed = speed;
			nav.SetDestination (target [i].transform.position);		
			Debug.Log (i);
			Debug.Log (target[i].transform.position);
			Debug.Log (hen.transform.position);
		}*/

		//if (isMoving /*&& isInDestinPoint*/) {
			nav.enabled = true;			
			hen_animation [henWalkAnimation.name].layer = 1;
			nav.speed = speed;
			nav.SetDestination (target[i].transform.position);		
		//}

		//if ((Mathf.Abs (hen.transform.position.x) == Mathf.Abs (target [i].transform.position.x)) && (Mathf.Abs (hen.transform.position.z) == Mathf.Abs (target [i].transform.position.z))) {
		/*if (
			(Mathf.Abs(hen.transform.position.x - target [i].transform.position.x) < minTargetDistance)
			&&
			(Mathf.Abs(hen.transform.position.z - target [i].transform.position.z) < minTargetDistance)
			){
			isMoving = false;
			Debug.Log ("EXTERMINATION");
			/*isInDestinPoint = true;
			hen_animation.Stop (henWalkAnimation.name);
			hen_animation.Play (henPickupunAnimation.name);
			hen_animation [henPickupunAnimation.name].speed = 2;
			hen_animation [henPickupunAnimation.name].layer = 1;
			hen_animation [henPickupunAnimation.name].wrapMode = WrapMode.Once;
			getRandom = false;
			play_pickup();*/
		}
		/*else 
			isInDestinPoint = false;	*/
	//}

}
