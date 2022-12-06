using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded = false;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float groundRadius = 0.15f;
    [SerializeField] private Transform Posgroundcheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float JumpForce = 800.0f;
    private Rigidbody2D gBody;
    // Start is called before the first frame update
    void Start()
    {
        gBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float hrz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();
        // Code for jumping
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            gBody.AddForce(new Vector2(0.0f, JumpForce));
            isGrounded = false;
        }

        gBody.velocity = new Vector2(hrz * speed, gBody.velocity.y);
    }
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(Posgroundcheck.position, groundRadius, GroundLayer);
    }
}