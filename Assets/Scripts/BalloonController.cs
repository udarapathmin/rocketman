using UnityEngine;
using System.Collections;

public class BalloonController : MonoBehaviour {
public float velocidadMax;
     
     public float xMax;
     public float yMax;
     public float xMin;
     public float yMin;
         
     private float x;
     private float y;
     private float Startx;
     private float Starty;
     private float tiempo;
     private float angulo;
 
     // Use this for initialization
     void Start () {
 
 
         x = Random.Range(-velocidadMax, velocidadMax);
         y = Random.Range(-velocidadMax, velocidadMax);

         Startx = transform.localPosition.x;
         Starty = transform.localPosition.y;

         //angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
         transform.localRotation = Quaternion.Euler( 0, angulo, 0);
     }
     
     // Update is called once per frame
     void Update()
     {

         tiempo += Time.deltaTime;

         if (transform.localPosition.x - Startx > xMax)
         {
             x = Random.Range(-velocidadMax, 0.0f);
             //angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             //transform.localRotation = Quaternion.Euler(0, angulo, 0);
             tiempo = 0.0f;
         }
         if (transform.localPosition.x -Startx< xMin)
         {
             x = Random.Range(0.0f, velocidadMax);
             //angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             //transform.localRotation = Quaternion.Euler(0, angulo, 0);
             tiempo = 0.0f;
         }
         if (transform.localPosition.y - Starty > yMax)
         {
             y = Random.Range(-velocidadMax, 0.0f);
             //angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             //transform.localRotation = Quaternion.Euler(0, angulo, 0);
             tiempo = 0.0f;
         }
         if (transform.localPosition.y - Starty< yMin)
         {
             y = Random.Range(0.0f, velocidadMax);
             //angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             //transform.localRotation = Quaternion.Euler(0, angulo, 0);
             tiempo = 0.0f;
         }


         if (tiempo > 1.0f)
         {
             x = Random.Range(-velocidadMax, velocidadMax);
             y = Random.Range(-velocidadMax, velocidadMax);
             //angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             //transform.localRotation = Quaternion.Euler(0, angulo, 0);
             tiempo = 0.0f;
         }

         transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y+y);
         //transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition,velocidadMax*Time.deltaTime);

     }
}
