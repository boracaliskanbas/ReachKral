using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	public float valSpeed = 0.0f;

	// Use this for initialization
	void Start () {

		var playerBody = GetComponent<Rigidbody> ();

		playerBody.AddForce (0, 0, valSpeed, ForceMode.Impulse);




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
