using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    public GameObject checklist;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
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
