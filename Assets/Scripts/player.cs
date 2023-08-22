using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    Up,
    Forward,
}


public class player : MonoBehaviour
{

    public KeyCode W_Key;
    public KeyCode S_key;
    public KeyCode A_key;
    public KeyCode D_key;

    public Transform[] point; //0 UP, 1 ForWard
    private Transform curPoint;
    public GameObject PANEL;
    //设置攻击间隔，false表示没有间隔
    private bool wait = false;
    private float speed = 300;
    //间隔攻击的计时器
    private float timer = 0;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        PANEL.SetActive(false);
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playMove();


        // 如果没有输入移动按键并且速度足够小，则停止移动
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            _rigidbody2D.velocity *= 0.9f; // 逐渐减小速度
            if (_rigidbody2D.velocity.magnitude < 0.01f)
            {
                _rigidbody2D.velocity = Vector2.zero; // 停止移动
            }
        }

        if (Input.GetKeyDown(KeyCode.L) && wait == false)
        {
            wait = true;
            Fire(Dir.Forward);
            //playerAnim.PlayShootAnim();
        }
        if (Input.GetKeyDown(KeyCode.W) && wait == false)
        {
            wait = true;
            Fire(Dir.Up);
            //playerAnim.PlayShootupAnim();
        }
        if (wait)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                wait = false;
                timer = 0;
            }
        }
    }

    private void playMove()
    {
        float h = Input.GetAxis("Horizontal");  //获取A D 键操作
        //Debug.Log("h = " + h);
        if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody2D.velocity = new Vector2(h * speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
            //playerAnim.PlayWalkAnim();
        }
        else if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _rigidbody2D.velocity = new Vector2(h * speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

            //playerAnim.PlayWalkAnim();
        }
        else
        {
            //playerAnim.PlayIdleAnim();
        }
        float L = Input.GetAxis("Vertical");
        if (L > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, L * speed * Time.fixedDeltaTime);
        }
        else if(L < 0)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, L * speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Tree")// 这里注意，根据tag不同自行改动，只是这里我的物体tag叫做Player
        {
            PANEL.SetActive(true);
        }

    }

    private void Fire(Dir dir)
    {
        //播放相应的音乐
        SoundManege.Instance.PlayerMusicName("shoot");


        GameObject temp = Resources.Load<GameObject>("Prefabs/Bullet");  //加载Resources的Prefabs/Bullet下子弹预制体

        if (temp == null)
        {
            Debug.LogError("Resources.Load<GameObject>(\"Prefabs / Bullet\") is Empty");
        }

        switch (dir)
        {
            case Dir.Forward:
                curPoint = point[0];    //0 向前发射
                break;
            case Dir.Up:
                curPoint = point[1];    //1向上发射
                break;
        }
        //生成相应的物体
        GameObject GO = Instantiate(temp, curPoint.transform.position, Quaternion.identity);

        //初始化子弹方向
        GO.GetComponent<Bulett>().InitDir(dir);
    }
}
