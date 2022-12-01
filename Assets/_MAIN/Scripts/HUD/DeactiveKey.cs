using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaiCi
{
    public class DeactiveKey : MonoBehaviour
    {
        public int numberKey = 0;
        public static DeactiveKey instance;

        private void Awake()
        {
            instance = this;
        }

        public void Run()
        {
            transform.GetChild(numberKey).GetComponent<UnityEngine.UI.Image>().enabled = false;
            numberKey++;

            if (numberKey == 3)
            {
                string name = SceneManager.GetActiveScene().name;

                var arr = name.Split($"{'_'}");

                int nextLevel = Int32.Parse(arr[1]) + 1;

                Debug.Log(arr[0] + "_" + nextLevel);

                SceneManager.LoadScene(arr[0] + "_" + nextLevel);
            }
        }

        internal void Reset()
        {
            numberKey = 0;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().enabled = true;
            }
        }
    }
}