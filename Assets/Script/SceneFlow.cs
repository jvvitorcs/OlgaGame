using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
    }

    public void LoadGame(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    
}
