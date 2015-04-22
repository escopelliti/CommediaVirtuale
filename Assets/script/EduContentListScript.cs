using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EduContentListScript : MonoBehaviour {

	private GameObject mainManager;
	private MainManager mainManagerScript;
	private GameObject eduContentListPanel;
	public Dictionary<string, EduContent> buttonDictionary { get; set; }

	// Use this for initialization
	void Awake () {

		mainManager = GameObject.Find ("MainManager");
		mainManagerScript = mainManager.GetComponent<MainManager> ();
		eduContentListPanel = GameObject.Find ("EduContentListPanel");
		buttonDictionary = new Dictionary<string, EduContent> ();
	}

	public void DisplayContentList()
	{
		float offsetX = 70;
		float offsetY = 640;
		if (mainManagerScript.EduContentList.Count == 0) {

			GameObject text = Instantiate(Resources.Load ("TextPrefab")) as GameObject;
			text.name = "NoContentText";
			Text t = text.GetComponent<Text>();
			t.text = "Non hai raccolto ancora nessun contenuto";
			t.rectTransform.sizeDelta = new Vector2(600, 30);
			t.fontSize = 25;
			t.color = Color.red;
			t.fontStyle = FontStyle.BoldAndItalic;
			t.transform.parent = eduContentListPanel.transform;
			t.rectTransform.anchoredPosition = new Vector3(94, 0, 0);			
			return;
		}

		foreach (EduContent eduContent in mainManagerScript.EduContentList) {	

			GameObject b = Instantiate (Resources.Load ("Button")) as GameObject;
			b.transform.parent = eduContentListPanel.transform;
			b.transform.position = new Vector3 (offsetX, offsetY, 0);
			Button button = b.GetComponent<Button> ();
			b.name = eduContent.name;
			buttonDictionary.Add(b.name, eduContent);
			button.onClick.AddListener (() => OnBookClick (button));
			b.SetActive (true);

			GameObject text = Instantiate (Resources.Load ("TextPrefab")) as GameObject;
			Text t = text.GetComponent<Text> ();
			t.text = eduContent.name;
			t.color = Color.yellow;
			t.transform.position = new Vector3 (offsetX + 120, offsetY, 0);
			offsetY -= 40;
			t.transform.parent = eduContentListPanel.transform;
		}
	}

	public void OnBookClick(Button data) 
	{
		GameObject displayEduContent = gameObject.transform.parent.transform.Find ("DisplayEduContent").gameObject;
		displayEduContent.SetActive (true);

		GameObject scrollbar = mainManagerScript.CanvasMenu.transform.Find ("Scrollbar").gameObject;
		scrollbar.SetActive (true);

		GameObject content = displayEduContent.transform.Find ("Content").gameObject;
		content.GetComponent<Text> ().text = buttonDictionary[data.name].Content;
	}
	
	// Update is called once per frame
	void Update () {



	}
}
