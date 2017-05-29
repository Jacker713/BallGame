using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Rigidbody rb;

    public Material BaseMaterial;
    public Material Red;
    public Material Blue;
    public Material Green;

    public float speedIncrease = 2.0f;

    public float jumpPower = 5.0f;

    private Vector3 physics;

    public bool jump;
    public bool quick;
    public bool invert;

    public float speed;

    public static float originalSpeed;

    public Renderer rend;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
         originalSpeed = speed;
        jump = false;
        quick = false;
        invert = false;
        physics = Physics.gravity;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }


    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.R))
        {
            jump = !jump;
            quick = false;
            invert = false;

            if (jump)
                rend.sharedMaterial = Red;
            else
                rend.sharedMaterial = BaseMaterial;
        }

        //speed
        if (Input.GetKeyDown(KeyCode.B))
        {
            quick = !quick;
            invert = false;
            jump = false;

            if (quick)
            {
                speed = ((float)(speed) * speedIncrease);
                rend.sharedMaterial = Blue;
            }
            else
                rend.sharedMaterial = BaseMaterial;

        }

        //gravity
        if (Input.GetKeyDown(KeyCode.G))
        {
            invert = !invert;
            quick = false;
            jump = false;

            if (invert)
                rend.sharedMaterial = Green;
            else
                rend.sharedMaterial = BaseMaterial;

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump)
                rb.AddForce(Vector3.up * jumpPower);
            else if (invert)
                Physics.gravity *= -1;
        }

        if (!quick)
            speed = originalSpeed;
        if (!invert)
            Physics.gravity = physics;


    }


    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed, ForceMode.Force);
	}

}
