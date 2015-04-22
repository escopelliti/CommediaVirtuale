using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MainManager : MonoBehaviour {
	
	public ArrayList EduContentList { get; set; }
	public GameObject CanvasMenu { get; set; }
	private GameObject GamingObj = null;
	public GameObject Dante { get; set; }
	private GameObject Sounds = null;
	public GameObject Virgilio { get; set; }
	public HumanControlScript HumanScript { get; set; }
	public MouseLook MouseLook{ get; set; }
	private GameObject damnedSound ;
	public  GameObject UICanvas { get; set; }
	public GameObject infoCanvas{ get; set; }
	private GameObject bookGameobj;
	public Text bookText{ get; set; }

	public GameObject Minosse { get; set;}
	
	// Use this for initialization
	void Start ()
	{		
		InitializationOnLevel (0);
	}
	
	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		EduContentList = new ArrayList ();
		GamingObj = GameObject.Find ("Gaming");		
	}
	
	public void InitializationOnLevel(int level){

		infoCanvas = GameObject.Find ("InfoCanvas");
		bookGameobj =  infoCanvas.transform.Find ("BookText").gameObject;
		bookText = bookGameobj.GetComponent<Text>();

		UICanvas = GameObject.Find ("UICanvas");
		if (UICanvas != null) {
			UICanvas.SetActive(false);		
		}

		if (level != 0) {
			bookText.text = "Contenuti raccolti : " + EduContentList.Count;
		}

		damnedSound = GameObject.Find ("damnedSound");

		Dante = GameObject.Find ("Dante");
		HumanScript = Dante.GetComponent<HumanControlScript> ();
		MouseLook = Dante.GetComponent<MouseLook> ();

		CanvasMenu = GameObject.Find ("CanvasMenu");

		Sounds = GameObject.Find ("Sounds");

		Virgilio = GameObject.Find ("Virgilio");
		Minosse = GameObject.Find ("Minosse");
	}
	
	public void OnLevelWasLoaded(int level)
	{
		if (level < 3)
			InitializationOnLevel (level);	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {

			foreach(AudioSource a in Sounds.GetComponents<AudioSource>()){
				if(a.time != 0.0f){
					a.Pause();
				}
			}
			foreach(AudioSource a in Virgilio.GetComponents<AudioSource>()){

				if(a.time != 0.0f)
				{
					a.Pause();
				}
			}
			if(damnedSound != null)
			{
				AudioSource hellSound = damnedSound.GetComponent<AudioSource>();
				hellSound.Pause ();
			}

			if(Minosse != null)
			{
				AudioSource minosseSound = Minosse.GetComponent<AudioSource>();
				minosseSound.Pause ();
			}
			
			CanvasMenu.SetActive(true);
			if(GamingObj != null)
			{
				GamingObj.SetActive (false);
			}

			Dante.SetActive (false);
			Virgilio.SetActive(false);			
		}		
	}
	
	public void NewEduContentHarvested (GameObject eduContent)
	{
		EduContent eduContentScript = eduContent.GetComponent<EduContent> ();
		EduContentList.Add (eduContentScript);
		bookText.text = "Contenuti raccolti : " + EduContentList.Count;
	}
	
}
