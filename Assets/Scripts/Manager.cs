using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    Dino dino;
    EnemySpawn enemySpawn;
    GroundMovement groundmovement;

    bool gameOver = false;

    void Start()
    {
        dino           = FindFirstObjectByType<Dino>();
        enemySpawn     = FindFirstObjectByType<EnemySpawn>();
        groundmovement = FindFirstObjectByType<GroundMovement>();

    }
    void Update()
    {

        if (!gameOver)
        {

        
            if (Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, 0, LayerMask.GetMask("Enemy")).Length > 0) {

                gameOver = true;
                // colidiu
                enemySpawn.stopSpawning = true;

                SpeedGlobal.speed = 0;

                Cactus[] allCactus = FindObjectsByType<Cactus>(FindObjectsSortMode.None);
                foreach (Cactus obj in allCactus)
                    SpeedGlobal.speed = 0;
                    SpeedGlobal.isDead = true;
                

            }
        } else {
            // restart
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
