using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Transform playerSpawn;
    public float forwardSpeed = 20f;
    public float sidewaysSpeed = 10f;
    public float jumpForce = 4f;

    PlayerControls controls;
    Rigidbody rb;
    float moveInput;
    bool canJump = false;
    bool finished = false;
    private float finishSpeed;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Movement.Enable();
        controls.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<float>();
        controls.Movement.Move.canceled += ctx => moveInput = 0f;
        controls.Movement.Jump.performed += ctx => Jump();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -3f)
        {
            GameOver();
        }

        if (!finished)
        {
            var movement = new Vector3(moveInput, 0, 0);

            transform.Translate(movement * sidewaysSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

    }

    void Jump()
    {
        if (canJump && !finished)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    void GameOver()
    {
        transform.position = playerSpawn.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            finished = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = false;
        }
    }
}