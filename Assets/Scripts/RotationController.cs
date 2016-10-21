using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationController : MonoBehaviour {
    //Score
    private int score = 0;
    private int objectscores = 0;
    public Text scoreText;
    private float startTime;

	// Use this for initialization
    public Transform target;
    private Vector3 myRotation;
    private bool updating = true;
    private bool onPlay = true;

    private int finalscore = 0;

    public float rotationDegreesPerSecond = 45f;
    public float rotationDegreesAmount = 90f;
    private float totalRotation = 0;
    //private float degreesPerSecond = 0.5f;

    //Game objectives
    private int balooncrashcount = 0;
    public Text gameInst;
    public GameObject gametext;

    // Game Over
    public GameManager Manager;


    void Start()
    {
        StartCoroutine(WaitAndDissable());
    }

    void Awake() {
       
    }

    void Update()
    {

        if (updating)
        {
            
            if (Input.GetMouseButton(1))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 100))
                {
                    myRotation = gameObject.transform.rotation.eulerAngles;
                    Vector3 hitPoint = hit.point;
                    Vector3 targetDir = hitPoint - transform.position;

                    float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                    myRotation.z = Mathf.Clamp(angle, 0, 50);
                    transform.rotation = Quaternion.Euler(myRotation);
                }


            }
            if (Input.GetMouseButtonUp(1))
            {


                Debug.Log("Released left click.");

                Vector3 finalAngle = transform.localEulerAngles;
                finalAngle.z = Mathf.Clamp(finalAngle.z, 20, 50);
                Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
                playerBody.isKinematic = false;
                playerBody.constraints = RigidbodyConstraints2D.FreezeRotation;

                playerBody.AddForceAtPosition(new Vector2(finalAngle.z, finalAngle.z), new Vector2(transform.position.x, transform.position.y), ForceMode2D.Impulse);

                this.updating = false;
                startTime = Time.time;
                
            }
        }

        if (!updating && onPlay)
        {
            score = (int)(Time.time - startTime);
            updateScore();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            
            GameObject man = GameObject.Find("man");
            Rigidbody2D rg = man.GetComponent<Rigidbody2D>();
            rg.constraints = RigidbodyConstraints2D.FreezeAll;
            Time.timeScale = 0;
            Debug.Log("ddddd");
            onPlay = false;

        }
    }

    void SwingOpen()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 10, Space.Self);
    }

    public void updateScore()
    {
        scoreText.text = "Score : " + (score + objectscores).ToString();
    }

    IEnumerator WaitAndDissable()
    {
        float time = 5f;
        yield return new WaitForSeconds(time);

        gametext.SetActive(false);
    }

    public void increase_baloon_count()
    {
        {
            balooncrashcount++;
            if (balooncrashcount == 3)
            {
                Manager.GameWin();
                updating = true;
                scoreText.text = "Score : " + (score + objectscores).ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "balloon")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            GameObject mn = GameObject.Find("man");
            Rigidbody2D rg2 = mn.GetComponent<Rigidbody2D>();
            Vector3 dir = Quaternion.AngleAxis(0, Vector3.up) * (Vector3.up);
            rg2.AddForce(dir * 30.0f, ForceMode2D.Impulse);
            //Debug.Log("ddddd");
            objectscores = objectscores + 50;

            Destroy(col.gameObject);

            increase_baloon_count();
        }
        if (col.gameObject.tag == "storm")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            GameObject mn = GameObject.Find("man");
            Rigidbody2D rg2 = mn.GetComponent<Rigidbody2D>();
            Vector3 dir = Quaternion.AngleAxis(0, Vector3.up) * (Vector3.up);
            rg2.AddForce(dir * 75.0f, ForceMode2D.Impulse);

            objectscores = objectscores - 30;

            if(objectscores<0){
                objectscores = 0;
            
            }

            //Debug.Log("ddddd");
        }

        if (col.gameObject.tag == "plane")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            GameObject mn = GameObject.Find("man");
            Rigidbody2D rg2 = mn.GetComponent<Rigidbody2D>();
            Vector3 dir = Quaternion.AngleAxis(0, Vector3.up) * (Vector3.up);
            rg2.AddForce(dir * 90.0f, ForceMode2D.Impulse);

            objectscores = objectscores + 1000;

          

            //Debug.Log("ddddd");
        }

        if (col.gameObject.tag == "ground")  // or if(gameObject.CompareTag("YourWallTag"))
        {

            Manager.GameOver();
            updating = true;
            finalscore = score;
            Debug.Log("ground");
        }
    }

}


