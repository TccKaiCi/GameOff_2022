using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{

    public class HideObjectWithKeyPress : InteractWithObject
    {
        private bool _isHide;

        private void Start()
        {
            base.Start();
            _isHide = false;
        }

        protected override void PLayInteraction()
        {
            if (_isHide)
            {
                Debug.Log("Player Hide");
            }
            else
            {
                Debug.Log("Player unHide");
            }

            _isHide = !_isHide;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                isIntractable = true;
                _isHide = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                isIntractable = false;
                _isHide = false;
            }
        }
    }
}
