using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Rigidbody rb;

    public static float speed;

    public static float orignalSpeed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        orignalSpeed = speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed, ForceMode.Force);
	}

    public static void setSpeed(float s)
    {
        speed = s;
    }

    public static float getSpeed()
    {
        return speed;
    }

    public static float getOriginalSpeed()
    {
        return orignalSpeed;
    }
}
