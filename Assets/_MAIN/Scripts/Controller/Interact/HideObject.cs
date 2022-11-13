using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{

    public class HideObject : InteractWithObject
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
                TarodevController.PlayerController.instance.active = false;
                TarodevController.PlayerController.instance.transform.SetDisplayChildObject(0, 0, false);
                Debug.Log("Player Hide");
            }
            else
            {
                TarodevController.PlayerController.instance.active = true;
                TarodevController.PlayerController.instance.transform.SetDisplayChildObject(0, 0, true);
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
