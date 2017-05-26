using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNode : MonoBehaviour {

    public GameObject player;

    public float rotateSpeed = 5;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);

        Quaternion rotation = Quaternion.Euler(transform.eulerAngles.z, transform.eulerAngles.x + horizontal, transform.eulerAngles.y);
        transform.position = player.transform.position;

        transform.rotation = rotation;
    }
}
