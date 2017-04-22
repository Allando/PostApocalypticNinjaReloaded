using UnityEngine;
public class playerScript : MonoBehaviour
{
    private float Jumpforce = 2.5f;
    private float MovingSpeed = 0.2f;
    private Rigidbody2D rigidbody2D;
    private Collision2D coll;
    private float Speed = 10;
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
        // DIRECTION = DOWN -> LEFT -> UP -> RIGHT
        if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f)
        {
            GravityDownControls();
        }
        else if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f)
        {
            GravityLeftControls();
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f)
        {
            GravityUpControls();
        }
        else if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f)
        {
            GravityRightControls();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Shifting Gravity");
            ShiftGravity();
        }
    }

    /// <summary>
    /// Shifts gravity clockwise!!
    /// DIRECTION = DOWN -> LEFT -> UP -> RIGHT
    /// </summary>
    private void ShiftGravity()
    {
        //Keeping camera .. just in case
        //Camera.main.transform.Rotate(new Vector3(0, 0, -90));

        //if (Physics2D.gravity.x == 10f && Physics2D.gravity.y == 0f)
        //{
        //    Debug.Log("Gravity Down");
        //    Physics2D.gravity = new Vector3(0f, -10f, 0f);
        //}
        //else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == -10f)
        //{
        //    Debug.Log("Gravity Left");
        //    Physics2D.gravity = new Vector3(-10f, 0f, 0f);
        //}
        //else if (Physics2D.gravity.x == -10f && Physics2D.gravity.y == 0f)
        //{
        //    Debug.Log("Gravity Up");
        //    Physics2D.gravity = new Vector3(0f, 10f, 0f);
        //}
        //else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 10f)
        //{
        //    Debug.Log("Gravity Right");
        //    Physics2D.gravity = new Vector3(10f, 0f, 0f);
        //}

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
            rigidbody2D.gameObject.transform.position += new Vector3(-MovingSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            rigidbody2D.gameObject.transform.position += new Vector3(MovingSpeed, 0, 0);
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
            rigidbody2D.AddForce(transform.right * -Jumpforce * 100);
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Platform")
        {
            Debug.Log("Collision with platform");
            Jumpforce = 0;
        }
        else
        {
            Jumpforce = 2.5f;
        }
    }
}