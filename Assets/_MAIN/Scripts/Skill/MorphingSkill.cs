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

        public GameObject[] childs;

        private bool _isInCoolDown;

        private void Start()
        {
            _isUsingSkill = false;
            _isInCoolDown = false;
        }

        public override void Use()
        {
            if (_isInCoolDown) return;

            Debug.Log("Use morphing");
            StartCoroutine(DoMorphing());
        }

        IEnumerator DoMorphing()
        {
            if (_isUsingSkill)
            {

                _isInCoolDown = true;
                //todo go out of skill
                gameObject.tag = Memory.playerTag;

                foreach (var a in childs)
                {
                    a.tag = Memory.playerTag;
                }

                ReturnToNormal();

                yield return new WaitForSeconds(3.0f);
                _isInCoolDown = false;
                _isUsingSkill = !_isUsingSkill;
            }
            else
            {
                //todo play hide
                gameObject.tag = Memory.playerHidingTag;

                foreach (var a in childs)
                {
                    a.tag = Memory.playerHidingTag;
                }

                SpawnEffectDisappear();
                _isUsingSkill = !_isUsingSkill;
            }

            yield return null;
        }

        private void ReturnToNormal()
        {
            PlayerController.instance.TurnOnOneAnimation(Memory.AnimationExitMorphingName);
            PlayerController.instance.animator.SetBool(Memory.AnimationIdleName, true);
            Invoke(nameof(PlayIdle), 1.15f);
        }
        public void PlayIdle()
        {
            PlayerController.instance.SetMovingStatus(true);
        }
        private void SpawnEffectDisappear()
        {
            PlayerController.instance.TurnOnOneAnimation(Memory.AnimationMorphingName);
            PlayerController.instance.SetMovingStatus(false);

            var effect = Instantiate(listPrefab[UnityEngine.Random.Range(0, listPrefab.Length)], transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

    }
}
