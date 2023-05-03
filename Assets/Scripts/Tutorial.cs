using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public List<GameObject> screens;
    private int screenNum;

    // Start is called before the first frame update
    void Start()
    {
        screenNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject screen in screens)
        {
            if(screens.IndexOf(screen) == screenNum) 
            {
                screen.SetActive(true);
            }
            else
            {
                screen.SetActive(false);
            }
        }
    }

    public void Next()
    {
        screenNum++;
    }
}
