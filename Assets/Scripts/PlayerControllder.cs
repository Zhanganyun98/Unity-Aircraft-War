using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    [Header("边界控制")]
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControllder : MonoBehaviour
{
    [Header("炮弹预设体")]
    public GameObject bullet;
    [Header("移动速度")]
    public float Speed = 5f;
    public Boundary boundary;
    public float tilt=4f;
    public Transform shotSpawn;//炮弹发射点
    [Header("玩家开炮声音")]
    public AudioClip fireClip;

    private GameObject bolt;
    private Rigidbody rb;
  
    private float fireRate=0.2f;//发射间隔
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       Fire();
        
    }
    public void Fire()
    {
        if (Input.GetButton("Fire") && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            bolt = Instantiate(bullet,transform.position,Quaternion.identity);
            AudioSource.PlayClipAtPoint(fireClip,transform.position);

            
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * Speed;

        //飞机边界设置
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        //飞机侧身
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
