using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string level)
	{
		Debug.Log ("Level load requested for " + level);
		Brick.breakableCount = 0;
		SceneManager.LoadScene (level);
	}

	public void QuitRequest()
	{
		Debug.Log ("Quit requested");
		Application.Quit (); //Doesn't work unless built and run, not run in debug mode
	}

	public void LoadNextLevel()
	{
		Brick.breakableCount = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void BrickDestroyed()
	{
		if(Brick.breakableCount <= 0) //last brick destroyed
		{
			LoadNextLevel();
		}
	}
}
