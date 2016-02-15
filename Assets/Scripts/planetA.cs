using UnityEngine;
using System.Collections;

public class planetA : MonoBehaviour {

	public float mass = 1000.0f;
	static GameObject self;
	public float g = 0.01f;
	public Vector3 acceleration = Vector3.zero;
	bool canOrbit = false;
	bool clockwise;
	float rotateAngle = 100;
	public Vector3 vel;
	bool bInput = false;
	public float speed = 0.0f;
	public bool bRotating = false;
	public Vector3 BaseVel = new Vector3(0,0,0);
	public Vector3 VelIn = new Vector3(0,0,0);





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		BaseVel = collider.gameObject.GetComponent<Rigidbody> ().velocity;
		

		//Camera.main.ScreenToWorldPoint (transform.position);
	
		//Camera.main.transform.Translate (transform.position, Space.World);




		//Camera.main.transform.position.x = transform.position.x;
		//Camera.main.transform.position.z = transform.position.z;

		var posVector = (transform.position - collider.transform.position);
		var angle = Vector3.Angle (posVector, collider.GetComponent<Rigidbody> ().velocity);





		Debug.Log ("angle val " + angle);




		Debug.Log (Vector3.Cross (posVector, collider.GetComponent<Rigidbody> ().velocity));

		if (Vector3.Cross (posVector, collider.GetComponent<Rigidbody> ().velocity).y > 0) 
			collider.GetComponent<playerA> ().clockwise = false;
		else
			collider.GetComponent<playerA> ().clockwise = true;

//		if (Mathf.Abs (angle) >= 45.0f) {
//
//			collider.GetComponent<playerA> ().canOrbit = true;
//
//
//
//			collider.GetComponent<Rigidbody> ().velocity = Vector3.zero;
//
//		}



		Debug.Log ("Player entered with an angle of " + angle + " " + " " +canOrbit);



	}

	void OnTriggerStay(Collider collider)
	{
		if (!collider.GetComponent<playerA> ().canOrbit) {
			
			float multiplier = GetComponent<SphereCollider> ().radius * this.transform.localScale.x / (Vector3.Distance(collider.gameObject.GetComponent<Rigidbody>().position, this.transform.position));
			VelIn = BaseVel + (BaseVel * (multiplier - 1)*  0.1f); 
			float speedx = (VelIn.x) * (VelIn.x);
			float speedz = (VelIn.z) * (VelIn.z);

			//float speedx = (collider.gameObject.GetComponent<Rigidbody> ().velocity.x) * (collider.gameObject.GetComponent<Rigidbody> ().velocity.x);
			//float speedz = (collider.gameObject.GetComponent<Rigidbody> ().velocity.z) * (collider.gameObject.GetComponent<Rigidbody> ().velocity.z);
			speed = Mathf.Sqrt (speedx + speedz);
		}

		//collider.transform.RotateAround (transform.position, Vector3.up, rotateAngle * Time.fixedDeltaTime);

		//Debug.Log (rotateAngle * Time.fixedDeltaTime);
		var posVector = (transform.position - collider.transform.position);
		var angle = Vector3.Angle (posVector, collider.GetComponent<Rigidbody> ().velocity);

		if (Mathf.Abs (angle) >= 70.0f && !bInput) {

			collider.GetComponent<playerA> ().canOrbit = true;



			collider.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		}

		//if (Input.GetKey (KeyCode.DownArrow)) {
		if((Input.touchCount > 0) || (Input.GetKey (KeyCode.DownArrow)) ){

			var normAngle = (transform.position - collider.transform.position).normalized;

			var tempAngle = normAngle.x;

			if(collider.GetComponent<playerA> ().clockwise)
				normAngle.x = -normAngle.z;
			else
				normAngle.x = normAngle.z;
			


			if(collider.GetComponent<playerA> ().clockwise)
				normAngle.z = tempAngle;
			else
				normAngle.z = -tempAngle;

			collider.GetComponent<Rigidbody> ().velocity = normAngle * speed;//mag;//rotateAngle
			bInput = true;
			return;

		}



		if (!bInput) {
			if (collider.GetComponent<playerA> ().canOrbit) {
				


				Debug.Log ("scale = " + this.transform.localScale.x);

				if (collider.GetComponent<playerA> ().clockwise) {
					collider.transform.RotateAround (transform.position, Vector3.up, Time.fixedDeltaTime * 360 * speed / (2 * Mathf.PI * (Vector3.Distance(collider.gameObject.GetComponent<Rigidbody>().position,this.transform.position))));//GetComponent<SphereCollider> ().radius * this.transform.localScale.x));
				} else
					collider.transform.RotateAround (transform.position, Vector3.down, Time.fixedDeltaTime * 360 * speed / (2 * Mathf.PI * (Vector3.Distance(collider.gameObject.GetComponent<Rigidbody>().position,this.transform.position))));//GetComponent<SphereCollider> ().radius * this.transform.localScale.x));
				


			} else
				collider.GetComponent<Rigidbody> ().velocity = VelIn;
			//else {
//				var distance = (transform.position - collider.transform.position);	
//
//				var direction = (transform.position - collider.transform.position);
//				//Debug.Log (direction);
//				acceleration += g * (direction.normalized * mass) / direction.sqrMagnitude;
//
//				collider.GetComponent<Rigidbody> ().velocity += acceleration * Time.fixedDeltaTime;
//				collider.transform.position += collider.GetComponent<Rigidbody> ().velocity * Time.fixedDeltaTime;
//
//			}

			vel = collider.GetComponent<Rigidbody> ().velocity;

		}
				
	}

	void OnTriggerExit(Collider collider)
	{
		Debug.Log ("Player is out of sphere collider");

		collider.GetComponent<playerA> ().canOrbit = false;
		collider.GetComponent<playerA> ().clockwise = false;

		bInput = false;

	}

	void FixedUpdate()
	{
		Debug.Log (VelIn.magnitude);
	}
}