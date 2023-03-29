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
}
