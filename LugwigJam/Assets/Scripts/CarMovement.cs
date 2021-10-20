using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float forceMult = 200;
    public Rigidbody rb;
    public CharacterController characterController;
    public float speed = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.up * verticalMove;
        characterController.Move(speed * Time.deltaTime * move);
        if (horizontalMove < 0)
        {
            transform.Rotate(transform.up, 0.1f);
        }
        else if (horizontalMove > 0)
        {
            transform.Rotate(transform.up, -0.1f);
        }
    }
}
