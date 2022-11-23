using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using TMPro;
using UnityEngine.UI;
using System;

namespace KaiCi
{
    public class GenerateLevel : MonoBehaviour
    {
        public Sprite[] mapImage;
        public GameObject mapLevelPrefab;

        [ButtonMethod]
        private void Generate()
        {
            for (int i = 0; i < mapImage.Length; i++)
            {
                var map = Instantiate(mapLevelPrefab, transform.position, Quaternion.identity);
                map.transform.parent = transform;

                map.transform.GetChild(0).GetComponent<Image>().sprite = mapImage[i];
                map.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText((i + 1) + "");
                map.GetComponent<ChangeScene>().sceneName = GetSceneName(i + 1);
            }
        }

        private SceneName GetSceneName(int i)
        {
            foreach (var type in Enum.GetValues(typeof(SceneName)))
            {
                if (type.ToString().Contains("_" + i))
                {
                    return (SceneName)type;
                }
            }

            return SceneName.Home;
        }
    }
}