using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    public GameObject box;
    public Sprite check;
    public GameObject gm;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Task10"))
        { 
            box.GetComponent<SpriteRenderer>().sprite = check;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void timeTaco()
    {        
        SceneManager.LoadScene("TimeTaco");
        gm.GetComponent<GameManager>().isWorkDone = true;
    }

    public void SchoolAndWork()
    {
        box.GetComponent<SpriteRenderer>().sprite = check;
        PlayerPrefs.SetString("task10", "Done");
        gm.GetComponent<GameManager>().LoseEnergy(10);
    }

    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }


    public void CreditScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }


    public void MenuScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void ResetDay()
    {
        // resets game and things to default
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Bedroom", 1);
        PlayerPrefs.SetInt("Time", 0);
    }

    public void FinishGame()
    {
        PlayerPrefs.SetString("FinishGame?", "Yes");
    }
}
