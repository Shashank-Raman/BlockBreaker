using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;

	// Use this for initialization
	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!autoPlay) 
		{
			MoveWithMouse ();
		}
		else 
		{
			AutoPlay ();
		}
	}

	void MoveWithMouse()
	{
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosition = Input.mousePosition.x / Screen.width * 16;
		paddlePosition.x = Mathf.Clamp(mousePosition, 0.5f, 15.5f);
		this.transform.position = paddlePosition;
	}

	void AutoPlay()
	{
		//Move the mouse to the y-position of the ball
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		paddlePosition.x = Mathf.Clamp(ballPosition.x, 0.5f, 15.5f);
		this.transform.position = paddlePosition;
	}
}
