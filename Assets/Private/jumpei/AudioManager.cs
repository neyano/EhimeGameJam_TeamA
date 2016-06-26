using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour{


    /*BGM*/
    [SerializeField]
    private AudioClip startMusic;
    [SerializeField]
    private AudioClip gameMusic;
    [SerializeField]
    private AudioClip staffRollMusic;
    [SerializeField]
    private AudioClip lessTimeMusic;


    /*SE*/
    [SerializeField]
    private AudioClip successSE;
    [SerializeField]
    private AudioClip failedSE;
    [SerializeField]
    private AudioClip tapSE;
    [SerializeField]
    private AudioClip buttonSE;


    private AudioSource audio;

    public static AudioManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        audio = this.gameObject.GetComponent<AudioSource>();
    }   
 
    public void PlayeStartMusic()
    {
        audio.clip = startMusic;
        audio.Play();
    }

    public void PlayGameMusic()
    {
        audio.clip = gameMusic;
        audio.Play();
    }

    public void PlayStaffRollMusic()
    {
        audio.clip = staffRollMusic;
        audio.Play();
    }

    public void PlayLessTimeMusic()
    {
        audio.clip = lessTimeMusic;
        audio.Play();
        
    }



    public void ButtonSE()
    {
        audio.PlayOneShot(buttonSE);
    }
    public void SuccessSE()
    {
        audio.PlayOneShot(successSE);
    }
    public void FailedSE()
    {
        audio.PlayOneShot(failedSE);
    }
    public void TapSE()
    {
        audio.PlayOneShot(tapSE);
    }



}
