using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControlCornudo : MonoBehaviour {

	private Transform playerTarget;
	private BossStateChecker bossStateChecker;
	private NavMeshAgent navAgent;
	private Animator anim;

	private bool finishedAttacking = true;
	private float currentAttackTime;
	private float waitAttackTime = 1f;

	void Awake () {
		playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		bossStateChecker = GetComponent<BossStateChecker> ();
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {

		if (finishedAttacking) {
			GetStateControl();
		} else {

			anim.SetInteger ("Transicion", 3);
			if (!anim.IsInTransition (0) && ((anim.GetCurrentAnimatorStateInfo (0).IsName ("GolpearDer"))| (anim.GetCurrentAnimatorStateInfo (0).IsName ("GolpearIzq") ))) {
				finishedAttacking = true;
			}
		}
	}

	void GetStateControl() {
		if (bossStateChecker.BossState == Boss_State.DEATH) {

		//	Debug.Log ("Bos..... start.....");
			navAgent.isStopped = true;
			anim.SetInteger ("Transicion", 4);
			Destroy (gameObject, 9f);

		} else {

			if (bossStateChecker.BossState == Boss_State.PAUSE) {
				navAgent.isStopped = false;
				anim.SetInteger ("Transicion", 1);

				navAgent.SetDestination (playerTarget.position);

			} else if (bossStateChecker.BossState == Boss_State.ATTACK) {

				//anim.SetBool ("Run", false);
				anim.SetInteger ("Transicion", 3);

				Vector3 targetPosition = new Vector3 (playerTarget.position.x, transform.position.y,
					playerTarget.position.z);

				transform.rotation = Quaternion.Slerp (transform.rotation,
					Quaternion.LookRotation (targetPosition - transform.position), 5f * Time.deltaTime);

				if (currentAttackTime >= waitAttackTime) {

					int atkRange = Random.Range (1, 5);
					anim.SetInteger ("Transicion", 1);

					currentAttackTime = 0f;
					finishedAttacking = false;
				} else {
					anim.SetInteger ("Transicion", 1);
					currentAttackTime += Time.deltaTime;
				}

			} else {
				anim.SetInteger ("Transicion", 0);
				navAgent.isStopped = true;
			}

		} 

	}

} // class