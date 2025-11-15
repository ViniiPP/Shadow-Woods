using UnityEngine;

public class JumpSong : MonoBehaviour 
{
    public static JumpSong instance;
    public AudioSource audio;



    void Awake()
    {
        instance = this;
    }
    public void playSong ()
    {
        audio.Play();
    }
}
