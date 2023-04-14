using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Bedroom", 1);
        PlayerPrefs.SetInt("Time", 0);
    }
}
