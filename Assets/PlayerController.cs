using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {

	public Character character;

	private Vector2 movementDirection;
	private Rigidbody2D rb;
	private Animator anim;
	private GameObject sprite;
	private GameObject projectileSpawn;

	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = transform.Find("Sprite").GetComponent<Animator> ();
		sprite = transform.Find ("Sprite").gameObject;

	}

	void Start () {
		character.Initialize (gameObject);
		projectileSpawn = transform.Find ("SpawnPoint").gameObject;
	}

	public override void OnStartLocalPlayer() {
		Camera.main.GetComponent<CamFollow> ().poi = this.gameObject;
	}

	void Update () {

		if(!isLocalPlayer) {
			return;
		}


		projectileSpawn.transform.rotation = CalculatProjectileSPawnPointRotation ();

		movementDirection = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;	
		if (Input.GetKeyDown(KeyCode.Space)) {
			CmdAction ();
		}

		if (rb.velocity.x == 0 && rb.velocity.y == 0) {
			anim.SetFloat ("Speed", 0f);

		} else {
			anim.SetFloat ("Speed", 1.0f);
		}

		if (rb.velocity.x < 0) {
			sprite.GetComponent<SpriteRenderer> ().flipX = true;
		} else if(rb.velocity.x > 0){
			sprite.GetComponent<SpriteRenderer> ().flipX = false;
		}

	}

	[Command]
	void CmdAction()
	{
		if (character.ability != null) {
			
			GameObject instance = character.ability.TriggerAbility (gameObject, projectileSpawn.transform);
			instance.GetComponent<Mover> ().owner = gameObject.GetComponent<PlayerController>();

			NetworkServer.Spawn (instance);
		}
	}

	void FixedUpdate()
	{
		rb.velocity = movementDirection * character.moveSpeed;
	}


	private Quaternion CalculatProjectileSPawnPointRotation()
	{
		Vector3 dir;
		float angle;
		dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			//return Quaternion.AngleAxis(angle, Vector3.forward);

		return Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void TakeDamage(int amount)
	{
		if (!isServer)
		{
			return;
		}

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}
	}

	void OnChangeHealth(int currentHealth){
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	
	}
}
