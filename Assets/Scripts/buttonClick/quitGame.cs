using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour
{
    private Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(quitgame);
    }
    public  void quitgame()
    {
        Application.Quit();

    }


}
