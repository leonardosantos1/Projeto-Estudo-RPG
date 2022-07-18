using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float initialSpeed;
    
    private bool _isRunning = false;
    private bool _isRolling = false;
    private bool _isCutting = false;
    private bool _isDigging = false;
    private bool _isWatering = false;

    private PlayerItems playerItems;

    private int handlingObj = 1;


    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }


    public Rigidbody2D rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public int HandlingObj { get => handlingObj; set => handlingObj = value; }

    void Start()
    {
        initialSpeed = speed;
        _rigidbody = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchTools();
        OnRun();
        OnRoll();
        OnCutting();
        OnDigging();
        OnWatering();
    }

    private void FixedUpdate()
    {
        OnMove();
        CharacterFlip();
    }

    private void OnMove()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
    }

    private void CharacterFlip()
    {
        if (_rigidbody.velocity.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);

        }

        if (_rigidbody.velocity.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void OnCutting()
    {
        if(HandlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isCutting = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _isCutting = false;
            }
        }
        
    }

    private void OnDigging()
    {
        if(HandlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDigging = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _isDigging = false;
            }
        }
        
    }

    private void OnWatering()
    {
        if (HandlingObj == 3 && playerItems.totalWater > 0 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isWatering = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _isWatering = false;
            }

            if (_isWatering)
            {
                playerItems.totalWater -= 0.01f;

            }

        }
        else
        {
            _isWatering = false;
        }

    }

    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8f;
            _isRunning = true;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    private void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            speed = 10f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = initialSpeed;
        }
    }

    private void SwitchTools()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandlingObj = 1;
            _isDigging = false;
            _isWatering = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandlingObj = 2;
            _isCutting = false;
            _isWatering = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandlingObj = 3;
            _isDigging = false;
            _isCutting = false;
        }
    }
}
