using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using DG.Tweening;

namespace KaiCi
{
    public class ShowLevelPanel : MonoBehaviour
    {
        [MustBeAssigned] public GameObject panel;

        [ButtonMethod]
        public void ShowPanel()
        {
            panel.transform.DOScale(new Vector3(1, 1, 1), 1f);
            HideButton();
        }

        [ButtonMethod]
        public void HidePanel()
        {
            panel.transform.DOScale(new Vector3(0, 0, 0), 1f);
        }

        private void HideButton()
        {
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
            transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        }

        private void OnEnable()
        {
            HidePanel();
        }
    }
}