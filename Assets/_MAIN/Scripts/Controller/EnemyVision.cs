using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class EnemyVision : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(Memory.playerTag))
            {
                // HUDSystem.Instance.healthBar.DeleteOneHearth();
                TarodevController.PlayerController.instance.transform.position = new Vector3(-39.9199982f, 6.44999981f, 0f);
            }
        }
    }
}
