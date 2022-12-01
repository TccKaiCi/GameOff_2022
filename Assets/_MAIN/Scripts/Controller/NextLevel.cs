using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class NextLevel : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {

            }
        }
    }
}
