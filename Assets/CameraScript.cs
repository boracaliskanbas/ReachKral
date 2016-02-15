using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody> ().velocity = GameObject.FindObjectOfType<playerA> ().GetComponent<Rigidbody> ().velocity;
	
	}
}
