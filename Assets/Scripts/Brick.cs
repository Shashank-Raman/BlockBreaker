using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour 
{
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0; //static in order to be accessible by LevelManager
	public GameObject smoke;

	private bool isBreakable;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () 
	{
		isBreakable = this.tag.Equals("Breakable");
		//Keep track of breakable bricks
		if (isBreakable) 
		{
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) 
		{
			HandleHits ();
		}
	}

	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits)
        {
			breakableCount--;
			levelManager.BrickDestroyed ();
			PuffSmoke ();
			Destroy (gameObject);
		}
		else 
		{
			LoadSprites ();
		}
	}

	void PuffSmoke()
	{
		ParticleSystem.MainModule main = smoke.GetComponent<ParticleSystem> ().main;
		main.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
		Instantiate (smoke, this.transform.position, Quaternion.identity);
	}

	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) 
		{
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
		else
		{
			Debug.LogError ("Error: Brick sprite missing");
		}
	}
}
