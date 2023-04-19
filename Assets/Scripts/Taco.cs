using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taco : MonoBehaviour
{
    
    public GameObject Ingredient;
    public GameObject introText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIngredient()
    {
        Debug.Log("oioioiioioioiooioioiioiooiiooioi JOSKE");

        Vector2 spawnLocation = new Vector2(Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f));

        
        if (!introText.activeInHierarchy)
        {
            Instantiate(Ingredient, spawnLocation, Ingredient.transform.rotation);
        }
        
    }

}
