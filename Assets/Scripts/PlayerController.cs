using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;

    public int maxEnergy = 100;
    public int currentEnergy;

    public EnergyBar energyBar;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();



        ///////////////////////
        ///////////////////////
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseEnergy(10);
        }
    }

    
    private void LoseEnergy(int energyLoss)
    {
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
    }

    private void PlayerMovement()
    {
        //left - right
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

}
