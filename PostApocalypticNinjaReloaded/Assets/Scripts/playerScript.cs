using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float jumpforce;
    public float movingSpeed;
    public float speed = 10;
    public Physics2D Physics2D { get; set; }
    
    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Shifting Gravity");
            shiftGravity();
        }
    }

    /// <summary>
    /// Shifts cameraangle and gravity 90 degrees to the left 
    /// </summary>
    private void shiftGravity()
    {
        //Camera.main.transform.Rotate(new Vector3(0, 0, -90));

        for (var i = 0; i < 450; i += 1 )
        {
            Debug.Log("Rotating...");
            Camera.main.transform.Rotate(new Vector3(0, 0, -90));
        }

        //Camera.main.transform.eulerAngles =
        //    Vector3.Lerp(Camera.main.transform.eulerAngles,
        //    new Vector3(0, 0, -90),Time.deltaTime * speed);

        if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f)//LeftToUp
        {
            Debug.Log("Gravity Up");
            Physics2D.gravity = new Vector3(0f, 10f, 0f); //UP
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f)//DownToLeft
        {
            Debug.Log("Gravity Left");
            Physics2D.gravity = new Vector3(-10f, 0f, 0f); //LEFT
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f)//RightToDown
        {
            Debug.Log("Gravity Down");
            Physics2D.gravity = new Vector3(0f, -10f, 0f); //DOWN
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f)//UpToRight
        {
            Debug.Log("Gravity Right");
            Physics2D.gravity = new Vector3(10f, 0f, 0f); //RIGHT
        }
    }
}
