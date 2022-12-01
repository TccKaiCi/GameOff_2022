using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace KaiCi
{
    public class Teleport : MonoBehaviour
    {
        public CinemachineConfiner2D cameraBound;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                PlayerController.instance.transform.position = transform.GetChild(0).transform.position;
                CameraMoveByMove.instance.MoveToPoint(transform.GetChild(0).transform.position);

                cameraBound.enabled = false;
            }
        }
    }
}