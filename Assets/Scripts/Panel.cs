using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    private Button nextWord1;
    private Button nextWord2;
    private Text text1;
    private Text text2;

    /*private void Awake()
    {
        gameObject.SetActive(false);
    }*/
    void Start()
    {
        nextWord1 = transform.Find("Button1").GetComponent<Button>();
        nextWord2 = transform.Find("Button2").GetComponent<Button>();
        text1 = transform.Find("Text1").GetComponent<Text>();
        text2 = transform.Find("Text2").GetComponent<Text>();
        nextWord1.onClick.AddListener(OnNext1);
        nextWord2.onClick.AddListener(OnNext2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnNext1()
    {
        text1.gameObject.SetActive(false);
        nextWord1.gameObject.SetActive(false);
        //Debug.LogWarning("DWAD");
        text2.gameObject.SetActive(true);
        nextWord2.gameObject.SetActive(true);
        //Debug.LogWarning("DWAD21414");
    }
    private void OnNext2()
    {
        gameObject.SetActive(false);
    }
    
}
