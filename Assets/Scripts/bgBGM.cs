using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgBGM : MonoBehaviour
{
    public AudioSource alarmBGM;
    // Start is called before the first frame update
    void Start()
    {
        alarmBGM.Stop();//声音停止
        alarmBGM.loop = true;//设置声音为循环播放 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            alarmBGM.Play();//声音播放
        if (Input.GetKeyDown(KeyCode.R))
            alarmBGM.Stop();
        //if (alarmBGM.isPlaying)//声音是否正在播放
            //print("音乐正在播放");
    }
}
