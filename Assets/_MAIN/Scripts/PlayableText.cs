using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KaiCi
{
    public class PlayableText : MonoBehaviour
    {
        public DOTweenAnimation dgAnim;

        private void OnEnable()
        {
            dgAnim.DORestart();
            dgAnim.DOPlay();
        }
    }
}