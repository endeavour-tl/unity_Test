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
    //���ù��������false��ʾû�м��
    private bool wait = false;
    private float speed = 300;
    //��������ļ�ʱ��
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


        // ���û�������ƶ����������ٶ��㹻С����ֹͣ�ƶ�
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            _rigidbody2D.velocity *= 0.9f; // �𽥼�С�ٶ�
            if (_rigidbody2D.velocity.magnitude < 0.01f)
            {
                _rigidbody2D.velocity = Vector2.zero; // ֹͣ�ƶ�
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
        float h = Input.GetAxis("Horizontal");  //��ȡA D ������
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
        if (obj.tag == "Tree")// ����ע�⣬����tag��ͬ���иĶ���ֻ�������ҵ�����tag����Player
        {
            PANEL.SetActive(true);
        }

    }

    private void Fire(Dir dir)
    {
        //������Ӧ������
        SoundManege.Instance.PlayerMusicName("shoot");


        GameObject temp = Resources.Load<GameObject>("Prefabs/Bullet");  //����Resources��Prefabs/Bullet���ӵ�Ԥ����

        if (temp == null)
        {
            Debug.LogError("Resources.Load<GameObject>(\"Prefabs / Bullet\") is Empty");
        }

        switch (dir)
        {
            case Dir.Forward:
                curPoint = point[0];    //0 ��ǰ����
                break;
            case Dir.Up:
                curPoint = point[1];    //1���Ϸ���
                break;
        }
        //������Ӧ������
        GameObject GO = Instantiate(temp, curPoint.transform.position, Quaternion.identity);

        //��ʼ���ӵ�����
        GO.GetComponent<Bulett>().InitDir(dir);
    }
}
