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
        nav.speed = speed;
        //i = Random.Range (0, 4);
    }
    
    // Update is called once per frame
    void Update () {
            // is picking animation playing - let it play 
            if (hen_animation.IsPlaying (henPickupunAnimation.name)) {
                return;
            }
            
            // if not moving then idle
            if (isMoving) {
                hen_animation.CrossFade (henWalkAnimation.name);
            } else {
                hen_animation.CrossFade (henIdleAnimation.name);
            }

            // if it's time to do something - 90% chance to move somewhere
            if (isMoving) {
                check_dest();
            }
            if (Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                if (!isMoving/* && !isPicking*/) {
                    if (Random.Range (0, 10) > 1) {
                        hen_Move(   Random.Range (0,(target.Length-1))  );
                        }
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
            play_pickup()
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
        i = target_number
        isMoving = true;
        nav.enabled = true;            
        hen_animation [henWalkAnimation.name].layer = 1;
        nav.SetDestination (target [target_number].transform.position);        
    }
}
