using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public VideoPlayer _VideoPlayer;
    public string _SceneName;
    public GameObject _Button;

    void Start()
    {
        _Button.SetActive(false);
        Debug.Log(_VideoPlayer);
    }


    void Update()
    {
        if (_VideoPlayer.time == 31)
        {
            _VideoPlayer.Pause();
            _Button.SetActive(true);
        }

    }

    public void LoadGame()
    {
        SceneManager.LoadScene(_SceneName);
    }
}
