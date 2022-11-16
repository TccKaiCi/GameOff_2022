using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace KaiCi
{
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.1f;
        [SerializeField] private Movement _movement;

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                    // case State.DialogControl:
                    //     DialogControl();
                    //     break;
            }
        }
        void CharacterControl()
        {
            if (Input.GetKey(KeyCode.UpArrow))
                _movement.nextMoveCommand = Vector3.up * stepSize;
            else if (Input.GetKey(KeyCode.DownArrow))
                _movement.nextMoveCommand = Vector3.down * stepSize;
            else if (Input.GetKey(KeyCode.LeftArrow))
                _movement.nextMoveCommand = Vector3.left * stepSize;
            else if (Input.GetKey(KeyCode.RightArrow))
                _movement.nextMoveCommand = Vector3.right * stepSize;
            else
                _movement.nextMoveCommand = Vector3.zero;
        }
    }
}