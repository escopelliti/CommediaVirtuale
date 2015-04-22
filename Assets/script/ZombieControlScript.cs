using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]



public class ZombieControlScript : MonoBehaviour
{
	public float animSpeed = 1.5f;				
	
	private Animator anim;							
	private AnimatorStateInfo currentBaseState;


	public List<GameObject> waypoints = new List<GameObject>();
	private int counter;
	private Vector3 startingPosition;
	
	void Start ()
	{
		startingPosition = gameObject.transform.position;
		foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("waypoint")) 
		{
			waypoints.Add(gameObj);
		}
		waypoints = waypoints.OrderBy (o => o.name).ToList ();
		counter = 0;
		anim = GetComponent<Animator>();					  				
	}
	
	void Update(){

	}
	
	void FixedUpdate ()
	{
		GameObject waypoint = null;

		waypoint = waypoints[counter];
		if (Mathf.Abs((gameObject.transform.position.x - waypoint.transform.position.x)) <= 0.1f) 
		{

			counter++;
			if (counter >= waypoints.Count)
			{
				gameObject.transform.position = startingPosition;
				counter = 0;					
			}
		}				  
		gameObject.transform.LookAt (waypoint.transform.position);						

		anim.speed = animSpeed;
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
		RaycastHit hitInfo = new RaycastHit();
		
		if (Physics.Raycast(ray, out hitInfo))
		{
			if (hitInfo.distance > 1.75f)
			{
				anim.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
			}
		}
	}
}
