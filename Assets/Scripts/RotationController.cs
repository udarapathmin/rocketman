﻿using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {
    
	// Use this for initialization
    public Transform target;

    void Awake() {
       
    }

    void Update()
    {
      
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 hitPoint = hit.point;

                Vector3 targetDir = hitPoint -transform.position;

                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

        } if (Input.GetMouseButtonUp(0)) {

           
            Debug.Log("Released left click.");
            Vector3 finalAngle = transform.localEulerAngles;
            Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
            playerBody.isKinematic = false;
            //playerBody.AddForce(new Vector2(1, 0) * 0.5f, ForceMode2D.Impulse);
            //target.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(finalAngle.z, finalAngle.z), new Vector2(transform.position.x, transform.position.y), ForceMode2D.Impulse);
            //Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
            //playerBody.isKinematic = false;

            playerBody.AddForceAtPosition(new Vector2(finalAngle.z, finalAngle.z), new Vector2(transform.position.x, transform.position.y), ForceMode2D.Impulse);
            
        }
    }
}

