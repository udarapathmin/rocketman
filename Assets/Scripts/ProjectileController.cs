using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    public float rocketSpeed = 0.5f;
    Rigidbody2D myRB;
	// Use this for initialization
	void Awake () {
        myRB = GetComponent<Rigidbody2D>();

        myRB.AddForce(new Vector2(1,0)*rocketSpeed,ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

     
	
	}
}
