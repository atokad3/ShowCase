using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public GameObject glow;
    public bool taskIsDone;
    public float energyCost;

    public EnergyBar energyBar;
    public int currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        taskIsDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            Debug.Log("YES");
            taskIsDone = true;
            glow.SetActive(false);
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
}
