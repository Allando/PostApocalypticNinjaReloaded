using UnityEngine;
public class playerScript : MonoBehaviour
{
    //PLAYER MOVEMENT VALUES
    private float jumpforce = 5f;
    private float movingSpeed = 12.5f;

    private Rigidbody2D rigidbody2D;
    private Collision2D coll;
   
    // Use this for initialization
    private void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f) //If Gravity is down
        {
            GravityDownControls();
        }
        else if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f) //If Gravity is left
        {
            GravityLeftControls();
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f) //If Gravity is up
        {
            GravityUpControls();
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f) //If Gravity is right
        {
            GravityRightControls();
        } 

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Shifting Gravity Left");
            ShiftGravityLeft();
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Shifting Gravity Right");
            ShiftGravityRight();
        }
    }

    /// <summary>
    /// Shifts gravity clockwise!!
    /// DIRECTION = DOWN -> LEFT -> UP -> RIGHT
    /// </summary>
    private void ShiftGravityLeft()
    {
        //Keeping camera thing... just in case!
        //Camera.main.transform.Rotate(new Vector3(0, 0, -90));

        if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f)
        {
            Debug.Log("Gravity Down");
            Physics2D.gravity = new Vector3(0f, -10f, 0f);
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f)
        {
            Debug.Log("Gravity Left");
            Physics2D.gravity = new Vector3(10f, 0f, 0f);
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f)
        {
            Debug.Log("Gravity Up");
            Physics2D.gravity = new Vector3(0f, 10f, 0f);
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f)
        {
            Debug.Log("Gravity Right");
            Physics2D.gravity = new Vector3(-10f, 0f, 0f);
        }
    }

    /// <summary>
    /// Shift gravity counter clockwise
    /// Down -> Right -> Up -> Left
    /// </summary>
    private void ShiftGravityRight()
    {
        if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f)
        {
            Debug.Log("Gravity Down");
            Physics2D.gravity = new Vector3(0f, -10f, 0f);
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f)
        {
            Debug.Log("Gravity Left");
            Physics2D.gravity = new Vector3(-10f, 0f, 0f);
        }
        else if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f)
        {
            Debug.Log("Gravity Up");
            Physics2D.gravity = new Vector3(0f, 10f, 0f);
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f)
        {
            Debug.Log("Gravity Right");
            Physics2D.gravity = new Vector3(10f, 0f, 0f);
        }
    }

    /// <summary>
    /// Conrols if Gravity is down
    /// </summary>
    private void GravityDownControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.up * jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
            rigidbody2D.gameObject.transform.position += new Vector3(-movingSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            rigidbody2D.gameObject.transform.position += new Vector3(movingSpeed * Time.deltaTime, 0, 0);
        }
    }

    /// <summary>
    /// Conrols if Gravity is left
    /// </summary>
    private void GravityLeftControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.right * jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Up");
            gameObject.transform.position += new Vector3(0, movingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Down");
            gameObject.transform.position += new Vector3(0, -movingSpeed * Time.deltaTime, 0);
        }
    }

    /// <summary>
    /// Conrols if Gravity is up
    /// </summary>
    private void GravityUpControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.up * -jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Right");
            gameObject.transform.position += new Vector3(-movingSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Left");
            gameObject.transform.position += new Vector3(movingSpeed * Time.deltaTime, 0, 0);
        }
    }

    /// <summary>
    /// Conrols if Gravity is right
    /// </summary>
    private void GravityRightControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.right * -jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Up");
            gameObject.transform.position += new Vector3(0, movingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Down");
            gameObject.transform.position += new Vector3(0, -movingSpeed * Time.deltaTime, 0);
        }
    }

    /// <summary>
    /// Prevention of double jumps
    /// </summary>
    /// <param name="coll"></param>
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag != "Platform")
    //    {
    //        Debug.Log("Collision with platform");
    //        jumpforce = 0;
    //    }
    //    else
    //    {
    //        jumpforce = 2.5f;
    //    }
    //}
}