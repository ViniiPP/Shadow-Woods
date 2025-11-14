using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    Dino dino;
    EnemySpawn enemySpawn;
    GroundMovement groundmovement;
    Bird birdEnemy;
    Cactus groundEnemy;

    bool gameOver = false;

    void Start()
    {
        dino = FindFirstObjectByType<Dino>();
        enemySpawn = FindFirstObjectByType<EnemySpawn>();
        groundmovement = FindFirstObjectByType<GroundMovement>();
        birdEnemy = FindFirstObjectByType<Bird>();
        groundEnemy = FindFirstObjectByType<Cactus>();
    }

    void Update()
    {
        if (!gameOver)
        {
            if (birdEnemy == null)
                birdEnemy = FindFirstObjectByType<Bird>();

            if (groundEnemy == null)
                groundEnemy = FindFirstObjectByType<Cactus>();

            var dinoCol = dino.GetComponent<BoxCollider2D>();
            var birdCol = birdEnemy != null ? birdEnemy.GetComponent<BoxCollider2D>() : null;
            var groundCol = groundEnemy != null ? groundEnemy.GetComponent<BoxCollider2D>() : null;

            bool touchedBird = birdCol != null && dinoCol.IsTouching(birdCol);
            bool touchedGround = groundCol != null && dinoCol.IsTouching(groundCol);

            if (touchedBird || touchedGround)
            {
                gameOver = true;

                enemySpawn.stopSpawning = true;
                dino.isFreeze = true;

                SpeedGlobal.speed = 0;
                SpeedGlobal.isDead = true;

                Cactus[] allCactus = FindObjectsByType<Cactus>(FindObjectsSortMode.None);
                foreach (Cactus obj in allCactus)
                {
                    SpeedGlobal.speed = 0;
                    SpeedGlobal.isDead = true;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                PointUI.resetarPontos();

                SpeedGlobal.speed = SpeedGlobal.initialSpeed;
                SpeedGlobal.isDead = false;
                GroundMovement ground = GetComponent<GroundMovement>();
                ground.ResetAll();
                
                SceneManager.LoadScene(1);  

                return;
            }
        }
    }
}
