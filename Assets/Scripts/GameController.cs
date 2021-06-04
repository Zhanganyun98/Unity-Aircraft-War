using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("敌人的预设体")]
    public GameObject[] hazards;
    public Vector3 spawnValues;
    [Header("一批敌人的数量")]
    public int hazardCound = 10;
    [Header("一批中，单个敌人生成间隔")]
    public float spawnWait = 0.5f;
    [Header("开始的暂停时间")]
    public float startWait = 1f;
    [Header("两批敌人之间的间隔时间")]
    public float waveWait = 4;
    [Header("背景音乐")]
    public AudioSource alarmBGM;

    private Text fraction;//记录分数的Text
    private Slider hp;

    [HideInInspector]
    public int crtScore1 = 0;//游戏分数
    [HideInInspector]
    public int Score=0;//最高分数
    private int crtHp=100;//当前血量
    private Text gameOverText;
    private Transform continues;
    private Text _againText;


    private GameObject player;

    private bool gameOver=false;

    void Start()
    {
        StartCoroutine(SpawnWaves()); 
        fraction = GameObject.Find("Panel/fraction/score").GetComponent<Text>();
        hp = GameObject.Find("Panel/HP").GetComponent<Slider>();
        player = GameObject.FindWithTag("Player");
        gameOverText = GameObject.Find("Panel/gameOver").GetComponent<Text>();

        continues = GameObject.Find("Panel/again").transform ;
        _againText= GameObject.Find("again/againText").GetComponent<Text>();
        // alarmBGM.Stop();//音乐停止
        alarmBGM.loop = true;//开启音乐循环
    }

    private void Update()
    {
        fraction.text = crtScore1.ToString();
        hp.value = crtHp;
        Death();
        //血量>0时播放背景音乐
        // if (Input.GetKeyDown(KeyCode.E))
        //  alarmBGM.Play();
    }

    /// <summary>
    /// 加分方法
    /// </summary>
    /// <param name="scores"></param>
    public void GetScore(int scores)
    {
        crtScore1 += scores;
    }
    /// <summary>
    /// 玩家扣血方法
    /// </summary>
    /// <param name="damage"></param>
    public void GetHp(int damage)
    {
        crtHp -= damage;
    }
    private void Death()
    {
        if (crtHp<0)
        {
            Destroy(player);
            //血量小于0时停止播放背景音
            alarmBGM.Stop();

            gameOver = true;
            gameOverText.text = "Game Over!"+"总分数"+crtScore1;

            if (crtScore1>Score)
            {
                Score = crtScore1;
                //将最高分数存储
                PlayerPrefs.SetInt("High",Score);
            }
        }

    }
    private void again()
    {
        _againText.text = "是否重来!";
        continues.transform.GetChild(1).gameObject.SetActive(true);
        continues.transform.GetChild(2).gameObject.SetActive(true);
        // continues.SetActive(true);
        // continues.gameObject.SetActive(true);
        //continues.enabled = true;
        //continues.gameObject.transform.GetChild(0);
        //continues.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("找到再来一次的组件了");
    }

    IEnumerator SpawnWaves()
    {
        int number = 0;
        yield return new WaitForSeconds(startWait);
        while (number<10)
        {
            for (int i=0;i<hazardCound; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
                Instantiate(hazard,spawnPosition,Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            number++;
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                Invoke("again", 2);
                break;
            }

        }

    }



}
