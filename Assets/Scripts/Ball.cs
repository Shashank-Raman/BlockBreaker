using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hasStarted) 
		{
			if (Input.GetMouseButtonDown(0)) 
			{	//Launch the ball
				hasStarted = true;
				this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Vector2 tweak = new Vector2 (Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
		if (hasStarted) 
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
