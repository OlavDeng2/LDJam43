using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource music;
    public static MusicManager musicManager;


	// Use this for initialization
	void Awake () {
        if(musicManager == null)
        {
            musicManager = this;
        }
        else if(musicManager != this)
        {
            Destroy(this.gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(this.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
