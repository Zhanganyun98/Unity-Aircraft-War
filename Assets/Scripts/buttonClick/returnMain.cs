﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnMain : MonoBehaviour
{
    public void ReturnMain()
    {
        SceneManager.LoadScene("StartGameUI");
    }


}
