using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    private Rigidbody2D rb; //link to the object
    //private InputActions moveActions;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //moveActions = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //control - analysis of player reactions

        /*
        //Input - direct access to devices (keyboard, mouse)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 100f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * 5f);
        }
        */

        /*
        // Input Manager - combination of several methods of control along the axes
        float y = Input.GetAxis("Vertical");
        rb.AddForce(5f * y * Vector2.up);
        */

        //Input System - 
        //rb.AddForce(5f * moveActions)
    }
}
