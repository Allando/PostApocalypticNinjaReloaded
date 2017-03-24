using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float jumpforce;
    public float movingSpeed;
    public Physics2D Physics2D { get; set; }

    //For gravity



    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump?");
            rigidbody2D.AddForce(transform.up * jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
            gameObject.transform.position += new Vector3(-movingSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            gameObject.transform.position += new Vector3(movingSpeed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Gravity Change Up");
            Physics2D.gravity = new Vector3(10f, 0f, 0f);
            Camera.main.transform.Rotate(new Vector3(0, 0, -90));
            gravityUp();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Gravity Change Left");
            gravityLeft();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Gravity Change Down");
            gravityDown();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Gravity Change Right");
            gravityRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Shifting Gravity");
            shiftGravity();
        }
    }

    private void shiftGravity()
    {
        Camera.main.transform.Rotate(new Vector3(0, 0, -90));

        if (Physics2D.gravity.y == 0 && Physics2D.gravity.x == -10)
        {
            Debug.Log("ToUpper");
            Physics2D.gravity = new Vector3(10f, 0f, 0f); //UP
        }
        else if (Physics2D.gravity.y == 10 && Physics2D.gravity.x == 0)
        {
            Debug.Log("ToLeft");
            Physics2D.gravity = new Vector3(0f, -10f, 0f); //LEFT
        }
        else if (Physics2D.gravity.y == 0 && Physics2D.gravity.x == -10)
        {
            Debug.Log("ToLower");
            Physics2D.gravity = new Vector3(-10f, 0f, 0f); //DOWN
        }
        else if (Physics2D.gravity.y == -10 && Physics2D.gravity.x == 0)
        {
            Debug.Log("ToRight");
            Physics2D.gravity = new Vector3(0f, 10f, 0f); //RIGHT
        }
    }

    private void gravityUp()
    {
        Physics2D.gravity = new Vector3(0f, 10f, 0f);
        //Camera.main.transform.eulerAngles =
        //    Vector3.Lerp(Camera.main.transform.eulerAngles,
        //    new Vector3(90, 0, 0), Time.deltaTime * movingSpeed);
    }

    private void gravityLeft()
    {
        Physics2D.gravity = new Vector3(-10f, 0f, 0f);
    }

    private void gravityDown()
    {
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
    }

    private void gravityRight()
    {
        Physics2D.gravity = new Vector3(10f, 0f, 0f);
    }
}
