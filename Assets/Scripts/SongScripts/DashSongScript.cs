using UnityEngine;

public class DashSongScript : MonoBehaviour
{
    public static DashSongScript instance;
    public AudioSource audio;



    void Awake()
    {
        instance = this;
    }
    public void playSong()
    {
        audio.Play();
    }

}
