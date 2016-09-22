using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {
    
	// Use this for initialization
    public Transform target;
    private Vector3 myRotation;
    void Awake() {
       
    }

    void Update()
    {
      
        if (Input.GetMouseButton(1))
        {
            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 100))
            {
                myRotation = gameObject.transform.rotation.eulerAngles;
                Vector3 hitPoint = hit.point;
                Vector3 targetDir = hitPoint -transform.position;

                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                myRotation.z = Mathf.Clamp(angle, 20, 50);
                transform.rotation = Quaternion.Euler(myRotation);
            }

        } if (Input.GetMouseButtonUp(1)) {

           
            Debug.Log("Released left click.");
            
            Vector3 finalAngle = transform.localEulerAngles;
            finalAngle.z = Mathf.Clamp(finalAngle.z, 20, 50); ;
            Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
            playerBody.isKinematic = false;
            
            playerBody.AddForceAtPosition(new Vector2(finalAngle.z, finalAngle.z), new Vector2(transform.position.x, transform.position.y), ForceMode2D.Impulse);

           
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "background")  // or if(gameObject.CompareTag("YourWallTag"))
        {

            GameObject background = GameObject.Find("background");
            Rigidbody2D rg = background.GetComponent<Rigidbody2D>();
            rg.velocity = Vector3.zero;
        }
    }
}


