using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    public Transform target;
    public float smoothing;

    Vector3 offset;
    float LowY;
	// Use this for initialization
	void Start () {


        offset = transform.position - target.position;
        LowY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, 10);

        if (transform.position.y < LowY) transform.position = new Vector3(transform.position.x, LowY, transform.position.z);
	}
}
