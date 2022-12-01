using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System;

namespace KaiCi
{
    // [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public Vector3 nextMoveCommand;
        // public Animator animator;
        public bool flipX = false;

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;

        enum State
        {
            Idle, Moving
        }

        State state = State.Idle;
        Vector3 start, end;
        Vector2 currentVelocity;
        float startTime;
        float distance;
        float velocity;

        void IdleState()
        {
            if (nextMoveCommand != Vector3.zero)
            {
                start = transform.position;
                end = start + nextMoveCommand;
                distance = (end - start).magnitude;
                velocity = 0;
                // UpdateAnimator(nextMoveCommand);
                nextMoveCommand = Vector3.zero;
                state = State.Moving;
            }
        }

        void MoveState()
        {
            velocity = Mathf.Clamp01(velocity + Time.deltaTime * acceleration);
            // UpdateAnimator(nextMoveCommand);
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
            spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? true : false;
        }

        // void UpdateAnimator(Vector3 direction)
        // {
        //     if (animator)
        //     {
        //         animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
        //         animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
        //     }
        // }

        void Update()
        {
            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Moving:
                    MoveState();
                    break;
            }
        }

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // [MustBeAssigned][SerializeField] private Rigidbody2D _rigidbody2D;
        // public float moveSpeed = 10f;
        // // public float updateTime = 0.05f;
        // Vector2 targetVelocity;

        // private void Reset()
        // {
        //     _rigidbody2D = GetComponent<Rigidbody2D>();
        // }

        // void Awake()
        // {
        //     // Setup Rigidbody for frictionless top down movement and dynamic collision
        //     _rigidbody2D = GetComponent<Rigidbody2D>();

        //     _rigidbody2D.isKinematic = false;
        //     _rigidbody2D.angularDrag = 0.0f;
        //     _rigidbody2D.gravityScale = 0.0f;
        // }

        // public void MoveUp()
        // {
        //     targetVelocity = new Vector2(transform.position.x, transform.position.y + 1.0f);
        // }
        // public void MoveDown()
        // {
        //     targetVelocity = new Vector2(0.0f, -1.0f);
        // }
        // public void MoveLeft()
        // {
        //     targetVelocity = new Vector2(-1.0f, 0.0f);
        // }
        // public void MoveRight()
        // {
        //     targetVelocity = new Vector2(1.0f, 0.0f);
        // }

        // public void Freeze()
        // {
        //     targetVelocity = new Vector2(0.0f, 0.0f);
        // }

        // private void FixedUpdate()
        // {
        //     Move();
        // }

        // void Move()
        // {
        //     targetVelocity.Normalize();

        //     if (targetVelocity == Vector2.zero) return;
        //     // Set rigidbody velocity
        //     _rigidbody2D.velocity = (targetVelocity * moveSpeed) * Time.fixedDeltaTime; // Multiply the target by deltaTime to make movement speed consistent across different framerates

        //     // _rigidbody2D.MovePosition(_rigidbody2D.position * moveSpeed * targetVelocity * Time.fixedDeltaTime);
        //     // _rigidbody2D.MovePosition(_rigidbody2D.position * moveSpeed * targetVelocity * Time.fixedDeltaTime);

        //     // Debug.Log("Move " + targetVelocity.ToString());
        // }

        // public void Move(Vector2 vector2)
        // {
        //     targetVelocity = vector2;
        // }
    }
}