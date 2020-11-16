using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpList : MonoBehaviour
{
    public Sprite[] _Images;
    public Image _ActualImage, _BackugroundImage, _TextPanelImage;
    public GameObject _setaPopupObject;
    public Text _textPopUp;
    public bool _PopUpActive, _SpecificScene;
    public CanvasScript _CanvasScript;


    public void Awake()
    {
        CloseImage();
    }

    private void Start()
    {
        _CanvasScript = FindObjectOfType<CanvasScript>();
    }

    public void UpdateImages(int ArrayValue, string Text)
    {
        _textPopUp.text = "''" + Text + "''";
        _ActualImage.sprite = _Images[ArrayValue];
        _ActualImage.enabled = true;
        _BackugroundImage.enabled = true;
        _TextPanelImage.enabled = true;
        _setaPopupObject.SetActive(true);
        _textPopUp.enabled = true;
        _PopUpActive = true;
    }

    public void CloseImage()
    {
        _ActualImage.enabled = false;
        _BackugroundImage.enabled = false;

        _TextPanelImage.enabled = false;
        _setaPopupObject.SetActive(false);
        _textPopUp.enabled = false;
        if (_SpecificScene)
        {
            _CanvasScript.buttonNextScene.enabled = true;
        }
        _PopUpActive = false;
        _CanvasScript.ActiveButtonsUI();
    }

    public void Dialogue()
    {
        Debug.Log("Dialogue");
        _TextPanelImage.enabled = true;
        _setaPopupObject.SetActive(true);
        _textPopUp.enabled = true;
        _SpecificScene = true;
        _PopUpActive = true;

    }
}
