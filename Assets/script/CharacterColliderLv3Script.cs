using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterColliderLv3Script : MonoBehaviour {

	
	public int currentCharacter = 0;
	private bool takenObj = false;
	private MainManager mainMgr;
	public GameObject obj1 = null;
	public GameObject obj2 = null;
	public GameObject obj3 = null;
	public GameObject sounds = null;

	private AudioSource okSound;
	private AudioSource notOkSound;

	public GameObject UCanvas = null;

	void Start () {

		mainMgr = GameObject.Find ("MainManager").GetComponent<MainManager> ();
		AudioSource[] audio = sounds.GetComponents<AudioSource> ();
		okSound = audio [1];
		notOkSound = audio [2];
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		switch (collision.gameObject.name) 
		{
			case "Limbo":
				if(takenObj)
				{
					if (notOkSound.time == 0.0f)
						notOkSound.Play();
				}
				break;
			case "Lussuriosi": //Paolo e Francesca -2				
				if(takenObj && currentCharacter==2)
				{
					takenObj=false;
					obj3.SetActive(true);
					currentCharacter++;
					if (okSound.time == 0.0f)
						okSound.Play();	
				} else{
					if(takenObj)
					{
						if (notOkSound.time == 0.0f)
							notOkSound.Play();
					}	
				}
				break;
			case "Golosi":
					if(takenObj)
					{
						if (notOkSound.time == 0.0f)
							notOkSound.Play();
					}	
				break;
			case "AvariProdighi":
				if(takenObj)
				{
				if (notOkSound.time == 0.0f)
					notOkSound.Play();
				}
				break;
			case "IracondiAccidiosi":
				if(takenObj)
				{
					if (notOkSound.time == 0.0f)
						notOkSound.Play();
				}	
				break;
			case "Eresiaci":
				if(takenObj)
				{
					if (notOkSound.time == 0.0f)
						notOkSound.Play();
				}	
				break;
			case "Violenti"://Pier della Vigne -3
				if(takenObj && currentCharacter==3)
				{
					takenObj=false;
					currentCharacter++;
					if (okSound.time == 0.0f)
						okSound.Play();
					AutoFade.LoadLevel(3, 3, 1, Color.black);
					mainMgr.infoCanvas.transform.Find ("Help").gameObject.SetActive(false);
				}
				else{
					if(takenObj)
					{
						if (notOkSound.time == 0.0f)
							notOkSound.Play();
					}	
				}
				break;
			case "Fraudolenti"://Ulisse - 1
				if(takenObj && currentCharacter==1)
				{
					takenObj=false;
					obj2.SetActive(true);
					currentCharacter++;
					if (okSound.time == 0.0f)
						okSound.Play();
				}
				else{
					if(takenObj)
					{
						if (notOkSound.time == 0.0f)
							notOkSound.Play();
					}	
				}
				break;
			case "Traditori":
				if(takenObj)
				{
					if (notOkSound.time == 0.0f)
						notOkSound.Play();
				}	
				break;
			case "Minosse":				
				GameObject Minosse = GameObject.Find("Minosse");
				AudioSource audioM = Minosse.GetComponent<AudioSource>();
				if(audioM.time == 0)
					audioM.Play();
				if(currentCharacter ==0)
				{
					obj1.SetActive(true);
					currentCharacter++;
				}
				mainMgr.infoCanvas.transform.Find ("Help").gameObject.SetActive(true);
				break;
			case "obj1":
				takenObj = true;
				UCanvas.SetActive(true);
				UCanvas.transform.Find("Obj1Panel").gameObject.SetActive(true);
				GameObject.Destroy(obj1);
				break;
			case "obj2":
				takenObj = true;
				UCanvas.SetActive(true);
				UCanvas.transform.Find("Obj2Panel").gameObject.SetActive(true);
				GameObject.Destroy(obj2);
				break;
			case "obj3":
				takenObj = true;
				UCanvas.SetActive(true);
				UCanvas.transform.Find("Obj3Panel").gameObject.SetActive(true);
				GameObject.Destroy(obj3);
				break;
			case "book":
				EduContent eduContent = collision.gameObject.GetComponent<EduContent>();
				eduContent.DestroyMe();
				break;
			}
	}

	private void SetUICanvas(GameObject gameObj)
	{
		mainMgr.UICanvas.SetActive (true);
		GameObject t = GameObject.Find ("EduContentText");
		Text eduContent = t.GetComponent<Text>();
		eduContent.text = gameObj.GetComponent<EduContent>().Content;
	}
}
