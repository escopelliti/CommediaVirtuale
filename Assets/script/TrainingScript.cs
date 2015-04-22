using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class TrainingScript : MonoBehaviour {
	
	public Text message = null;
	private float startTime;
	public static int trainingState;
	private bool timeFinished = false;
	private bool timeStarted = false;
	public static bool started = false;
	private RunScript runscript;
	private AudioSource nelmezzodel;
	private AudioSource selvaoscura;
	public GameObject book = null;
	public GameObject Sounds = null;
	public GameObject introCanvas = null;
	public GameObject characterController = null;


	void Awake ()
	{
		if (trainingState != 4) {
						trainingState = 0;
				}

	}
	
	// Use this for initialization
	void Start () {
		runscript = GetComponent<RunScript>();
		started = true;
		PlayIntroSound ();
	}

	private void PlayIntroSound()
	{
		AudioSource[] sources = Sounds.GetComponents<AudioSource>();
		nelmezzodel = sources[0];
		selvaoscura = sources[4];
		
		if (trainingState != 4) {
			nelmezzodel.Play();

		}

		selvaoscura.Play();
	}
	
	// Update is called once per frame
	void Update () {
		//controllo prima per guardare la variabile del menu attivo
		if(timeFinished) 
		{
			trainingState++;
			timeStarted = false;
			timeFinished = false;
			//trainingState = 4;
		}



		switch (trainingState)
		{
		case 0: 
			message.text = "Per muoverti in avanti utilizza W.\n Utilizza il mouse per cambiare direzione.";					
			if((Input.GetKey("up") || Input.GetKey("w")) && !timeStarted)
			{
				StartTimer();
			}
			
			//fase iniziale: impara a muoverti (anche corri)
			break;
		
		case 1:
			message.text = "Aggiungi SHIFT al movimento per correre.";

			if(Input.GetKey (KeyCode.LeftShift) && (Input.GetKey("up") || Input.GetKey("w")))
			{
				if(!timeStarted)
				{
					StartTimer();
				}

			}
			break;

		case 2: message.text = "Per saltare utilizza il tasto SPACEBAR."; 
			if (Input.GetButtonDown("Jump"))
			{
				if(!timeStarted)
				{
					StartTimer();
					book.SetActive(true);
				}
			}
			break;

		case 3: message.text = "Vai incontro ad un oggetto per raccoglierlo."; 				
			if(CharacterCollider.IsTrainingEnd){
				StartTimer ();

			}
			break;
		
		case 4: //lancio lo script che gestisce la corsa

			message.enabled = false;
			introCanvas.SetActive(true);
			characterController.SetActive(false);
			this.enabled = false;
			break;
		}
		
		
		
	}
	
	private void StartTimer() 
	{
		timeStarted = true;
		Thread countdown = new Thread(() => {
			Thread.Sleep(4000);
			timeFinished = true;
		});
		countdown.Start ();
	}
	
	
	
}
