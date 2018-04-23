using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAbility : Ability {

	public float damage;

	private Collider2D attackRange;
	public GameObject owner;

	public override void Initialize()
	{
		
	}

	public override GameObject TriggerAbility(GameObject player, Transform dir)
	{
		return null;
	}
}
