using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;


namespace KaiCi
{

    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private int _numberHearth = 0;
        [SerializeField] private int _maxHearth = 3;
        [MustBeAssigned] public GameObject heartPrefab;
        [SerializeField] private GameObject[] _listHeartBeDisplayed;

        private void Start()
        {
            _listHeartBeDisplayed = new GameObject[_maxHearth];
            InitNumberHearth(_maxHearth);
        }

        private void InitNumberHearth(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var heartObject = Instantiate(heartPrefab, transform.position, Quaternion.identity);
                heartObject.transform.parent = transform;
                _listHeartBeDisplayed[_numberHearth] = heartObject;

                _numberHearth++;
            }
        }

        [ButtonMethod]
        public void AddOneHearth()
        {
            if ((_numberHearth + 1) > _maxHearth) return;

            _listHeartBeDisplayed[_numberHearth].SetActive(true);
            _numberHearth++;
        }

        [ButtonMethod]
        public void DeleteOneHearth()
        {
            _numberHearth--;
            _listHeartBeDisplayed[_numberHearth].SetActive(false);
        }

        private void CheckHearth()
        {
            if (_numberHearth == 1)
            {
                HUDSystem.Instance.ShowGameWinPanel();
            }
        }
    }
}
