using UnityEngine;
using System.Collections;


public class HenEvents : MonoBehaviour {
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
	
	public static float speed = 2.5f;
	//public static float _speed;
	private float nextFire = 0.0f;
	private float fireRate = 10.0f;
	private bool isPicking = false;
	private bool isMoving = false;
	private float y = 0.0f;
    private static float minTargetDistance = 5.0f

	// Use this for initialization
	void Start () {
		hen_animation = GetComponent<Animation>();
		hen = (GameObject)this.gameObject;
		target = GameObject.FindGameObjectsWithTag ("HenDestination");		
		//i = Random.Range (0, 4);
	}
	
	// Update is called once per frame
	void Update () {
            if (!isMoving) {
                hen_animation.CrossFade (henIdleAnimation.name);
            } else {
                hen_animation.CrossFade (henWalkAnimation.name);
            }

			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				if (!isMoving/* && !isPicking*/) {
                    if (Random.Range (0, 10) > 1) {
                        hen_Move(   Random.Range (0,(target.length-1))  );
                        }
				}
			}
	}

    void play_pickup (){
			hen_animation.Stop (henWalkAnimation.name);
			hen_animation.Play (henPickupunAnimation.name);
			hen_animation [henPickupunAnimation.name].speed = 2;
			hen_animation [henPickupunAnimation.name].layer = 1;
			hen_animation [henPickupunAnimation.name].wrapMode = WrapMode.Once;
			isPicking = true;
    }

	void hen_Move (target_number){
        isMoving = true;
		if (isMoving /*&& isInDestinPoint*/) {
			nav.enabled = true;			
			hen_animation [henWalkAnimation.name].layer = 1;
			nav.speed = speed;
			nav.SetDestination (target [target_number].transform.position);		
		}

        // if in destination
		if (
                
                (Mathf.Abs(Mathf.Abs (hen.transform.position.x) -  Mathf.Abs(target [i].transform.position.x) < minTargetDistance))
                &&
                (Mathf.Abs(Mathf.Abs (hen.transform.position.z) - Mathf.Abs (target [i].transform.position.z) < minTargetDistance))
            ) {
			isMoving = false;
            play_pickup()
		}
	}
}
