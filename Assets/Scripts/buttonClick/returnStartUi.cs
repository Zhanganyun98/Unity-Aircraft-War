using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnStartUi : MonoBehaviour
{
    private GameObject gameController;
    private void Awake()
    {
        gameController = GameObject.Find("GameController");
    }
    public void returnUI()
    {
        //将排行榜的Panel激活
        gameController.transform.GetChild(1).gameObject.SetActive(false);
    }

}
