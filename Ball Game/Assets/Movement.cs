using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Rigidbody rb;

    public Material material;
    public float jumpPower = 5.0f;

    private Vector3 physics;

    public bool jump;
    public bool quick;
    public bool invert;

    public static float speed;

    public static float orignalSpeed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        orignalSpeed = speed;
        jump = false;
        quick = false;
        invert = false;
        physics = Physics.gravity;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            jump = !jump;
            quick = false;
            invert = false;

            if (jump)
                material.SetColor("_red", Color.red);
            else
                material.SetColor("_white", Color.white);

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            quick = !quick;
            invert = false;
            jump = false;

            if (quick)
            {
                setSpeed((float)(Movement.getSpeed()) * 2.0f);
                material.SetColor("_green", Color.green);
            }
            else
                material.SetColor("_white", Color.white);

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            invert = !invert;
            quick = false;
            jump = false;

            if (quick)
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

        if (!quick)
            setSpeed(getOriginalSpeed());
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
