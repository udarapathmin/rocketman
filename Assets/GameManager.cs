using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    // Score Baloons
    //public Transform ScoreBaloonPosition;
    public GameObject ScoreBaloon;
    // Cloud
    public GameObject Cloud;

    // Tornados
    //public Transform TornadoPosition;
    //public GameObject Tornado;

    public GameObject GameOverObj;
    public GameObject GameWonObj;

	// Use this for initialization
	void Start () {
        float randomTime = Random.RandomRange(3f, 5f);
        StartCoroutine(WaitAndGenerate(randomTime));
        Player.GetComponent<RotationController>().Manager = this;
        GameOverObj.SetActive(false);
        GameWonObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator WaitAndGenerate(float waitTime)
    {
        float randomTime = Random.RandomRange(1f, 3f);
        yield return new WaitForSeconds(randomTime);

        // Baloon
        Vector3 newposition = new Vector3(Random.RandomRange(Player.transform.position.x + 10, Player.transform.position.x + 20), Random.RandomRange(Player.transform.position.y - 10, Player.transform.position.y + 10), Player.transform.position.z);
        GameObject a = Instantiate(ScoreBaloon, newposition, Quaternion.identity) as GameObject;
        //a.GetComponent<LifeTaker>().Manager = this;
        Destroy(a, 20);

        // Clouds
        Vector3 cloudpos = new Vector3(Random.RandomRange(Player.transform.position.x - 5, Player.transform.position.x + 10), Random.RandomRange(Player.transform.position.y - 3, Player.transform.position.y + 3), Player.transform.position.z);
        GameObject clouds = Instantiate(Cloud, cloudpos, Quaternion.identity) as GameObject;

        Vector3 cloudpos2 = new Vector3(Random.RandomRange(Player.transform.position.x + 1, Player.transform.position.x + 5), Random.RandomRange(Player.transform.position.y - 10, Player.transform.position.y + 10), Player.transform.position.z);
        GameObject clouds2 = Instantiate(Cloud, cloudpos2, Quaternion.identity) as GameObject;
        //a.GetComponent<LifeTaker>().Manager = this;

        StartCoroutine(WaitAndGenerate(randomTime));
    }

    public void GameOver()
    {
        GameOverObj.SetActive(true);
    }

    public void GameWin()
    {
        GameWonObj.SetActive(true);
    }
}
