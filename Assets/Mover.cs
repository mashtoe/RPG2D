using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public PlayerController owner;

	public void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame	
	void Update () {
		//rb.AddForce (Vector2.up * speed);sdwadsdawsdaw
		//rb.velocity  = Vector2.up * speed;
		transform.Translate(new Vector2(1,0)* speed * Time.deltaTime);
	}

	public void OnCollisionEnter()
	{
		Destroy(gameObject);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<PlayerController> () != null) {
			PlayerController player = other.gameObject.GetComponent<PlayerController> ();

			if (player != owner) {
				player.TakeDamage (10);
			}

		} else {
			Destroy (gameObject);
		}
	}	

}
