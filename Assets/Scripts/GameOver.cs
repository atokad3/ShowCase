using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public GameManager gm;
  
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
       // gm.get
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (day > 6)
        {
            Debug.Log("yoyoyo");
            SceneManager.LoadScene(sceneBuildIndex: 4);

        }
        */
    }


    public void GameEnd()
    {

    }
}
