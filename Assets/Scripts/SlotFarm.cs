using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int digAmout;
    [SerializeField] private float currentWater;
    [SerializeField] private float requiredWater;

    private bool dugHole = false;
    [SerializeField] private bool waterDetected = false;
    [SerializeField] private bool onTheCarrot = false;

    private PlayerItems playerItems;

    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dugHole)
        {
            if (waterDetected)
            {
                currentWater += 0.01f; 
            }
            if(currentWater >= requiredWater)
            {
                _spriteRenderer.sprite = carrot;

                if (onTheCarrot && Input.GetKeyDown(KeyCode.E))
                {
                    playerItems.totalCarrot++;
                    _spriteRenderer.sprite = hole;
                    currentWater = 0f;

                }
            }
        }
       
        
    }

    private void OnHit()
    {
        digAmout--;

        if(digAmout <= 0)
        {
            _spriteRenderer.sprite = hole;
            dugHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Dig":
                if (digAmout > 0)
                {
                    OnHit();
                }
                break;
            case "Water":
                waterDetected = true;
                break;
            case "Player":
                onTheCarrot = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Water":
                waterDetected = false;
                break;
            case "Player":
                onTheCarrot = false;
                break;
        }
    }

}
