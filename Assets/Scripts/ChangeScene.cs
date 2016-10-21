using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void playGame(string sceanName) {
        
        SceneManager.LoadScene(sceanName);
    }
}
