using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering : MonoBehaviour
{

	Rigidbody2D rb;

	[SerializeField]
	float accelerationPower;
	[SerializeField]
	float steeringPower;
	float steeringAmount, speed, direction;

	float steeringPower2 = 10;
	float steeringAmount2 = 5, speed2 = 50, direction2;

	// Use this for initialization
	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	public void FixedUpdate()
	{

		steeringAmount = -Input.GetAxis("Horizontal");
		speed = Input.GetAxis("Vertical") * accelerationPower;
		direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

		rb.AddRelativeForce(Vector2.up * speed);

		rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);



	}

    public void OnMouseDown() 
	{
		if(Input.GetButton("ButtonForward"))
        {
			rb.AddForce(transform.up * speed2);
		}
		if(Input.GetButton("ButtonBackward"))
        {
			rb.AddForce(-transform.up * speed2);

		}
	}
}
