using UnityEngine;
using System.Collections;

public class OnShipScript : MonoBehaviour {
	private GameObject dante ;
	private GameObject campos;
	public  GameObject barca = null;
	private GameObject virgilio;
	public GameObject fpc ;
	private GameObject caronte;
	private bool finished = false;

	void Start () 
	{
		dante = GameObject.Find ("Dante");
		virgilio = GameObject.Find ("Virgilio");
		caronte = GameObject.Find ("Caronte");
		virgilio.SetActive (false);
		dante.SetActive (false);
		fpc.SetActive (true);
		barca.transform.position = new Vector3 (180f, 1.5f, 360f);
		System.Threading.Thread endLevelThread = new System.Threading.Thread (() =>
		{
			System.Threading.Thread.Sleep(6000);
			finished = true;
		});
		endLevelThread.Start();
	}
	

	void Update () {
		if (finished)
			AutoFade.LoadLevel(2, 3, 1, Color.black);
		barca.transform.position = new Vector3 (barca.transform.position.x+0.1f , barca.transform.position.y , barca.transform.position.z);
		fpc.transform.position = new Vector3 (fpc.transform.position.x+0.1f , fpc.transform.position.y , fpc.transform.position.z);
	}
}
