using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Sprite[] arrayInstrunction;
    public Image[] arrayMissions;

    [Header("UI")]
    public Image imageInstrunction;
    public Image imageSeta;
    public GameObject imageMissions;
    public GameObject imageArrow;
    public GameObject imageBag;
    public int imageID;
    public bool instrunctions, _TutorialDone, _TutorialPartTwo;

    [Header("Inputs")]
    public Button buttonInstruction;
    public Button buttonMissions;
    public Button buttonBag;

    public bool x = true;

    void Start()
    {
        buttonInstruction.enabled = false;
        buttonMissions.enabled = false;
        buttonBag.enabled = false;
        imageInstrunction.enabled = false;
        imageSeta.enabled = false;
        imageMissions.SetActive(false);
        imageArrow.SetActive(false);
        imageBag.SetActive(false);

        instrunctions = false;

        StartCoroutine(Tutorial());
    }

    void Update()
    {
       
    }

    IEnumerator Tutorial()
    {
        
        if (_TutorialDone == false)
        {
            if (_TutorialPartTwo == false)
            {
                yield return new WaitForSeconds(2f);
                imageArrow.SetActive(true);
                imageArrow.transform.position = new Vector2(buttonInstruction.transform.position.x + 0.4f, buttonInstruction.transform.position.y - 0.8f);
                buttonInstruction.enabled = true;
            }
            else
            {
                Debug.Log("Segunda parte");
                imageArrow.SetActive(true);
                imageArrow.transform.position = new Vector2(buttonMissions.transform.position.x + 0.4f, buttonMissions.transform.position.y - 0.9f);
                buttonInstruction.enabled = false;
                _TutorialDone = true;
            }
            
        }
    }

    public void ImageInstructionsOn()
    {
        imageArrow.SetActive(false);
        if (imageID == arrayInstrunction.Length)
        {
            imageInstrunction.enabled = false;
            imageSeta.enabled = false;
            instrunctions = false;
            buttonMissions.enabled = true;
            buttonInstruction.enabled = true;
            imageID = 0;
        }
        else if (imageID >= 0)
        {
            buttonMissions.enabled = false;
            imageInstrunction.enabled = true;
            imageSeta.enabled = true;
            instrunctions = true;
            imageInstrunction.sprite = arrayInstrunction[imageID];
            imageID++;

            if (imageID == 2 && _TutorialDone == false)
            {
                Debug.Log("Barra de esperança muda");
            }
            else if (imageID == 3 && _TutorialDone == false)
            {
                Debug.Log("Barra de esperança para");
                _TutorialPartTwo = true;
                StartCoroutine(Tutorial());
            }
        }

    }

    public void MissionList()
    {
        if (imageMissions.activeSelf == false)
        {
            buttonInstruction.enabled = false;
            imageMissions.SetActive(true);
        }
        else
        {
            buttonInstruction.enabled = true;
            imageMissions.SetActive(false);
        }

    }

    public void MissionCheck(int IDMission)
    {
        arrayMissions[IDMission].enabled = true;
    }

}
