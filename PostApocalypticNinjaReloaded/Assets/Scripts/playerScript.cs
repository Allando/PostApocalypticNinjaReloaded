using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float Jumpforce;
    public float MovingSpeed;
    private Rigidbody2D rigidbody2D;
    public float Speed = 10;
    public Physics2D Physics2D { get; set; }

    // Use this for initialization
    private void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {

        if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f) //LeftToUp
        {
            Debug.Log("Gravity Up");
            Physics2D.gravity = new Vector3(0f, 10f, 0f); //UP

            GravityUpControls();
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f) //DownToLeft
        {
            Debug.Log("Gravity Left");
            Physics2D.gravity = new Vector3(-10f, 0f, 0f); //LEFT
            GravityLeftControls();
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f) //RightToDown
        {
            Debug.Log("Gravity Down");
            Physics2D.gravity = new Vector3(0f, -10f, 0f); //DOWN
            GravityDownControls();
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f) //UpToRight
        {
            Debug.Log("Gravity Right");
            Physics2D.gravity = new Vector3(10f, 0f, 0f); //RIGHT
            GravityRightControls();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Shifting Gravity");
            ShiftGravity();
        }
    }

    /// <summary>
    ///     Shifts cameraangle and gravity 90 degrees to the left
    /// </summary>
    private void ShiftGravity()
    {
        //Keeping camera .. just in case
        //Camera.main.transform.Rotate(new Vector3(0, 0, -90));

        if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f) //LeftToUp
        {
            Debug.Log("Gravity Up");
            Physics2D.gravity = new Vector3(0f, 10f, 0f); //UP
          
            GravityUpControls();
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f) //DownToLeft
        {
            Debug.Log("Gravity Left");
            Physics2D.gravity = new Vector3(-10f, 0f, 0f); //LEFT
            GravityLeftControls();
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f) //RightToDown
        {
            Debug.Log("Gravity Down");
            Physics2D.gravity = new Vector3(0f, -10f, 0f); //DOWN
            GravityDownControls();
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f) //UpToRight
        {
            Debug.Log("Gravity Right");
            Physics2D.gravity = new Vector3(10f, 0f, 0f); //RIGHT
            GravityRightControls();
        }
    }

    private void GravityDownControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.up * Jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
            gameObject.transform.position += new Vector3(-MovingSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            gameObject.transform.position += new Vector3(MovingSpeed, 0, 0);
        }
    }

    private void GravityLeftControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.right * Jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Up");
            gameObject.transform.position += new Vector3(0, MovingSpeed, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Down");
            gameObject.transform.position += new Vector3(0, -MovingSpeed, 0);
        }
    }

    private void GravityUpControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.up * -Jumpforce * 100); //THIS MIGHT BEE WRONG!!!
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Right");
            gameObject.transform.position += new Vector3(-MovingSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Left");
            gameObject.transform.position += new Vector3(MovingSpeed, 0, 0);
        }
    }

    private void GravityRightControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(transform.right * Jumpforce * 100);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Up");
            gameObject.transform.position += new Vector3(0, -MovingSpeed, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Down");
            gameObject.transform.position += new Vector3(0, MovingSpeed, 0);
        }
    }
}