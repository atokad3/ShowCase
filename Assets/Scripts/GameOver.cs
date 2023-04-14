using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    private GameObject gm;
    public int day;
  
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {

        day = PlayerPrefs.GetInt("Weekday");

        if (day >= 6)
        {
            Debug.Log("yoyoyo");
            SceneManager.LoadScene(sceneBuildIndex: 4);

        }
        
    }


    public void GameEnd()
    {

    }
}
