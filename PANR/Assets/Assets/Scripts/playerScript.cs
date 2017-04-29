using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    private float Jumpforce = 2f;
    private float MovingSpeed = 2f;
    private Rigidbody2D rigidbody2D;
    //private float Speed = 10;
    public Physics2D Physics2D { get; set; }

    private bool isGrounded;
    private int jump;
    private int maxJump = 1;

    // Use this for initialization
    private void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        // DIRECTION = DOWN -> LEFT -> UP -> RIGHT
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Shifting Gravity");
            ShiftGravityRight();
        }
    }



    /// <summary>
    /// Shifts gravity clockwise!!
    /// DIRECTION = DOWN -> LEFT -> UP -> RIGHT
    /// </summary>
    //private void ShiftGravityLeft()
    //{

    //          if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f)
    //        {
    //            Debug.Log("Gravity Down");
    //            Physics2D.gravity = new Vector3(0f, -10f, 0f);
    //}
    //        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f)
    //        {
    //            Debug.Log("Gravity Left");
    //            Physics2D.gravity = new Vector3(-10f, 0f, 0f);
    //        }
    //        else if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f)
    //        {
    //            Debug.Log("Gravity Up");
    //            Physics2D.gravity = new Vector3(0f, 10f, 0f);
    //        }
    //        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f)
    //        {
    //            Debug.Log("Gravity Right");
    //            Physics2D.gravity = new Vector3(10f, 0f, 0f);
    //        }

    //    
    //}

    /// <summary>
    /// Shift gravity counter clockwise
    /// Down -> Right -> Up -> Left
    /// </summary>
    private void ShiftGravityRight()
    {
        //Keeping camera thing...just in case!
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
    /// Conrols if Gravity is down
    /// </summary>
    private void GravityDownControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.up * Jumpforce * 100);
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
            rigidbody2D.gameObject.transform.position += new Vector3(-MovingSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            rigidbody2D.gameObject.transform.position += new Vector3(MovingSpeed * Time.deltaTime, 0, 0);
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
            rigidbody2D.AddForce(transform.right * Jumpforce * 100);
            //Jump();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Up");
            gameObject.transform.position += new Vector3(0, MovingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Down");
            gameObject.transform.position += new Vector3(0, -MovingSpeed * Time.deltaTime, 0);
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
            rigidbody2D.AddForce(transform.up * -Jumpforce * 100);
            //Jump();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Right");
            gameObject.transform.position += new Vector3(-MovingSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Left");
            gameObject.transform.position += new Vector3(MovingSpeed * Time.deltaTime, 0, 0);
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
            rigidbody2D.AddForce(transform.right * -Jumpforce * 100);
            //Jump();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Up");
            gameObject.transform.position += new Vector3(0, MovingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Down");
            gameObject.transform.position += new Vector3(0, -MovingSpeed * Time.deltaTime, 0);
        }
    }

    void Jump()
    {
        if (jump > 0)
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);

            isGrounded = false;

            jump = jump - 1;
        }

        if (jump == 0)
        {
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {
            jump = maxJump;

            isGrounded = true;
        }

        //if (coll.gameObject.tag =="Spike")
        //{

            
        //    SceneManager.LoadScene("Level_1");

        //}
    }

    void Death()
    {
        if (useGUILayout)
        {
            

        }
    }
}