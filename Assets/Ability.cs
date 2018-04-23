using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {
	public string aName;
	public Sprite aSprite;
	public AudioClip aSound;
	public float aBaseColldown = 1f;

	public abstract void Initialize ();


	public abstract GameObject TriggerAbility (GameObject player, Transform spawnPoint);


}
