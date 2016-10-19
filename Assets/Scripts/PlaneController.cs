using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
    private Vector3 pos1 = new Vector3(-4.5f, 12.3f, 19.23f);
    private Vector3 pos2 = new Vector3(532f, 12.3f, 19.23f);
    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}

    

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * 0.01f * speed, 10f));
    }
}
