using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class HideObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                other.gameObject.tag = Memory.playerHidingTag;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerHidingTag))
            {
                other.gameObject.tag = Memory.playerTag;
            }
        }
    }
}