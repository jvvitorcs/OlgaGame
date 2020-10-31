using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens : MonoBehaviour
{
    CanvasScript CScript;    
    public GameObject _EyeChoose;
    Objects _Objects;
    PopUpList PopUpScript;

    private void Start()
    {
        _Objects = FindObjectOfType<Objects>();
        PopUpScript = FindObjectOfType<PopUpList>();
        CScript = FindObjectOfType<CanvasScript>();        
    }

    private void OnMouseDown()
    {
        if (CScript._TutorialDone == true && !CScript.instrunctions && !PopUpScript._PopUpActive)
        {
            if (!_EyeChoose.activeSelf)
            {
                _EyeChoose.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1);
                _EyeChoose.SetActive(true);
            } else if (_EyeChoose.activeSelf)
            {
                _EyeChoose.SetActive(false);
            }            

            if (gameObject.tag == "bag")
            {
                _Objects.bag = true;               
            } else
            {
                _Objects.bag = false;
            }

            if (gameObject.tag == "draw")
            {
                _Objects.draw = true;
            }
            else
            {
                _Objects.draw = false;
            }

            if(gameObject.tag == "photo")
            {
                _Objects.photo = true;
            } else
            {
                _Objects.photo = false;
            }

           
           
        }
    }
}
