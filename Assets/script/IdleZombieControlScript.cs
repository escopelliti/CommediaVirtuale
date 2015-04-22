using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]



public class IdleZombieControlScript : MonoBehaviour
{
	public float animSpeed = 1.5f;				
	
	private Animator anim;							
	private AnimatorStateInfo currentBaseState;
	
	void Start ()
	{	
		anim = GetComponent<Animator>();
	}
	
	void Update(){
		
	}
	
	void FixedUpdate ()
	{						
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
