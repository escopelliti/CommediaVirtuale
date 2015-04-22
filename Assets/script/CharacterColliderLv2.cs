using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterColliderLv2 : MonoBehaviour {
	

	public GameObject sounds = null;
	private bool oarFound = false;

	private AudioSource caronte1 = null;
	private AudioSource caronte2 = null;
	public GameObject remo = null;
	private bool endLevelFlag = false;
	public GameObject endLevel = null;
	private MainManager mainMgr;
	private GameObject help;
	private GameObject caronte;

	void Start ()
	{
		mainMgr = GameObject.Find ("MainManager").GetComponent<MainManager> ();
		sounds = GameObject.Find ("Sounds");
		AudioSource[] audio = sounds.GetComponents<AudioSource>();
		caronte1 = audio[0];
		caronte2 = audio[1];
		help = mainMgr.infoCanvas.transform.Find ("Help").gameObject;
		caronte = GameObject.Find ("Caronte");
	}
	
	void OnCollisionEnter(Collision collision) 
	{

		if (collision.gameObject.name == "book")
		{
			EduContent eduContent = collision.gameObject.GetComponent<EduContent>();
			eduContent.DestroyMe();
		}
	
		
		if (collision.gameObject.name == "Caronte") {
			Text helpText = help.GetComponent<Text>();
			if (!endLevelFlag)
			{
				if(!oarFound){
					helpText.text ="Obiettivo : porta il remo a Caronte";
					remo.SetActive(true);
					if(caronte1.time == 0){
						caronte1.Play();
					}
				}
				else{
					mainMgr.Virgilio.transform.position = new Vector3(mainMgr.Dante.transform.position.x + 2, 
					                                                  mainMgr.Dante.transform.position.y,
					                                                  mainMgr.Dante.transform.position.z);
					mainMgr.Virgilio.transform.LookAt(caronte.transform.position);
					helpText.text = string.Empty;
					mainMgr.Dante.GetComponent<HumanControlScript>().stayBlocked = true;
					mainMgr.Dante.GetComponent<MouseLook>().enabled = false;
					mainMgr.Virgilio.GetComponent<MouseLook>().enabled = false;
					mainMgr.Virgilio.GetComponent<VirgilioControllerScript>().stayBlocked = true;
					if(caronte2.time == 0)
					{
						caronte2.Play();
						System.Threading.Thread.Sleep(100);
						endLevel.SetActive(true);
						endLevelFlag = true;
					}
				}
			}
		}

		if (collision.gameObject.name == "Oar")
		{
			remo.SetActive(false);
			oarFound = true;
		}
	}
}
