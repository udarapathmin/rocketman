using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
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

        }
    }
}
