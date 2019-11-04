using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}
	
	void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		//float moveHorizontal = Input.acceleration.x;
		//float moveVertical = -Input.acceleration.z;

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//rigidbody.velocity = movement * speed;

		for (var i = 0; i < Input.touchCount; ++i) {
			var touch = Input.GetTouch(i);
			// Handle finger movements based on touch phase.
			switch (touch.phase) {
				// Record initial touch position.
			case TouchPhase.Began:
				// do something here
				break;
				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				Vector3 movement = new Vector3 (touch.deltaPosition.x, 0.0f, touch.deltaPosition.y);
				GetComponent<Rigidbody>().velocity = movement * speed;
				break;
				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				//hey do something here
				break;
			}
		}
		

		
		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}