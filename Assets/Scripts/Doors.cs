using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject player;
    public Vector3 playerGoTo;
    public Vector3 cameraGoTo;
    public GameObject currentRoom;
    public GameObject newRoom;
    public GameObject doorButton;


    // for closet in living room, if other door then ignore
    public GameObject openDoor;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
    }

    public void Move()
    {
        //moves player and camera to new room
        player.transform.position = playerGoTo;
        mainCamera.transform.position = cameraGoTo;
        // changes which room gameobject is active
        currentRoom.SetActive(false);
        newRoom.SetActive(true);
    }

    public void Date()
    {
        if(PlayerPrefs.GetFloat("CurrentEnergy") < 10)
        {
            Debug.Log("No Date For U");
        }
        else if(PlayerPrefs.GetFloat("CurrentEnergy") >= 10)
        {
            Move();
            mainCamera.GetComponent<GameManager>().LoseEnergy(10);
            openDoor.SetActive(false);
        }
    }

    public void Off()
    {
        openDoor.SetActive(false);
    }

    public void Closet()
    {
        // opens closet
        gameObject.SetActive(false);
        openDoor.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            doorButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            doorButton.SetActive(false);
    }
}
