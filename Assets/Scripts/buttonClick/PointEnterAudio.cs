using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointEnterAudio : MonoBehaviour,IPointerEnterHandler
{
    private AudioSource audioSource;
    private AudioClip clip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("weapon_player");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
