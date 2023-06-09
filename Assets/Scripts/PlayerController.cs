using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 3;
    public GameObject checklist;
    public GameObject PauseGame;
    public GameObject phone;
    private GameObject mainCamera;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera = GameObject.Find("Main Camera");
        if (PlayerPrefs.HasKey("StopX"))
        { // if has save, load
            LoadCharacter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.activeInHierarchy)
        { // if not pause, player move
            PlayerMovement();
            Checklist();
        }
        Pause();
        if (Input.GetKeyDown(KeyCode.C))
        {
            Unpause();
            SceneManager.LoadScene("CINNAMON");
        }

     
    }


    private void Pause()
    { // pauses game
        if (Input.GetKeyDown(KeyCode.LeftControl) && !PauseGame.activeInHierarchy)
        {
            PauseGame.SetActive(true);
            Time.timeScale = 0;
        }
        //unpause game
        else if (Input.GetKeyDown(KeyCode.LeftControl) && PauseGame.activeInHierarchy)
        {
            PauseGame.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Unpause()
    {
        //unpauses and saves game when goes quits
        PauseGame.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("StopX", transform.position.x);
        PlayerPrefs.SetFloat("StopY", transform.position.y);
        PlayerPrefs.SetFloat("StopCamX", mainCamera.transform.position.x);
        PlayerPrefs.SetFloat("StopCamY", mainCamera.transform.position.y);
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

    private void LoadCharacter()
    {
        // loads character and camera positions
        transform.position = new Vector3(PlayerPrefs.GetFloat("StopX"), PlayerPrefs.GetFloat("StopY"), 0);
        mainCamera.transform.position = new Vector3(PlayerPrefs.GetFloat("StopCamX"), PlayerPrefs.GetFloat("StopCamY"), -10);
    }

}
