using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;




public static class SpeedGlobal 
{

    public const float initialSpeed = 5f;
    public static float speed = 5f ;
    public static float maxSpeed  = 12f;
    public static float acceleration = 0.03f;
    public static bool isDead = false;

    public static void UpdateAceleration ()
    {
       if (speed == 5)
        {
            isDead = false;
        }
       if (isDead) speed= 0;

       if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }
    }
}
