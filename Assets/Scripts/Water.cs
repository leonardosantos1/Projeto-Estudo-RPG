using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool detectedPlayer = false;
    [SerializeField] private PlayerItems player;
    [SerializeField] private float quantityWater = 5f;
    [SerializeField] private bool coletandoAgua = false;

    public bool ColetandoAgua { get => coletandoAgua; set => coletandoAgua = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectedPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.GettingWater(quantityWater);
            coletandoAgua = true;
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                detectedPlayer = true;
                break;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                detectedPlayer = false;
                break;
        }

    }
}
