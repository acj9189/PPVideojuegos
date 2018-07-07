using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCornudo : MonoBehaviour {

	public float damageAmount = 10f;

	private Transform playerTarget;
	private Animator anim;
	private bool finishedAttack = true;
	private float damageDistance = 2f;

	private PlayerHealth playerHealth;

	void Awake () {
		playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent<Animator> ();

		playerHealth = playerTarget.GetComponent<PlayerHealth> ();

	}

	void Update () {
		if (finishedAttack) {
			DealDamage (CheckIfAttacking());
		} else {
			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("GolpearDer")) {
				finishedAttack = true;
			}
		}
	}

	bool CheckIfAttacking() {
		bool isAttacking = false;

		if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("GolpearDer") ||
			anim.GetCurrentAnimatorStateInfo (0).IsName ("GolpearDer")) {

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



