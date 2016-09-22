using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour {

	public void playGame()
    {
        SceneManager.LoadScene("Start_scean");
    }
}
