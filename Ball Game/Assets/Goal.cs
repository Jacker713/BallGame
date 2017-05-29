using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public Collider player;
    public bool collided =  false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {

        if (other == player)
        {
            collided = true;
            Application.Quit();
        }
    }
}
