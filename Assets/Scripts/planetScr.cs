using UnityEngine;
using System.Collections;

public class planetScr : MonoBehaviour {

	public float rotateAngle = 0.0f;
	public float angleIncrement = 1.0f;
	public Vector4 velocity;
	bool inputKeyGet = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//transform.RotateAround (Vector3.up, 10 * Time.deltaTime);


	}



	void OnTriggerEnter(Collider collider)
	{
		//collider.transform.RotateAround (transform.position, Vector3.up, rotateAngle);
		string strToPrint = "object entered the collider" + collider.name;
		collider.GetComponent<Rigidbody> ().velocity = Vector3.zero;


		Debug.Log(strToPrint);
	}

	void OnTriggerStay(Collider collider)
	{
		Vector3 normAngle = new Vector3 ();
		normAngle = (transform.position - collider.transform.position).normalized;
		 


		if (Input.GetKey ("down")) 
		{
			normAngle = (transform.position - collider.transform.position).normalized;

			var tempAngle = normAngle.x;
			normAngle.x = -normAngle.z;
			normAngle.z = tempAngle;

			collider.GetComponent<Rigidbody> ().velocity = normAngle * rotateAngle/10;//rotateAngle
			inputKeyGet = true;
		}


		Debug.Log (normAngle);
		if (inputKeyGet == false) {
			Debug.Log ("object is inside collider");
			collider.transform.RotateAround (transform.position, Vector3.up, rotateAngle * Time.deltaTime);

			//if(collider.transform.position 
			collider.transform.position += (transform.position - collider.transform.position) / 1000.0f;

			if (rotateAngle < 1000.0)
				rotateAngle += angleIncrement;
		}


		//velocity = collider.GetComponent<Rigidbody>().v


		//var tempGameObj = GameObject.FindObjectOfType<playerScript> ();


		//collider.transform.Rotate (Vector3.up, rotateAngle * Time.deltaTime, Space.Self);

	}
}