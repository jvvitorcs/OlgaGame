using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpList : MonoBehaviour
{
    public Sprite[] _Images;
    public Image _ActualImage, _BackGround, _TextPanel;
    public GameObject _setaPopup;
    public Text _textPopUp;
    public bool _PopUpActive;

    public void Start()
    {        
        CloseImage();
    }

    public void UpdateImages(int ArrayValue, string Text)
    {
        _textPopUp.text = "''" + Text + "''";
        _ActualImage.sprite = _Images[ArrayValue];
        _ActualImage.enabled = true;
        _BackGround.enabled = true;
        _TextPanel.enabled = true;
        _setaPopup.SetActive(true);
        _textPopUp.enabled = true;
        _PopUpActive = true;
    }

    public void CloseImage()
    {
        _ActualImage.enabled = false;
        _BackGround.enabled = false;
        _TextPanel.enabled = false;
        _setaPopup.SetActive(false);
        _textPopUp.enabled = false;
        _PopUpActive = false;
    }
}
