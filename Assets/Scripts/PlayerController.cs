using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 3;
    public GameObject checklist;
    public Animator anim;
    public GameObject PauseGame;
    public bool doorClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.activeInHierarchy)
        {
            PlayerMovement();
            Checklist();
        }
        Pause();
    }

    /*
     * Each day, player chooses activity
     * Each activity costs energy
     * When daily energy remaining minus starting energy < 0, sleep
     * Rinse, repeat
     */

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

}
