using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class MorphingSkill : Skill
    {
        [SerializeField] private bool _isUsingSkill;
        [SerializeField] private GameObject[] listPrefab;

        private void Start()
        {
            _isUsingSkill = false;
        }

        public override void Use()
        {
            Debug.Log("Use morphing");
        }

        private void DoMorphing()
        {
            if (_isUsingSkill)
            {
                //todo go out of skill
            }
            else
            {
                //todo play hide
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
