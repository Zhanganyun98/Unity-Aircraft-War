using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Score1 : MonoBehaviour
{

    public List<Score> scoreList = new List<Score>();

    public StreamReader sr = new StreamReader(Application.dataPath + "Resources/RankingList.txt");
    public string nextLine;

    private string Name;
    private int numScore;
    private GameController _gameController;
    private float score2;
    private Transform Item;
    public void Awake()
    {
        _gameController = GetComponent<GameController>();
        Item = GameObject.Find("RankingList/Item").transform;

        while ((nextLine = sr.ReadLine()) != null)
        {
            scoreList.Add(JsonUtility.FromJson<Score>(nextLine));
        }
        sr.Close();
    }
    public void s1()
    {
        score2 = _gameController.crtScore1;
        scoreList.Add(new Score(Name, numScore));
    }

    /// <summary>
    /// 当用户点击排行榜按钮时
    /// </summary>
    public void s2()
    {
        scoreList.Sort();
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/RankingList.txt");
        if (scoreList.Count > 10) for (int i = 10; i <= scoreList.Count; i++) scoreList.RemoveAt(i);
        for (int i = 0; i < scoreList.Count; i++)
        {
            sw.WriteLine(JsonUtility.ToJson(scoreList[i]));
            Debug.Log(scoreList[i].ToString());
        }
        sw.Close();


        for (int i = 0; i < scoreList.Count; i++)
        {
            GameObject item = Instantiate(Item.gameObject);
            item.gameObject.SetActive(true);
            item.transform.SetParent(Item.parent, false);
            item.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
            item.transform.Find("Name").GetComponent<Text>().text = scoreList[i].name;
            item.transform.Find("Score").GetComponent<Text>().text = scoreList[i].score.ToString();
        }

    }


    public class Score : System.IComparable<Score>
    {
        public string name;
        public int score;
        public Score(string n, int s) { name = n; score = s; }
        public int CompareTo(Score other)
        {
            if (other == null)
                return 0;
            int value = other.score - this.score;
            return value;
        }
        public override string ToString()//debug用
        {
            return name + " : " + score.ToString();
        }


    }
}
