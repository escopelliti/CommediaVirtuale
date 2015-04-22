using UnityEngine;
using System.Collections;
using System.Threading;

public class EndSecondLevelScript : MonoBehaviour {
	private GameObject virgilio;
	private AudioSource caronte2 = null;
	public GameObject sounds = null;
	public GameObject onship = null;
	private bool played = false;
	AudioSource audiovirgilioend;
	void Start () {
		virgilio = GameObject.Find ("Virgilio");
		AudioSource[] audiovirgilio = virgilio.GetComponents<AudioSource> ();
		audiovirgilioend = audiovirgilio [1];
		AudioSource[] audio = sounds.GetComponents<AudioSource>();
		caronte2 = audio [1];

		//onship.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (caronte2.time == 0 && !played) {
			played = true;
			audiovirgilioend.Play();
			Thread.Sleep(100);
		}

		if (audiovirgilioend.time == 0 && played) {
			onship.SetActive(true);		
		}
	}
}
