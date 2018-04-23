using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability {

	public GameObject projectile;

	public override void Initialize()	
	{
		//projectile = Resources.Load ("Projectile") as GameObject;
	}

	public override GameObject TriggerAbility(GameObject player, Transform dir)
	{
		GameObject instance = Instantiate (projectile, dir.position, dir.rotation) as GameObject;
		return instance;
	}
}
