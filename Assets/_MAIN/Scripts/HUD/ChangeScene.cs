using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaiCi
{
    public enum SceneName
    {
        Home = 0,
        LoadingScene = -2,
        Main = 99,
        Level_1 = 1,
        Level_2 = 2,
        Level_3 = 3,
        Level_4 = 4,
        Level_5 = 5,
        Level_6 = 6,
        Level_7 = 7,
        Level_8 = 8,
        Level_9 = 9,
    }
    public class ChangeScene : MonoBehaviour
    {
        public SceneName sceneName;
        public void LoadScene()
        {
            Debug.Log("Loading scene");
            SceneManager.LoadScene(sceneName.ToString());
        }
    }
}