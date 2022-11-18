using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KaiCi
{
    public class DashSkill : Skill
    {
        [SerializeField] private bool _isDashing = false;
        public float speed, runTime;

        public Rigidbody2D rigidbody2D;
        public Vector2 moveInput;

        public override void Use()
        {
            Debug.Log("Use dash");
            _isDashing = true;
        }

        private void FixedUpdate()
        {
            if (_isDashing) HandleDash();
        }

        private void HandleDash()
        {
            moveInput.x = speed * Input.GetAxisRaw("Horizontal") + transform.position.x;
            moveInput.y = speed * Input.GetAxisRaw("Vertical") + transform.position.y;

            // rigidbody2D.velocity = (moveInput * speed);
            _isDashing = false;

            transform.DOMove(moveInput, runTime);
        }

        // private bool CanMove(Vector2 dir, float distance)
        // {
        //     return Physics2D.Raycast(transform.position, dir, distance).collider == null;
        // }

    }
}
