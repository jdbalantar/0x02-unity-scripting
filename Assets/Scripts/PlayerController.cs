using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 0, 2000 * Time.deltaTime);
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed <= 0)
        {
            if (Input.GetKey("w"))
                rb.AddForce(0, 0, 30);
            if (Input.GetKey("s"))
                rb.AddForce(0, 0, -30);
            if (Input.GetKey("a"))
                rb.AddForce(-30, 0, 0);
            if (Input.GetKey("d"))
                rb.AddForce(30, 0, 0);
        }
        else
        {
            if (Input.GetKey("w"))
                rb.AddForce(0, 0, 30 * speed);
            if (Input.GetKey("s"))
                rb.AddForce(0, 0, -30 * speed);
            if (Input.GetKey("a"))
                rb.AddForce(-30 * speed, 0, 0);
            if (Input.GetKey("d"))
                rb.AddForce(30 * speed, 0, 0);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            Debug.Log("Score: " + score);
        }
    }

    public Rigidbody rb;
    public float speed;
    private int score;
}
