using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taco : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfxTaco;
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

        Vector2 spawnLocation = new Vector2(Random.Range(-2.6f, 2.6f), Random.Range(-2.3f, 2.3f));

        Instantiate(Ingredient, spawnLocation, Ingredient.transform.rotation);
        
        
    }

    public void TacoSound()
    {
        src.clip = sfxTaco;
        src.Play();
        Debug.Log("tacosound");
    }

}
