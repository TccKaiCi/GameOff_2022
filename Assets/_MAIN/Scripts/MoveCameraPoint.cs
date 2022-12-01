using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KaiCi
{
    public class MoveCameraPoint : MonoBehaviour
    {
        public GameObject point;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                CameraMoveByMove.instance.MoveToPoint(point.transform.position);
            }
        }
    }
}