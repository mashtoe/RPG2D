using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	public GameObject poi;
	private float camZ;

	// Use this for initialization
	void Start () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		if (players.Length > 0) {
			poi = players [0];
		}
		camZ = transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		Vector3 destination;
		if (poi != null) {
			destination.x = poi.transform.position.x;
			destination.y = poi.transform.position.y;
			destination.z = camZ;

			transform.position = destination;
		}

	}
}
