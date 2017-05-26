using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject playerNode;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - playerNode.transform.position;
	}
	


    // Update is called once per frame
	void LateUpdate () {

        transform.position = playerNode.transform.position + offset;

        transform.LookAt(playerNode.transform);
    }
}
