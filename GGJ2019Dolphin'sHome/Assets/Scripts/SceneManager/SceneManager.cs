using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public static void LoadIntroducao()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public static void LoadTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public static void LoadFase1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public static void LoadConversaSobreLar1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public static void LoadFase2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public static void LoadCréditos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    
    public static void CloseGame()
    {
        Application.Quit();
    }

    public static void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
