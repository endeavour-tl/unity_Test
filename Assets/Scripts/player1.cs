using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{

    public KeyCode U_Key;
    public KeyCode J_Key;
    public KeyCode H_Key;
    public KeyCode K_Key;

    private float speed = 300;
    private Rigidbody2D _rigidbody2D;

    private float keyDownTime = 0f;

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
    }

    private void playMove()
    {
        float h = 0;
        float L = 0;
        if (Input.GetKeyDown(U_Key) || Input.GetKeyDown(J_Key) || Input.GetKeyDown(H_Key) || Input.GetKeyDown(K_Key))
        {
            keyDownTime = Time.time;  // 记录按键按下的时间
        }

        if (Input.GetKey(U_Key))
        {
            Debug.LogError("U_Key");
            L = CalculateMoveFactor();  // 动态计算移动系数
            //L = 1;
        }
        else if (Input.GetKey(J_Key))
        {
            //L = -1;
            Debug.LogError("J_Key");
            L = - CalculateMoveFactor();
        }

        if (Input.GetKey(H_Key))
        {
            h = -CalculateMoveFactor();
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(K_Key))
        {
            h = CalculateMoveFactor();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        Debug.Log("h = " + h);
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
        //float L = Input.GetAxis("Vertical");
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
    private float CalculateMoveFactor()
    {
        // 根据按键按下的时间计算移动系数
        float timeSinceKeyDown = Time.time - keyDownTime;
        return Mathf.Clamp(timeSinceKeyDown, 0.7f, 1f);  // 最小为1，按键按下的时间越长，系数越大
    }
}
