using UnityEngine;

public class Cactus : MonoBehaviour
{
  
    
    void Start()
    {
  
    }
    void Update()
    {

        float speedCactus = SpeedGlobal.speed * 1.1f;
        SpeedGlobal.UpdateAceleration();
        transform.position += Vector3.left * speedCactus * Time.deltaTime;
        if (transform.position.x <= -5)
        {
            Destroy(gameObject);
        }
    }
}
