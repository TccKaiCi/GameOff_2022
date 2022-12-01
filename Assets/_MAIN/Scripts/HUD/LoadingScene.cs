using System.Collections;
using DG.Tweening;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace KaiCi
{
    public class LoadingScene : MonoBehaviour
    {
        public TMP_Text loadingProcessText;
        public Slider loadingBar;
        public RectTransform loadingImg;

        private float _width;
        private float _offset;

        void Start()
        {
            Camera cam = Camera.main;
            _width = 2f * cam.orthographicSize * cam.aspect;
            _offset = -_width / 2f;
            loadingImg.position = loadingImg.position.SetX(_offset);

            StartCoroutine(LoadMainScene());
        }
        IEnumerator LoadMainScene()
        {
            float progress = 0f;

            yield return new WaitForSeconds(0.5f);

            var loadGameScene = SceneManager.LoadSceneAsync("Main");
            while (!loadGameScene.isDone)
            {
                progress = Mathf.Clamp01(loadGameScene.progress / 0.9f);
                loadingProcessText.SetText("Loading");
                loadingBar.value = progress;
                loadingImg.DOMoveX(progress * _width + _offset, .1f);

                yield return null;
            }
        }
    }
}
