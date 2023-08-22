using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    private Button _PlayButton;
    private Button _explainButton;
    private Button _memberButton;
    private Button _setButton;
    public GameObject _StartPanel;
    public GameObject _memberPanel;
    public GameObject _explainPanel;
    public GameObject _SetPanel;
    public GameObject _progressPanel;

    private GameObject _parent;  // 父物体，包含了所有同级别的 Panel

    private void Start()
    {
        _PlayButton = transform.Find("PlayButton").GetComponent<Button>();
        _explainButton = transform.Find("explainButton").GetComponent<Button>();
        _memberButton = transform.Find("memberButton").GetComponent<Button>();
        _setButton = transform.Find("setButton").GetComponent<Button>();

        _parent = transform.parent.gameObject;  // 获取父物体

        /*_StartPanel = GameObject.Find("StartPanel").GetComponent<Panel>();
        //_memberPanel = _parent.transform.Find("memberPanel").GetComponentInChildren<Panel>();
        _memberPanel = GameObject.FindGameObjectWithTag("memberPanel").GetComponent<Panel>();//memberPanel
        _explainPanel = _parent.transform.Find("explainPanel").GetComponent<Panel>();*/
        //_SetPanel = _parent.transform.Find("SetPanel").GetComponentInChildren<GameObject>();

        if (_memberPanel != null)
        {
            // 在这里你可以操作 _setPanel
            Debug.Log("SetPanel found and assigned!");
        }
        else
        {
            Debug.LogError("SetPanel not found.");
        }

        _PlayButton.onClick.AddListener(OnPlayButton);
        _explainButton.onClick.AddListener(OnexplainButton);
        _memberButton.onClick.AddListener(OnmemberButton);
        _setButton.onClick.AddListener(OnsetButton);
    }


    private void OnPlayButton()
    {
        //TODO 跳转到动态加载界面
        _progressPanel.SetActive(true);
        _progressPanel.GetComponent<progressPanel>().LoadNextLevel();
    }

    private void OnexplainButton()
    {
        //TODO 跳转到解释说明界面
        _memberPanel.gameObject.SetActive(true);
    }

    private void OnmemberButton()
    {
        //TODO 跳转到成员显示界面
        _explainPanel.gameObject.SetActive(true);
    }
    private void OnsetButton()
    {
        // TODO 跳转到设置界面
        //_SetPanel.gameObject.SetActive(true);
        // 在点击按钮时将 SetPanel 设置为激活状态
        /*GameObject setPanel = GameObject.Find("SetPanel");  // 根据名称找到 SetPanel
        if (setPanel != null)
        {
            setPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("在点击按钮时将 SetPanel 设置为激活状态");
        }*/
        _SetPanel.SetActive(true);
    }
}
