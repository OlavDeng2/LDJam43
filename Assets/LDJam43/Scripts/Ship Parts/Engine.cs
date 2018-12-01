using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public int health = 4;
    GameObject ship = null;

    // Use this for initialization
    void Start()
    {
        ship = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
