using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float totalWood;
    [SerializeField] private float _totalWater;
    [SerializeField] private float _totalCarrot;

    [SerializeField] private float _carrotLimit = 5f;
    [SerializeField] private float _waterLimit = 50f;
    [SerializeField] private float _woodLimit = 7f;

    public float TotalWood { get => totalWood; set => totalWood = value; }
    public float totalWater { get => _totalWater; set => _totalWater = value; }
    public float totalCarrot { get => _totalCarrot; set => _totalCarrot = value; }
    public float carrotLimit { get => _carrotLimit; set => _carrotLimit = value; }
    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GettingWater(float water)
    {
        if(_totalWater <= _waterLimit)
        {
            _totalWater += water;
        }
    }
}
