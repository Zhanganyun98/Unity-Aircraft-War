using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingScore : MonoBehaviour
{
    private GameController _gameController;
    private Text ScoreText;
    private void Awake()
    {
       
    }
    private void Start()
    {
        _gameController = GetComponent<GameController>();
        ScoreText = GameObject.Find("Prefab/Score").GetComponent<Text>();
        //ScoreText.text = _gameController.Score.ToString();
        ScoreText.text = PlayerPrefs.GetInt("High").ToString();
    }
    private void Update()
    {
        
      

    }

}

/*
 public class RankingScore : MonoBehaviour
{
    public GameObject L0;
    public GameObject[] newIndexs;
    public GameObject Panel;
    public Text indexText;
    int indexM;
    //用来把取的数赋值于此
    public  int[] save = new int [8];
    int Num;
    string  saveIntStr;

    //插入排序
    // Use this for initialization
    void
     Start()
    {
        //获取上一场景存储的数据
        indexM = PlayerPrefs.GetInt( "indexM" );
        indexText.text ="点击次数："+ indexM.ToString();

        //获取存储的排行榜中的数据
        for(int i = 0; i < 8; i++)
        {
            string saveIntStrS = saveIntStr + i.ToString();
            save[0]= PlayerPrefs.GetInt(saveIntStrS);
        }
        //添加新数据并排序（从小到大）
        for (int i = 0; i < 8; i++)
        {
            if
             (save[/ font][/ size][font = 微软雅黑][size = 3] == null || save[/ size][/ font][font = 微软雅黑][size = 3] == 0)
            {
              save[/ size][/ font][font = 微软雅黑][size = 3] = indexM;
                Num = i;
                for ( int  m = 0; m < Num + 1; ++m)
                {
                    int t = save[m];
                    int n = m;
                    while
                     ((n > 0) && (save[n - 1] > t))
                    {
                        save[n] = save[n - 1];
                        --n;
                    }
                    save[n] = t;
                }
                break;
            }
            else
            {
                int
                 n = 7;
                if
                 (indexM < save[7])
                {
                    while
                     (save[n - 1] > indexM)
                    {
                        save[n] = save[n - 1];
                        --n;
                        save[n] = indexM;
                        if
                         (n == 0)
                        {
                            break  ;
                        }
                    }
                    break              ;
                }
            }
        }
        //把当前数据存储
        for
         (int j = 0; j < 8; j++)
        {
            string saveIntStrI = saveIntStr + j.ToString();
            PlayerPrefs.SetInt(saveIntStrI, save[j]);
            //PlayerPrefs.SetInt(saveIntStrI, 0);
        }

        //将数据显示到场景UI中
        for
         (
        int
         i = 0; i < newIndexs.Length; i++)
        {
            string saveIntStrO = saveIntStr + i.ToString();
            newIndexs[indexM] = Instantiate(L0, transform.position, transform.rotation)
            as GameObject;
            newIndexs[/ size][/ font][font = 微软雅黑][size = 3].transform.SetParent(Panel.transform);
            newIndexs[/ size][/ font][font = 微软雅黑][size = 3].GetComponent<Text>().text = PlayerPrefs.GetInt(saveIntStrO).ToString();
        }
    }
    void
     Update()
    {

    }
    public void reStart()
    {
        SceneManager.LoadScene("Scene1" );
    }
}

*/