using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityScript : playerScript
{

    float speed = 10;

    // Update is called once per frame
    public void Update()
    {

        {
            Debug.Log("Gravity Change Up");
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
    }

    private void gravityUp()
    {
        Physics2D.gravity = new Vector3(0f, 10f, 0f);
        Camera.main.transform.eulerAngles =
                Vector3.Lerp(Camera.main.transform.eulerAngles,
                new Vector3(90, 0, 0), Time.deltaTime * speed);
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
