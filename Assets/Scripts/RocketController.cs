using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {
    public float jetpackForce = 75.0f;
   
    float fuel=5;
    float maxFuel =5;
    Rect fuelRect;
    Texture2D fuelTexture;
    bool fuelstat =true;
    bool jetpackActive = false;
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
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "gas")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            GameObject mn = GameObject.Find("man");
            Rigidbody2D rg2 = mn.GetComponent<Rigidbody2D>();
            Vector3 dir = Quaternion.AngleAxis(0, Vector3.up) * (Vector3.up);
            rg2.AddForce(dir * 10.0f, ForceMode2D.Impulse);
            Debug.Log("gas");
            fuel = fuel + 0.15f;

            if (fuel > maxFuel) {
                fuel = maxFuel;
            }

            Destroy(col.gameObject);
        }
    }

    //public void Button_Click_D() {
    //    Debug.Log("Pressed gas button.");
    //    jetpackActive = true;
    //}

    //public void Button_Click_U()
    //{
    //    Debug.Log("released gas button.");
    //    jetpackActive = false;
    //}

    public void update_score_withtime() {

        float score = Time.deltaTime;
    
    }
}
