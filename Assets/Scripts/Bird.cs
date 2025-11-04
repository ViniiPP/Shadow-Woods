using UnityEngine;

public class Bird : MonoBehaviour
{




    void Start()
    {
        
    }

    void Update()
    {

        SpeedGlobal.UpdateAceleration();
        transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime * 1.2f ;
        if (transform.position.x <= -5)
        {
            Destroy(gameObject);
        }

    }
}
