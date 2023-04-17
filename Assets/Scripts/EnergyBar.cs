using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public Gradient gradient;
    public Image fill;


    // Start is called before the first frame update
    void Start()
    {
        // if energy has save, load saved energy
        if (PlayerPrefs.HasKey("CurrentEnergy"))
        {
            SetEnergy(PlayerPrefs.GetFloat("CurrentEnergy"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxEnergy(float energy)
    {
        energySlider.maxValue = energy;
        energySlider.value = energy;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(float energy)
    {
        energySlider.value = energy;
        fill.color = gradient.Evaluate(energySlider.normalizedValue);
    }
}
