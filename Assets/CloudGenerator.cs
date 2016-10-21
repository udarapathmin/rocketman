using UnityEngine;
using System.Collections;

public class CloudGenerator : MonoBehaviour {

    public GameObject cloud;
    public Vector2 velocity = new Vector2(-4, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = velocity;
        Destroy(cloud, 5);
	}
}
