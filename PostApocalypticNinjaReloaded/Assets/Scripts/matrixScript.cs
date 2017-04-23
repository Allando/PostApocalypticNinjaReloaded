using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrixScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D { get; set; }
    private float movingSpeed = 10f;

    // Use this for initialization
    void Start ()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f) //If Gravity is down
        {
            rigidbody2D.gameObject.transform.position += new Vector3(0, -movingSpeed * Time.deltaTime, 0);
        }
        else if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f) //If Gravity is left
        {
            rigidbody2D.gameObject.transform.position += new Vector3(-movingSpeed * Time.deltaTime, 0, 0);
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f) //If Gravity is up
        {
            rigidbody2D.gameObject.transform.position += new Vector3(0, movingSpeed * Time.deltaTime, 0);
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f) //If Gravity is right
        {
            rigidbody2D.gameObject.transform.position += new Vector3(movingSpeed * Time.deltaTime, 0, 0);
        }
    }
}
