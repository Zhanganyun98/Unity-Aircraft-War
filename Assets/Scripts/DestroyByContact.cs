using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    public AudioClip audioClip;
    public AudioClip playerAudioClip;

   // public AudioSource audioSource;

    [Header("加分数")]
    public int addScore = 10;
  
    private int damage=10;//对玩家的伤害
    private GameController _gameController;

    private void Awake()
    {
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
    }
    //当其他碰撞器进入当前GameObject的触发器时，销毁该碰撞器对应的游戏对象，同时销毁该GameObject
    void OnTriggerEnter(Collider other)
    {
        //如果碰到的是玩家子弹
        if ( other.tag == "bullet")
        {
            _gameController.GetScore(addScore);//调用加分方法

            Instantiate(playerExplosion,transform.position,transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
           // audioSource.GetComponent<AudioSource>().Play();
            
            AudioSource.PlayClipAtPoint(audioClip,transform.position);
        }
        //如果碰到的是玩家
        if (other.tag == "Player")
        {
            _gameController.GetHp(damage);//调用扣血方法

            Instantiate(playerExplosion, transform.position, transform.rotation);

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(playerAudioClip, transform.position);
        }


    }
}