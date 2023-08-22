using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulett : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 9f;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject.Destroy(gameObject, 5f);     //每个5秒自动销毁
    }

    public void InitDir(Dir dir)
    {
        Vector2 v2;

        switch (dir)
        {
            case Dir.Up:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                v2 = new Vector2(0, speed);
                _rigidbody2D.velocity = v2;       //刚体速度
                break;
            case Dir.Forward:
                //获取人物位置
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                //人物往右走
                if (player.rotation.y == 0)
                {
                    v2 = new Vector2(speed, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    v2 = new Vector2(-speed, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                _rigidbody2D.velocity = v2;       //刚体速度
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
