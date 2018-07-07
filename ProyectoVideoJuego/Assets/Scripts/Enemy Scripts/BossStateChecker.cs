﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss_State {
	NONE,
	IDLE,
	PAUSE,
	ATTACK,
	DEATH
}

public class BossStateChecker : MonoBehaviour {

	private Transform playerTarget;
	private Boss_State boss_State = Boss_State.NONE;
	private float distanceToTarget;

	private EnemyHealth bossHealth;
	private bool jugador;

	void Awake () {
		playerTarget = null;
		bossHealth = GetComponent<EnemyHealth> ();
		jugador = false;
	}

	void Update () {
		if(!this.jugador){
			if(this.playerTarget==null && GameObject.FindGameObjectWithTag ("Player")!=null){
				playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
			}
			if (this.playerTarget != null) {
				this.jugador = true;
			}

		}

		if(playerTarget!=null){
		SetState ();
		}
	}

	void SetState() {
		distanceToTarget = Vector3.Distance (transform.position, playerTarget.position);

		if (boss_State != Boss_State.DEATH) {

			if (distanceToTarget > 3 && distanceToTarget <= 15f) {

				boss_State = Boss_State.PAUSE;

			} else if (distanceToTarget > 15f) {

				boss_State = Boss_State.IDLE;

			} else if (distanceToTarget <= 3f) {
			
				boss_State = Boss_State.ATTACK;

			} else {

				boss_State = Boss_State.NONE;
			
			}

			if (bossHealth.health <= 0f) {
				boss_State = Boss_State.DEATH;
			}

		}

	}

	public Boss_State BossState {
		get { return boss_State; }
		set { boss_State = value; }
	}

} // class


































