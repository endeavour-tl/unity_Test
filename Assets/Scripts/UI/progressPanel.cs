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
        //_operation.allowSceneActivation = false;//�Զ���ת���򲻼�����仰
        while (!_operation.isDone)
        {
            //û�����
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
        _slider = GetComponentInChildren<Slider>();  // ��ȡ Slider ���
        _text = GetComponentInChildren<Text>();  // ��ȡ Text ���
        gameObject.SetActive(false);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        gameObject.SetActive(true);
        float targetProgress = 0.9f;  // Ŀ����ؽ��ȣ���������Ϊ0.9��ʾ���ص�90%��
        float currentProgress = 0f;

        while (currentProgress < targetProgress)
        {
            currentProgress += Time.deltaTime * 0.1f;  // ���ƽ��ȵ������ٶȣ����Ը�����Ҫ����
            _slider.value = currentProgress;
            _text.text = (currentProgress * 100).ToString("F0") + "%";
            yield return null;
        }

        AsyncOperation _operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //_operation.allowSceneActivation = false;//�Զ���ת���򲻼�����仰
        while (!_operation.isDone)
        {
            // ������ʾ��ɵĽ��ȣ�������ʾ10%��
            _slider.value = targetProgress + _operation.progress * 0.1f;
            _text.text = ((targetProgress + _operation.progress * 0.1f) * 100).ToString("F0") + "%";
            yield return null;
        }
    }
}