using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 20f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
	  		float verticalInput = Input.GetAxis("Vertical");

	  		if (CameraChange.CamMode == 1) {
	  			rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, 0);
	  		}
				else {
	  			rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
	  		}

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

				if (!IsGrounded())
				{
					
				}
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        // jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            // Destroy(collision.transform.parent.gameObject);

				rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5f);
				rb.transform.Translate(0,0,20f);

            // Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}