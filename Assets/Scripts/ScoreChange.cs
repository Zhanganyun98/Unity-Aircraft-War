using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChange : MonoBehaviour
{
    public static ScoreChange Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int NowScore;
    public Text TScore;
    public int Speed;

    public void AddScore(int Score)
    {
        StartCoroutine(ScoreUP(Score));
    }
    IEnumerator ScoreUP(int Score)
    {
        int Increment = Score / Speed;
        if (Score <= Speed)
        {
            Increment = 1;
        }
        int tempscore = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.005f);
            if (tempscore + Increment >= Score)
            {
                NowScore += Score - tempscore;
                TScore.text = NowScore.ToString();
                break;
            }
            else
            {
                NowScore += Increment;
                TScore.text = NowScore.ToString();
            }
            tempscore += Increment;
        }
    }
    public void Test(int Score)
    {
        AddScore(Score);
    }
}