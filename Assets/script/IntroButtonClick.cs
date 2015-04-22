using UnityEngine;
using System.Collections;

public class IntroButtonClick : MonoBehaviour {

	private RunScript runScript;
	public GameObject trainingGameObj = null;
	public GameObject characterController = null;

	// Use this for initialization
	void Start () {
		runScript = trainingGameObj.GetComponent<RunScript> ();
	}
	
	public void OnContinueClick() 
	{
		characterController.SetActive (true);
		runScript.enabled = true;
		gameObject.SetActive (false);
	}
}
