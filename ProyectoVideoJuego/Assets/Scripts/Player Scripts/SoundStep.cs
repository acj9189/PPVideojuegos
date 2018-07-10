using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStep : MonoBehaviour {


	double stepInterval = 0.3; // min interval between steps
	double stepLength = 0.5; // distance walked by each step
	//public AudioClip []footsteps ; // drag step sounds here
	public AudioClip footsteps; // drag step sounds here

	private double stepTime;
	private Vector3 lastStep;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		lastStep = transform.position; // initialize lastStep position
		audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

		// if walked a distance >= stepLength...
		if (Vector3.Distance(transform.position, lastStep) >= stepLength){
			if (Time.time > stepTime){ // and it's time to play a new footstep...
				// play a randomly selected sound:
				Debug.Log("Entro a calcularo los pasos" + footsteps.name);
				//audio.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
				//audio.PlayOneShot(footsteps[0]);
				audio.PlayOneShot(footsteps);

				lastStep = transform.position; // update lastStep and stepTime:
				stepTime = Time.time + stepInterval;
				audio.Play();
			}
		}
		
	}
}
