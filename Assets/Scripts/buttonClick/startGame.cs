using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour
{
    //[Header("鼠标移入声效")]
   // public AudioClip _audioClip;
    private Button btn;
    private AudioSource audioSource;
    private  AudioClip clip;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickStartGame);

    }
    private void OnClickStartGame()
    {
       //切换场景
        SceneManager.LoadScene("Main");
    }

}
