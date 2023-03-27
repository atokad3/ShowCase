using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxEnergy(int energy)
    {
        energySlider.maxValue = energy;
        energySlider.value = energy;

    }

    public void SetEnergy(int energy)
    {
        energySlider.value = energy;
    }
}
