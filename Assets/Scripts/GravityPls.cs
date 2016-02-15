using UnityEngine;
using System.Collections;

public class GravityPls : MonoBehaviour {

	float gravity = -3500.0f;

	// Use this for initialization
	void Start () {



		//GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, 8000));

		GetComponent<Rigidbody> ().AddForce (-5000, 0, 0, ForceMode.Impulse);


	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody>().velocity += transform.position.normalized * gravity * Time.deltaTime;

		string name = GetComponent<Rigidbody> ().name;
		Debug.Log (name);
	
	}
}
