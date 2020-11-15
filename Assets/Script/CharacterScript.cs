using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public float _speed;
    int _health = 5;
    Rigidbody2D _rb;
    Animator _anim;
    CanvasScript _canvasScript;
    PopUpList PopUpListScript;
    public bool _bagBool;
    Scene ActualScene;
    int SceneIndex;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PopUpListScript = FindObjectOfType<PopUpList>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _canvasScript = FindObjectOfType<CanvasScript>();
        
           
    }

    void Update()
    {
        ActualScene = SceneManager.GetActiveScene();
        SceneIndex = ActualScene.buildIndex;
        if (SceneIndex == 5)
        {
            Destroy(this.gameObject);
        }
        Move();
        FlipSprite();

        if (_bagBool == true)
        {
            _anim.SetBool("Bag", true);
        }
    }

    void Move()
    {

        if (!_canvasScript.instrunctions && _canvasScript._TutorialDone == true && !PopUpListScript._PopUpActive)
        {
            
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * _speed;
            _rb.velocity = new Vector2(moveBy, _rb.velocity.y);
            bool playerHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon;
            _anim.SetBool("Run", playerHorizontalSpeed);

        }
    }

    private void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rb.velocity.x), 1f);
        }
    }
}
