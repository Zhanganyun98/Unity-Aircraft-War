using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{

    private float MoveSpeed = 1.0f;//背景移动速度
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);//移动
        if (transform.position.z <= -30)//如果z轴小于-30
        {
            transform.position = new Vector3(0, 0, 30);//循环位置
        }

    }
}