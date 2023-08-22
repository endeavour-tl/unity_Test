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

    private GameObject _parent;  // �����壬����������ͬ����� Panel

    private void Start()
    {
        _PlayButton = transform.Find("PlayButton").GetComponent<Button>();
        _explainButton = transform.Find("explainButton").GetComponent<Button>();
        _memberButton = transform.Find("memberButton").GetComponent<Button>();
        _setButton = transform.Find("setButton").GetComponent<Button>();

        _parent = transform.parent.gameObject;  // ��ȡ������

        /*_StartPanel = GameObject.Find("StartPanel").GetComponent<Panel>();
        //_memberPanel = _parent.transform.Find("memberPanel").GetComponentInChildren<Panel>();
        _memberPanel = GameObject.FindGameObjectWithTag("memberPanel").GetComponent<Panel>();//memberPanel
        _explainPanel = _parent.transform.Find("explainPanel").GetComponent<Panel>();*/
        //_SetPanel = _parent.transform.Find("SetPanel").GetComponentInChildren<GameObject>();

        if (_memberPanel != null)
        {
            // ����������Բ��� _setPanel
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
        //TODO ��ת����̬���ؽ���
        _progressPanel.SetActive(true);
        _progressPanel.GetComponent<progressPanel>().LoadNextLevel();
    }

    private void OnexplainButton()
    {
        //TODO ��ת������˵������
        _memberPanel.gameObject.SetActive(true);
    }

    private void OnmemberButton()
    {
        //TODO ��ת����Ա��ʾ����
        _explainPanel.gameObject.SetActive(true);
    }
    private void OnsetButton()
    {
        // TODO ��ת�����ý���
        //_SetPanel.gameObject.SetActive(true);
        // �ڵ����ťʱ�� SetPanel ����Ϊ����״̬
        /*GameObject setPanel = GameObject.Find("SetPanel");  // ���������ҵ� SetPanel
        if (setPanel != null)
        {
            setPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("�ڵ����ťʱ�� SetPanel ����Ϊ����״̬");
        }*/
        _SetPanel.SetActive(true);
    }
}
