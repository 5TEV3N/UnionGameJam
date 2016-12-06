using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
