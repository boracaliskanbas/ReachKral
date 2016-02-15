using UnityEngine;
using System.Collections;

public class playerA : MonoBehaviour {

	public float mass = 100.0f;
	public bool clockwise;
	public bool canOrbit = false;
	public float velocity = 100.0f;
	public Vector3 lastVel;
	Transform trans;
	public float RefVelMag = 0;
	// Use this for initialization
	void Start () {

		this.GetComponent<Rigidbody> ().velocity = new Vector3 (velocity, 0, 0);

		lastVel = this.GetComponent<Rigidbody> ().velocity;

		trans = Camera.main.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		RefVelMag = this.GetComponent<Rigidbody> ().velocity.magnitude;




		//Camera.main.transform.Translate (new Vector3(transform.position.x, trans.position.y, transform.position.z), Space.Self);
	
	}

	void FixedUpdate()
	{
		
	}


}
