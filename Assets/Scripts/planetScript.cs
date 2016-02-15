using UnityEngine;
using System.Collections;

public class planetScript : MonoBehaviour {

	public float rotateAngle = 0.0f;

	// Use this for initialization
	void Start () {

		Debug.Log ("planet init");


	
	}
	
	// Update is called once per frame
	void Update () {

	}


	void onTriggerEnter(Collider collider)
	{
		//collider.transform.RotateAround (transform.position, rotateAngle);
		Debug.Log("Object entered the sphere collider");
		collider.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

	}

	void onTriggerStay(Collider collider){

		Debug.Log ("Object is inside collider");
		collider.transform.RotateAround (collider.transform.position, Vector3.up, rotateAngle);


	}
}
