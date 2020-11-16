using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public Sprite[] arrayInstrunction, arrayDialogues;
    public Image[] arrayMissions;
    Scene ActualScene;
    int SceneIndex;

    [Header("UI")]
    public Image imageInstrunction, imageDialogue;
    public Image imageSeta;
    public GameObject imageMissions;
    public GameObject imageArrow;
    public GameObject imageBag, buttonDialogues, buttonChoices;
    public int imageID, _dialogueID;
    public bool instrunctions, _TutorialDone, _TutorialPartTwo, _DialogueBool;
    public Text _Dialogues;

    [Header("Inputs")]
    public Button buttonInstruction;
    public Button buttonMissions;
    public Button buttonBag;
    public Button buttonNextScene;


    private PopUpList PopUpListScript;
    CharacterScript PlayerScript;

    bool FirstScene, SecondScene, ThirdScene;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerScript = FindObjectOfType<CharacterScript>();
        PopUpListScript = FindObjectOfType<PopUpList>();

        imageMissions.SetActive(false);
        imageInstrunction.enabled = false;
        imageSeta.enabled = false;
        imageArrow.SetActive(false);

        instrunctions = false;


    }

    private void Update()
    {
        ActualScene = SceneManager.GetActiveScene();
        SceneIndex = ActualScene.buildIndex;
        ScenesBegin();
        Debug.Log("cena");

        if(SceneIndex == 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void ScenesBegin()
    {
        if (SceneIndex == 2 && !FirstScene)
        {
            DesactiveButtonsUI();
            StartCoroutine(Tutorial());
            FirstScene = true;

        }
        else if (SceneIndex == 3 && !SecondScene)
        {
            DesactiveButtonsUI();
            SceneTwoStart();
            SecondScene = true;
        }
        else if (SceneIndex == 4 && !ThirdScene)
        {
            DesactiveButtonsUI();
            SceneThreeStart();
            ThirdScene = true;
        }
        else if (SceneIndex == 5)
        {
            imageInstrunction.enabled = false;
            DesactiveButtonsUI();
        }
    }



    public void ActiveButtonsUI()
    {
        buttonInstruction.enabled = true;
        buttonMissions.enabled = true;
        buttonBag.enabled = true;
    }

    void DesactiveButtonsUI()
    {
        buttonInstruction.enabled = false;
        buttonMissions.enabled = false;
        buttonNextScene.enabled = false;
        buttonBag.enabled = false;
        buttonDialogues.SetActive(false);
        buttonChoices.SetActive(false);
        if (SceneIndex == 2)
        {
            imageBag.SetActive(false);
        }
    }

    IEnumerator Tutorial()
    {

        if (_TutorialDone == false)
        {
            if (_TutorialPartTwo == false)
            {
                yield return new WaitForSeconds(2f);
                imageArrow.SetActive(true);
                imageArrow.transform.position = new Vector2(buttonInstruction.transform.position.x + 0.3f, buttonInstruction.transform.position.y - 0.5f);
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



    public void SceneTwoStart()
    {
        _Dialogues.text = "*Crack*";
        PopUpListScript.Dialogue();
        //PopUpListScript._SpecificScene = false;
        //PlayerScript._bagBool = true;
    }

    public void SceneThreeStart()
    {
        if (_dialogueID >= 0 && _dialogueID < 7)
        {

            buttonDialogues.SetActive(true);
            imageDialogue.enabled = true;
            _DialogueBool = true;
            imageDialogue.sprite = arrayDialogues[_dialogueID];
            _dialogueID++;
            if (_dialogueID == arrayDialogues.Length)
            {
                buttonChoices.SetActive(true);
            }
        }

    }

}
