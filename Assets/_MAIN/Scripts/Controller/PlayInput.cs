using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System;

namespace KaiCi
{
    [RequireComponent(typeof(Movement))]
    public class PlayInput : MonoBehaviour
    {
        [SerializeField] private Movement _movement;

        private void Update()
        {
            GetherInput();
        }

        private void GetherInput()
        {
            // _movement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
            // if (Input.GetKeyDown(Memory.moveKeyCode.moveUp))
            // {
            //     _movement.MoveUp();
            // }
            // else
            // if (Input.GetKeyDown(Memory.moveKeyCode.moveDown))
            // {
            //     _movement.MoveDown();
            // }
            // else
            // if (Input.GetKeyDown(Memory.moveKeyCode.moveLeft))
            // {
            //     _movement.MoveLeft();
            // }
            // else
            // if (Input.GetKeyDown(Memory.moveKeyCode.moveRight))
            // {
            //     _movement.MoveRight();
            // }
            // else
            // {
            //     _movement.Freeze();
            // }
        }
    }
}
