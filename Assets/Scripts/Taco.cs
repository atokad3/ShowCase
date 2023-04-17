using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taco : MonoBehaviour
{
    
    public GameObject Ingredient;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddIngredient()
    {


        Vector2 spawnLocation = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

        //Instantiate(Ingredient, spawnLocation, .gameObject.transform.rotation);
    }
}
