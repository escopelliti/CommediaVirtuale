using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ButtonClickScriptLv3 : MonoBehaviour {
	
	private GameObject danteGameObj = null;
	private HumanControlScript humanScript; 
	private MouseLook mouseLook;
	public GameObject Sounds = null;
	private GameObject virgilioGameObj;
	private MainManager mainMgr;
	private EduContentListScript eduContentListScript;
	private AudioSource audioEnvironment;
	public GameObject UCanvas = null;
	
	// Use this for initialization
	public void Start()
	{
		mainMgr = GameObject.Find ("MainManager").GetComponent<MainManager> ();
		danteGameObj = GameObject.Find ("Dante");
		virgilioGameObj = GameObject.Find ("Virgilio");
		humanScript = mainMgr.HumanScript;
		mouseLook = mainMgr.MouseLook;
		eduContentListScript = mainMgr.CanvasMenu.transform.Find ("EduContentListPanel").GetComponent<EduContentListScript> ();
		audioEnvironment = Sounds.GetComponent<AudioSource> ();
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
		foreach (AudioSource a in Sounds.GetComponents<AudioSource>()) {	
			if (a.time != 0.0f){
				a.Play ();
			}
		}
		audioEnvironment.Play ();
		gameObject.SetActive (false);
		humanScript.enabled = true;
		mouseLook.enabled = true;

		danteGameObj.SetActive (true);
		virgilioGameObj.SetActive(true);
		

		AudioSource minosseSound = mainMgr.Minosse.GetComponent<AudioSource> ();
		if (minosseSound.time != 0.0f)
		{
			minosseSound.Play();
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

	public void OnCloseV2()
	{
		UCanvas.transform.Find("Obj1Panel").gameObject.SetActive(false);
		UCanvas.transform.Find("Obj2Panel").gameObject.SetActive(false);
		UCanvas.transform.Find("Obj3Panel").gameObject.SetActive(false);
		UCanvas.SetActive (false);
	}

	public void OnCloseControlClick(){
		GameObject displayEduContent = transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (false);

		GameObject backcontrolbutton = transform.Find ("BackControlButton").gameObject;
		backcontrolbutton.SetActive (false);

		GameObject scrollbar = transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (false);
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
