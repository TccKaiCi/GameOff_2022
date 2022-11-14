using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaiCi
{
    public enum SceneName
    {
        Home,
        LoadingScene,
        Main
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