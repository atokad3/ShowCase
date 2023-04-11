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

    // for closet in living room, if other door then ignore
    public GameObject openDoor;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
    }

    public void Move()
    {
        player.transform.position = playerGoTo;
        mainCamera.transform.position = cameraGoTo;
        currentRoom.SetActive(false);
        newRoom.SetActive(true);
    }

    public void Closet()
    {
        gameObject.SetActive(false);
        openDoor.SetActive(true);
    }
}
