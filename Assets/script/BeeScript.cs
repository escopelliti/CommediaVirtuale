using UnityEngine;
using System.Collections;

public class BeeScript : MonoBehaviour {

	private Vector3 target;
	private float timer;
	private int sec;
	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		target = ResetTarget();
		sec = ResetSec();
		startingPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > sec){
			target = ResetTarget();
			sec = ResetSec();
		}

		transform.Translate(target * 2 * Time.deltaTime);
	}

	Vector3 ResetTarget()
	{
		return new Vector3(Random.Range(-2.0f,2.0f), Random.Range(-0.1f, 0.1f), Random.Range(-2.0f,2.0f));
	}

	int ResetSec() {
		timer = 0;
		return (int) Random.Range(1f,3f);
	}


}
