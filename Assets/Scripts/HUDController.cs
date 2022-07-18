using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image waterUIBar;
    
    [SerializeField] private Image wateringUIIcon;
    [SerializeField] private Image axeUIIcon;
    [SerializeField] private Image digUIIcon;

    private PlayerItems playerItems;
    private PlayerController playerController;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        playerController = FindObjectOfType<PlayerController>();

    }
    void Start()
    {
       woodUIBar.fillAmount = 0f;
       carrotUIBar.fillAmount = 0f;
       waterUIBar.fillAmount = 0f; 

    }

    // Update is called once per frame
    void Update()
    {
        SelectedTools();
        FillAmoutUpdateItems();
    }

    private void FillAmoutUpdateItems()
    {
        waterUIBar.fillAmount = playerItems.totalWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.TotalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.totalCarrot / playerItems.carrotLimit;
    }

    private void SelectedTools()
    {
        if (playerController.HandlingObj == 1)
        {
            axeUIIcon.color = new Color(axeUIIcon.color.r, axeUIIcon.color.g, axeUIIcon.color.b, 1f);
        }
        else
        {
            axeUIIcon.color = new Color(axeUIIcon.color.r, axeUIIcon.color.g, axeUIIcon.color.b, 0.5f);
        }

        if (playerController.HandlingObj == 2)
        {
            digUIIcon.color = new Color(digUIIcon.color.r, digUIIcon.color.g, digUIIcon.color.b, 1f);
        }
        else
        {
            digUIIcon.color = new Color(digUIIcon.color.r, digUIIcon.color.g, digUIIcon.color.b, 0.5f);
        }

        if (playerController.HandlingObj == 3)
        {
            wateringUIIcon.color = new Color(wateringUIIcon.color.r, wateringUIIcon.color.g, wateringUIIcon.color.b, 1f);
        }
        else
        {
            wateringUIIcon.color = new Color(wateringUIIcon.color.r, wateringUIIcon.color.g, wateringUIIcon.color.b, 0.5f);
        }

    }

}
