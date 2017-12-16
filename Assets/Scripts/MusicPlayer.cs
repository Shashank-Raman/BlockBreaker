using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{

	static MusicPlayer instance = null;

	void Awake()
	{
		Debug.Log ("Music player Awake " + GetInstanceID ());
        if (instance != null)
        {   //If the MusicPlayer has been created already
            Destroy(gameObject);
        }
		else
		{   //Create the MusicPlayer
			instance = this;
            GameObject.DontDestroyOnLoad (gameObject); //Ensures that the MusicPlayer is not destroyed automatically when loading a new scene.
		}
	}
}
