using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ButtonClickScript : MonoBehaviour {
	
	public string controlFile = null;
	private string controls;
	public Text menuContent = null;
	private GameObject gamingGameObj = null;
	private TrainingScript trainingScript;
	private GameObject characterController = null;
	private HumanControlScript humanScript; 
	private MouseLook mouseLook;
	public GameObject Sounds = null;
	private GameObject virgilioGameObj;
	private MainManager mainMgr;
	private EduContentListScript eduContentListScript;

	// Use this for initialization
	public void Start()
	{
		mainMgr = GameObject.Find ("MainManager").GetComponent<MainManager> ();
		TrainingScript.started = false;
		characterController = GameObject.Find ("Dante");
		virgilioGameObj = GameObject.Find ("Virgilio");
		gamingGameObj = GameObject.Find ("Gaming");
		if (gamingGameObj != null) {
			trainingScript = gamingGameObj.GetComponent<TrainingScript> ();
		}
		humanScript = mainMgr.HumanScript;
		mouseLook = mainMgr.MouseLook;
		eduContentListScript = mainMgr.CanvasMenu.transform.Find ("EduContentListPanel").GetComponent<EduContentListScript> ();
	}
	
	public void Awake(){
	
	}

	public void OnBackClick() 
	{
		GameObject eduContentListPanel = transform.Find ("EduContentListPanel").gameObject;
		eduContentListPanel.SetActive (false);

		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (false);

		GameObject displayEduContentPanel = transform.Find ("DisplayEduContent").gameObject;
		if (displayEduContentPanel != null) 
		{
			displayEduContentPanel.SetActive(false);
		}

		try {
			GameObject noContentText = eduContentListPanel.transform.Find ("NoContentText").gameObject;
			if (noContentText != null)
			{
				GameObject.Destroy (noContentText);
			}
		}
		catch(System.Exception ex)
		{
			eduContentListScript.buttonDictionary.Clear();
		}
		eduContentListScript.buttonDictionary.Clear();
	}
	
	public void OnStartClick()
	{
		gameObject.SetActive (false);
		if (!TrainingScript.started) {
			transform.Find ("PresentationImage").gameObject.SetActive(false);
			trainingScript.enabled = true;
			humanScript.enabled = true;
			mouseLook.enabled = true;
			if(gamingGameObj != null){
				gamingGameObj.SetActive (true);
			}
			characterController.SetActive (true);
			virgilioGameObj.SetActive(true);
		}
		else {
			foreach(AudioSource a in Sounds.GetComponents<AudioSource>()){
				if(a.time!=0.0f){
					a.Play();
				}
			}
			virgilioGameObj.SetActive(true);
			foreach(AudioSource a in virgilioGameObj.GetComponents<AudioSource>()){
				if(a.time!=0.0f){
					a.Play();
				}
			}
			humanScript.enabled = true;
			mouseLook.enabled = true;
			if(gamingGameObj != null){
				if(!characterController.GetComponent<CharacterCollider>().IsSafe)
					gamingGameObj.SetActive (true);
			}
			characterController.SetActive (true);

		}

		GameObject displayEduContent = transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (false);
		
		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (false);
	}

	public void OnClose()
	{
		mainMgr.UICanvas.SetActive (false);
	}

	public void OnControlClick()
	{
		GameObject backcontrolbutton = transform.Find ("BackControlButton").gameObject;
		backcontrolbutton.SetActive (true);

		GameObject displayEduContent = transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (true);
		
		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (true);
				
		GameObject content = displayEduContent.transform.Find ("Content").gameObject;
		content.GetComponent<Text> ().text = "\n\nW per muoverti in avanti.\n Utilizza il mouse per cambiare direzione.\n SHIFT per correre. \n SPACEBAR per saltare.\n P Pausa";
	}
	
	public void OnRestartClick()
	{
		TrainingScript.started = true;
		TrainingScript.trainingState = 4;
		AutoFade.LoadLevel (0, 3, 1, Color.black);
	}
	
	
	public void Update()
	{	
	}

	public void OnCloseControlClick(){
		GameObject displayEduContent = transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (false);

		
		GameObject backcontrolbutton = transform.Find ("BackControlButton").gameObject;
		backcontrolbutton.SetActive (false);

		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (false);
	}

	public void OnContentsClick()
	{	
		GameObject eduContentListPanel = transform.Find ("EduContentListPanel").gameObject;
		eduContentListPanel.SetActive (true);	
			
		EduContentListScript eduContentListScript = eduContentListPanel.GetComponent<EduContentListScript> ();
		eduContentListScript.DisplayContentList ();
	}

	public void OnExitClick()
	{
		Application.Quit ();
	}


	
}
