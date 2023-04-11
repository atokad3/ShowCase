using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int maxEnergy = 100;
    public int currentEnergy;
    public float speed = 3;
    public GameObject checklist;
    public Animator anim;
    public GameObject PauseGame;
    public EnergyBar energyBar;
    public string day;
    public int time;
    public bool doorClicked;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.activeInHierarchy)
        {
            PlayerMovement();
            Checklist();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoseEnergy(10);
            }
        }
        Pause();
    }

    /*
     * Each day, player chooses activity
     * Each activity costs energy
     * When daily energy remaining minus starting energy < 0, sleep
     * Rinse, repeat
     */
    private void LoseEnergy(int energyLoss)
    {
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseGame.activeInHierarchy)
        {
            PauseGame.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseGame.activeInHierarchy)
        {
            PauseGame.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void Checklist()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !checklist.activeInHierarchy)
        {
            checklist.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && checklist.activeInHierarchy)
        {
            checklist.SetActive(false);
        }
    }

    private void PlayerMovement()
    {
        //left - right
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }


    //make a thing that has time go up once you leave the house, days are like levels like cat game need to clear objectives to get to next day
    public void ClockTimer()
    {
            time = 8; // once you leave the house and click on the door the time gets set to 8 am\
           // set the time on the button need to search for answers = input field on button for time
           
           
    }
}
