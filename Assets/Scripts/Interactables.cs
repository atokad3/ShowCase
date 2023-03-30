using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public GameObject glow;
    public bool taskIsDone;

    public int energyCost;
    public EnergyBar energyBar;
    public int maxEnergy = 100;
    public int currentEnergy;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        taskIsDone = false;
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            Debug.Log("YES");
            taskIsDone = true;
            glow.SetActive(false);
            LoseEnergy(energyCost);
            player.GetComponent<Animator>().SetBool("gotDressed", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!taskIsDone)
        {
            glow.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        glow.SetActive(false);
    }

    private void LoseEnergy(int energyLoss)
    {
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
    }
}
