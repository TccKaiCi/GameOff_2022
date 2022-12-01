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
        private void Update()
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            if (_isDashing) HandleDash();
        }

        private void HandleDash()
        {
            Vector2 newPosition = transform.position;

            if (moveInput.x != 0)
            {
                newPosition.x += moveInput.x * speed;
            }

            if (moveInput.y != 0)
            {
                newPosition.y += moveInput.y * speed;
            }


            transform.DOMove(newPosition, runTime).OnComplete(() => _isDashing = false);
        }
    }
}
