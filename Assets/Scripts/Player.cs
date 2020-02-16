using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    public float moveSpeed = 6;
    public GameObject flip;
    public bool transitioning = false;

    float accelerationTime = .075f;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;
    bool frozen = false;
    SpriteRenderer renderer;
    Animator animator;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        frozen = false;
        if (flip.GetComponent<Flip>().flipping)
        {
            frozen = true;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        if (transitioning)
        {
            frozen = true;
            transform.localScale -= Vector3.one * Time.deltaTime * 3f;
            transform.Rotate(new Vector3(0, 0, 5));
        }

        if (frozen)
        {
            velocity.y = 0;
        }
        else
        {
            if (input.x > 0)
            {
                renderer.flipX = false;
            }
            else if (input.x < 0)
            {
                renderer.flipX = true;
            }

            if (controller.collisions.above || controller.collisions.below)
            {
                velocity.y = 0;
                if (Mathf.Abs(input.x) > 0)
                {
                    animator.SetTrigger("Walk");
                }
                else
                {
                    animator.SetTrigger("Idle");
                }
            }
            else
            {
                if (velocity.y > 0)
                {
                    animator.SetTrigger("JumpUp");
                }
                else if (velocity.y < 0)
                {
                    animator.SetTrigger("JumpDown");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
            {
                velocity.y = maxJumpVelocity;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (velocity.y > minJumpVelocity)
                {
                    velocity.y = minJumpVelocity;
                }
            }

            float targetVelocityX = input.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
