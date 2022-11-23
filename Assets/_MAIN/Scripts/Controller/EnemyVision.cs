using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace KaiCi
{
    public class EnemyVision : MonoBehaviour
    {
        [MustBeAssigned] public GameObject alert;
        public float timeForAlert;
        public bool isPlayerInRange = false;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                isPlayerInRange = true;
                StartCoroutine(StartAlert());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag) || other.CompareTag(Memory.playerHidingTag))
            {
                isPlayerInRange = false;
            }
        }

        IEnumerator StartAlert()
        {
            alert.SetActive(true);
            yield return new WaitForSeconds(timeForAlert);

            if (isPlayerInRange)
            {
                PlayerController.instance.transform.position = new Vector3(-39.9199982f, 6.44999981f, 0f);
            }


            alert.SetActive(false);
        }

    }
}
