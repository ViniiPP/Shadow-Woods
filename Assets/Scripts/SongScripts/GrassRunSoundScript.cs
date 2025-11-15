using Unity.VisualScripting;
using UnityEngine;

public class GrassRunSoundScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GrassRunSoundScript instance;
    public AudioSource audio;
    public bool isStarted = false;
    public MapList currentMap = ManageMap.Instance.GetCurrentMap();


    void Awake()
    {
        instance = this;
    }
     void Update()
    {
        if (audio == null) return;

        if (currentMap == MapList.FirstMap && isStarted != true) {
            audio.Play();
            isStarted = true;
        }
        if (currentMap != MapList.FirstMap)
        {
            audio.Stop();
        }
    }

    
}
