﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float damageAmount = 10f;

	private Transform playerTarget;
	private Animator anim;
	private bool finishedAttack = true;
	private float damageDistance = 2f;
	private bool jugador;
	private PlayerHealth playerHealth;

	void Awake () {
		playerTarget = null;
		anim = GetComponent<Animator> ();
		jugador = false;
		playerHealth = null;


	}

	void Update () {
		if(!this.jugador){
			if(this.playerTarget==null && GameObject.FindGameObjectWithTag ("Player")!=null){
				playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
				playerHealth = playerTarget.GetComponent<PlayerHealth> ();
			}
			if (this.playerTarget != null) {
				this.jugador = true;
			}

		}


		if (finishedAttack) {
			DealDamage (CheckIfAttacking());
		} else {
			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
				finishedAttack = true;
			}
		}
	}

	bool CheckIfAttacking() {
		bool isAttacking = false;

		if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Atk1") ||
		   anim.GetCurrentAnimatorStateInfo (0).IsName ("Atk2")) {

			if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.5f) {
				isAttacking = true;
				finishedAttack = false;
			}

		}

		return isAttacking;
	}

	void DealDamage(bool isAttacking) {
		if (isAttacking) {
			if (Vector3.Distance (transform.position, playerTarget.position) <= damageDistance) {
				playerHealth.TakeDamage (damageAmount);
			}
		}
	}

} // class




































