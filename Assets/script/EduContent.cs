using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EduContent : MonoBehaviour {
	
	public string contentFile = null;
	public Text contentUIText = null;
	private WWW request;
	private MainManager gameManager;
	public string contentType = null;
	public string Content { get; set; }
	public string name = null;
	private bool isWebPlayer = false;
	// Use this for initialization
	void Start ()
	{
		gameManager = GameObject.Find ("MainManager").GetComponent<MainManager> ();
		if (Application.platform == RuntimePlatform.WindowsWebPlayer)
		{
			StartCoroutine (WaitForDownload());
			isWebPlayer = true;
		} else 
		{
			Content = System.IO.File.ReadAllText(@"Assets/" + contentFile);
		}
	}
	
	IEnumerator WaitForDownload()
	{
		string url = Application.dataPath + @"/" + contentFile;
		request = new WWW (url);
		yield return request;		
	}
	
	public void DestroyMe()
	{
		gameManager.NewEduContentHarvested (gameObject);
		if (isWebPlayer)
		{
			//Debug.Log (Application.dataPath + @"/" + contentFile);
			Content = request.text;
		}				
		if (!contentType.Equals ("special")) {
			gameManager.UICanvas.SetActive (true);
			contentUIText.text = Content;
		}
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (contentType != "norotation")
			transform.Rotate(Vector3.right * Time.deltaTime * 30f);
	}
}
