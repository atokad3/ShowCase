using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float speedY = 1f;
    private Vector2 movingOn;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject.rb
        movingOn = new Vector2 (0f, speedY);
        rb2.velocity = movingOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
