using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

namespace KaiCi
{
    public class MorphingSkill : MonoBehaviour
    {
        [SerializeField] private bool _isUsingSkill;
        [SerializeField] private GameObject[] listPrefab;

        private void Start()
        {
            _isUsingSkill = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(Memory.morphingSkill))
            {
                DoMorphing();
            }
        }

        private void DoMorphing()
        {
            if (_isUsingSkill)
            {
                //todo go out of skill
                PlayerController.instance.PlayerReMoving();
            }
            else
            {
                //todo play hide
                PlayerController.instance.PlayerStopMoving();
                SpawnEffectDisappear();
            }

            _isUsingSkill = !_isUsingSkill;
        }
        private void SpawnEffectDisappear()
        {
            var effect = Instantiate(listPrefab[UnityEngine.Random.Range(0, listPrefab.Length)], transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

    }
}
