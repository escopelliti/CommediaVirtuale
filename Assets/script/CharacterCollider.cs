using UnityEngine;
using System.Collections;

public class CharacterCollider : MonoBehaviour {

	public static bool IsTrainingEnd = false;
	public GameObject Sounds = null;
	public bool IsSafe { get; set; }

	// Use this for initialization
	void Start () {
		IsSafe = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.name == "book")
		{
			EduContent eduContent = collision.gameObject.GetComponent<EduContent>();
			eduContent.DestroyMe();
			if (!IsTrainingEnd)
			{
				IsTrainingEnd = true;
			}
		}
		if (collision.gameObject.name == "Safe") {
			GameObject.Find ("Safe").SetActive(false);
			GameObject.Find("Gaming").SetActive(false);
			HumanControlScript.alwaysrun= false;
			collision.gameObject.SetActive(false);
			AudioSource[] audio = Sounds.GetComponents<AudioSource>();
			AudioSource breath = audio[5];
			breath.Stop();
			GameObject virgilio = GameObject.Find("Virgilio");
			AudioSource audiovirgilio = virgilio.GetComponent<AudioSource>();
			audiovirgilio.Play();
			IsSafe = true;
		}
		if (collision.gameObject.name == "GoToLevel2" )
		{
			AutoFade.LoadLevel(1,3,1,Color.black);
		}
	}
}
