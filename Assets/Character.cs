using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Characters/PlayableCharacter")]
public class Character : ScriptableObject {

	public float moveSpeed;
	public RuntimeAnimatorController animatorController;
	public Sprite characterSprite;
	public Ability ability;

	public void Initialize(GameObject obj)
	{
		ability.Initialize ();
		obj.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = characterSprite;
		obj.transform.Find ("Sprite").GetComponent<Animator> ().runtimeAnimatorController = animatorController;
	}
}
