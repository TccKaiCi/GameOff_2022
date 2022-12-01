using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KaiCi
{
    public class KeyMove : MonoBehaviour
    {
        public bool isActive = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag) && isActive == false)
            {
                DeactiveKey.instance.Run();
                isActive = true;
                Destroy(gameObject);
            }
        }
    }
}