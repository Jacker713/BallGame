using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyChanger : MonoBehaviour {

    public GameObject player;
    public Rigidbody rb;
    public Material material;
    public float jumpPower =  5.0f;

    public bool jump;
    public bool speed;
    public bool invert;

	// Use this for initialization
	void Start () {
        jump = false;
        speed = false;
        invert = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            jump = !jump;
            speed = false;
            invert = false;

            if (jump)
                material.SetColor("_red", Color.red);
            else
                material.SetColor("_white", Color.white);

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            speed = !speed;
            invert = false;
            jump = false;

            if (speed)
            {
                Movement.setSpeed((float) (Movement.getSpeed()) * 2.0f);
                material.SetColor("_green", Color.green);
            }
            else
                material.SetColor("_white", Color.white);

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            invert = !invert;
            speed = false;
            jump = false;

            if (speed)
                material.SetColor("_blue", Color.blue);
            else
                material.SetColor("_white", Color.white);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump)
                rb.AddForce(new Vector3(0, jumpPower, 0));
            else if (invert)
                Physics.gravity *= -1;
        }

        if (!speed)
            Movement.setSpeed(Movement.getOriginalSpeed());


    }
}
