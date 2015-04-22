using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using System.IO;


public class RunScript : MonoBehaviour {
	
	private int sound;
	private AudioSource roar1 = null;
	private AudioSource roar2 = null;
	private AudioSource roar3 = null;
	private AudioSource roar4 = null;
	private AudioSource breath = null;
	private bool timeStarted= false;

	private GameObject mainCharacter;
	private GameObject canvasMenu;
	public static float offset = 0.3f;
	public GameObject Sounds = null;
	private Vector3 startrun = new Vector3 (127f, 0.3f, 76f);

	private MainManager mainMgr;

	// Use this for initialization
	void Start () {

		mainMgr = GameObject.Find ("MainManager").GetComponent<MainManager>();

		mainCharacter = GameObject.Find ("Dante");
		sound = 1;
		mainCharacter.transform.position = startrun;
		AudioSource[] sources = Sounds.GetComponents<AudioSource>();
		roar1 = sources [1];
		roar2 = sources [2];
		roar3 = sources [3];
		breath = sources [5];
		roar4 = sources [6];
		breath.Play ();
		HumanControlScript.alwaysrun = true;	

		canvasMenu = mainMgr.CanvasMenu;
	}
	
	void Awake(){
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if (!timeStarted) {
			switch (sound) {
			case 1:
				roar1.Play();
				StartTimer();
				break;
			case 2:
				roar4.Play();
				StartTimer();
				break;
			case 3:
				roar2.Play();
				StartTimer();
				break;
			case 4:
				roar3.Play();
				StartTimer();
				break;
			}
		}

		Sounds.transform.LookAt (mainCharacter.transform.position);
		Sounds.transform.Translate (Vector3.forward * offset);

		if ((Mathf.Abs(mainCharacter.transform.position.z - this.Sounds.transform.position.z) < 0.2f) && ((Mathf.Abs(mainCharacter.transform.position.x - this.Sounds.transform.position.x) < 0.2f)))
		{
			RestartLevel();
		}

	}

	private void RestartLevel()
	{
		mainCharacter.SetActive(false);

		foreach (AudioSource a in Sounds.GetComponents<AudioSource>()) {
			a.Stop();		
		}

		canvasMenu.SetActive(true);

		GameObject gameOverText = canvasMenu.transform.Find ("GameOverText").gameObject;
		gameOverText.SetActive (true);

		GameObject restartButton = canvasMenu.transform.Find ("RestartButton").gameObject;
		restartButton.SetActive (true);

		foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("canvas_button")) {
			if (gameObj.name == "Exit")
				continue;
			gameObj.SetActive(false);
		}
		mainMgr.EduContentList.Clear ();
		gameObject.SetActive(false);
	}
	
	private void StartTimer() 
	{
		if (sound == 4) {
			sound = 0;		
		}
		timeStarted = true;
		Thread countdown = new Thread(() => {
			Thread.Sleep(2000);
			timeStarted = false;
			sound++;
		});
		countdown.Start ();
	}
}


