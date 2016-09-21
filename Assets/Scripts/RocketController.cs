using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {
    public float jetpackForce = 75.0f;
    float fuel=5;
    float maxFuel =5;
    Rect fuelRect;
    Texture2D fuelTexture;
    bool fuelstat =true;
	void Start () {
        fuelRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
        fuelTexture = new Texture2D(1,1);
        fuelTexture.SetPixel(0, 0, Color.red);
        fuelTexture.Apply();
        
	}

    void FixedUpdate()
    {
        
        bool jetpackActive = Input.GetKey("left shift");
        GameObject man = GameObject.Find("man");
        Rigidbody2D rg = man.GetComponent<Rigidbody2D>();
        
        
        if (jetpackActive)
        {
            Debug.Log("Pressed left shift.");
            if(fuelstat){
            rg.AddForce(Vector3.up * jetpackForce);

            fuel -= Time.deltaTime;
           
                if (fuel < 0) {
                fuel = 0;
                jetpackActive = false;
                fuelstat = false;
                }
            }
     
        }
        
        
    }

    void OnGUI() {

        float ratio = fuel / maxFuel;
        float rectWidth = ratio * Screen.width / 3;
        fuelRect.width = rectWidth;
        GUI.DrawTexture(fuelRect,fuelTexture);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject man = GameObject.Find("man");
        Rigidbody2D rg = man.GetComponent<Rigidbody2D>();
        
    }
}
