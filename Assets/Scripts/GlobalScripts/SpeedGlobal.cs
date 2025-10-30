using Unity.VisualScripting;
using UnityEngine;




public static class SpeedGlobal 
{

    public static float speed = 4f ;
    public static float maxSpeed  = 15f;
    public static float acceleration = 0.02f;
    public static bool isDead = false;

    public static void UpdateAceleration ()
    {

       if (isDead) speed= 0;

       if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }
    }
}
