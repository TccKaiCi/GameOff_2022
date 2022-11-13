using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System;

namespace KaiCi
{
    public class PlayInput : MonoBehaviour
    {
        [MustBeAssigned][SerializeField] private Movement movement;

        private void Reset()
        {
            movement = GetComponent<Movement>();
        }

        private void Update()
        {
            GatherInput();
        }

        private void GatherInput()
        {
            if (Input.GetKeyDown(Memory.moveLeft))
            {
                movement.Move(false);
            }
            if (Input.GetKeyDown(Memory.moveLeft))
            {
                movement.Move(true);
            }
        }
    }
}
