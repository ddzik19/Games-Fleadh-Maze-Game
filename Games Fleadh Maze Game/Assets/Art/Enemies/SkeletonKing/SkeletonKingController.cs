﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKingController : MonoBehaviour {

	public Transform player;
	static Animator anim;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = this.GetComponent<Animator>();
	}
	void Update () {
		if (Vector3.Distance (player.position, this.transform.position) < 13) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 3f * Time.deltaTime);

			anim.SetBool ("isIdle", false);

			if (direction.magnitude > 5) {
				//0.05f is the movement speed towards the player
				this.transform.Translate (0, 0, 0.15f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
			} 
		} else {
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
		}
	}
}
