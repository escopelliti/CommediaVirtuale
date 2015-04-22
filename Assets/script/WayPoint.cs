using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

	public int order;

	// Use this for initialization
	void Start () {
		this.tag = "waypoint";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetNumber()
	{
		return order;
	}
	
}
