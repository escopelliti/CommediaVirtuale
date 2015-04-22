using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ButtonClickScriptLv2 : MonoBehaviour {
	
	public string controlFile = null;
	private string controls;
	public Text menuContent = null;
	private GameObject Dante = null;
	private GameObject Virgilio = null;
	public GameObject Sounds = null;
	private MainManager mainManager;
	private bool startlevel2 = true;
	private GameObject damnedSound ;
	private MouseLook mouseLookdante;
	private MouseLook mouseLookvirgilio;
	private HumanControlScript humanControlScript;
	private VirgilioControllerScript virgiliocontrollerscript;
	private EduContentListScript eduContentListScript;
	
	public void Start()
	{
		mainManager = GameObject.Find ("MainManager").GetComponent<MainManager>();
		damnedSound = GameObject.Find ("damnedSound");
		Dante = mainManager.Dante;
		Virgilio = mainManager.Virgilio;
		mouseLookdante = Dante.GetComponent<MouseLook> ();
		mouseLookvirgilio = Virgilio.GetComponent<MouseLook> ();
		humanControlScript = Dante.GetComponent<HumanControlScript> ();
		virgiliocontrollerscript = Virgilio.GetComponent<VirgilioControllerScript> ();
		eduContentListScript = mainManager.CanvasMenu.transform.Find ("EduContentListPanel").GetComponent<EduContentListScript> ();
	}

	public void OnStartClick()
	{
		foreach(AudioSource a in Sounds.GetComponents<AudioSource>())
		{
			if(a.time!=0.0f)
			{
				a.Play();
			}
		}
		Dante.SetActive (true);
		Virgilio.SetActive (true);
		mouseLookdante.enabled = true;
		mouseLookvirgilio.enabled = true;
		humanControlScript.enabled = true;
		virgiliocontrollerscript.enabled = true;
		if (startlevel2) 
		{
			AudioSource hellSound1 = damnedSound.GetComponent<AudioSource>();
			hellSound1.Play();
			AudioSource virgilio1 = Virgilio.GetComponent<AudioSource> ();
			virgilio1.Play();
			startlevel2 = false;
		}
		AudioSource hellSound2 = damnedSound.GetComponent<AudioSource>();
		if(hellSound2.time!=0.0f){
			hellSound2.Play();
		}

		AudioSource virgilio2 = Virgilio.GetComponent<AudioSource> ();
		if(virgilio2.time!=0.0f){
			virgilio2.Play();
		}

		GameObject displayEduContent = transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (false);
		
		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (false);			

		gameObject.SetActive (false);
	}

	public void OnClose()
	{
		mainManager.UICanvas.SetActive (false);
	}

	public void OnCloseControlClick(){
		GameObject displayEduContent = transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (false);
		
		GameObject backcontrolbutton = transform.Find ("BackControlButton").gameObject;
		backcontrolbutton.SetActive (false);

		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (false);
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

	public void OnExitClick()
	{
		Application.Quit ();
	}

	public void OnContentsClick()
	{
		GameObject eduContentListPanel = transform.Find ("EduContentListPanel").gameObject;
		eduContentListPanel.SetActive (true);

		EduContentListScript eduContentListScript = eduContentListPanel.GetComponent<EduContentListScript> ();
		eduContentListScript.DisplayContentList ();
	}

	
}
