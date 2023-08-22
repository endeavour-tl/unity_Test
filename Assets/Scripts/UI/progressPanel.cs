using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*public class progressPanel : MonoBehaviour
{
    private Slider _slider;
    private Text _text;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _text = GetComponent<Text>();
        gameObject.SetActive(false);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        gameObject.SetActive(true);
        AsyncOperation _operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //_operation.allowSceneActivation = false;//自动跳转，则不加入这句话
        while (!_operation.isDone)
        {
            //没有完成
            _slider.value = _operation.progress;
            _text.text = _operation.progress * 100 + "%";
            yield return null;
        }
    }
}*/
public class progressPanel : MonoBehaviour
{
    private Slider _slider;
    private Text _text;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();  // 获取 Slider 组件
        _text = GetComponentInChildren<Text>();  // 获取 Text 组件
        gameObject.SetActive(false);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        gameObject.SetActive(true);
        float targetProgress = 0.9f;  // 目标加载进度（这里设置为0.9表示加载到90%）
        float currentProgress = 0f;

        while (currentProgress < targetProgress)
        {
            currentProgress += Time.deltaTime * 0.1f;  // 控制进度的增加速度，可以根据需要调整
            _slider.value = currentProgress;
            _text.text = (currentProgress * 100).ToString("F0") + "%";
            yield return null;
        }

        AsyncOperation _operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //_operation.allowSceneActivation = false;//自动跳转，则不加入这句话
        while (!_operation.isDone)
        {
            // 持续显示完成的进度（这里显示10%）
            _slider.value = targetProgress + _operation.progress * 0.1f;
            _text.text = ((targetProgress + _operation.progress * 0.1f) * 100).ToString("F0") + "%";
            yield return null;
        }
    }
}