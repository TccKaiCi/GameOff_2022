using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace KaiCi
{
    public class Movement : MonoBehaviour
    {
        [MustBeAssigned][SerializeField] private Rigidbody2D _rigidbody2D;

        private void Reset()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public float moveSpeed = 10f;
        public float updateTime = 0.05f;

        public void Move(bool isMoveRight)
        {
            // var moveDirection = isMoveRight ? moveSpeed : -1.0f * moveSpeed;
            var moveDirection = isMoveRight ? Vector2.right : -1.0f * Vector2.left;

            // var targetVelocity = new Vector2(moveDirection, _rigidbody2D.velocity.y);
            // // And then smoothing it out and applying it to the character
            // var m_Velocity = Vector2.zero;
            // _rigidbody2D.velocity = Vector2.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref m_Velocity, updateTime);

            // _rigidbody2D.velocity = Vector2.right * moveDirection;
            _rigidbody2D.velocity = moveDirection * moveSpeed;
        }
    }
}