using UnityEngine;
using System.Collections;

public class StaticChiken : MonoBehaviour {

	private Animation hen_animation;
	public AnimationClip henIdleAnimation;
	public AnimationClip henPickupunAnimation;

	private GameObject hen; 
	public int i = 10;
	private float nextRandom = 0.0f;
	private float RandomTimeRate;
	// Use this for initialization
	void Start () {
		hen_animation = GetComponent<Animation>();
		hen = (GameObject)this.gameObject;	
		RandomTimeRate = Random.Range (5, 15);
	}
	
	// Update is called once per frame
	void Update () {
		hen_animation.CrossFade (henIdleAnimation.name);
		if (Time.time > nextRandom) {
			nextRandom = Time.time + RandomTimeRate;
			i = Random.Range (0,9);
			if (i > 5) {
				hen_animation.Play (henPickupunAnimation.name);
				hen_animation [henPickupunAnimation.name].layer = 1;
				hen_animation [henPickupunAnimation.name].wrapMode = WrapMode.Once;
			}
		}

	}

}
