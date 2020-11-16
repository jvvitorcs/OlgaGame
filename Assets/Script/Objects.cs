using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    CharacterScript _character;
    public PopUpList PopUpScript;
    CanvasScript CScript;
    public bool bag, draw, photo;    
    public GameObject _EyeChooseClose;
    public GameObject[] _objects;

    //Referencia do personagem, do canvas e das opções de olhar e segurar
    void Start()
    {
        _character = FindObjectOfType<CharacterScript>();
        CScript = FindObjectOfType<CanvasScript>();
        PopUpScript = FindObjectOfType<PopUpList>();
    }


    public void Pick()
    {
        _EyeChooseClose.SetActive(false);

        if (bag)
        {           
            _character._bagBool = true;
            CScript.MissionCheck(0);            
            _objects[0].SetActive(false);
            CScript.imageBag.SetActive(true);
            CScript.buttonNextScene.enabled = true;
        }

        if (photo)
        {
            Debug.Log("Não preciso levar isto.");
        }

        if (_character._bagBool == true)
        {
            if (draw)
            {                
                _objects[1].SetActive(false);
            }            
        }

    }

    public void Look()
    {
        if (photo)
        {
            PopUpScript.UpdateImages(0, "Eu e Danica");
        }

        if (draw)
        {
            PopUpScript.UpdateImages(1, "...");
        }

    }

    public void CloseOptions()
    {
        _EyeChooseClose.SetActive(false);
    }
}