using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    Dino dino;
    EnemySpawn enemySpawn;
    GroundMovement groundmovement;
    Fly birdEnemy;
    Cactus groundEnemy;
    GameOverManager gameOverManager; 

    bool gameOver = false;

    void Start()
    {
        dino = FindFirstObjectByType<Dino>();
        enemySpawn = FindFirstObjectByType<EnemySpawn>();
        groundmovement = FindFirstObjectByType<GroundMovement>();
        birdEnemy = FindFirstObjectByType<Fly>();
        groundEnemy = FindFirstObjectByType<Cactus>();

        gameOverManager = FindFirstObjectByType<GameOverManager>(); 
    }

    void Update()
    {
        if (!gameOver)
        {
            if (birdEnemy == null)
                birdEnemy = FindFirstObjectByType<Fly>();

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

                if (gameOverManager != null)
                {
                    gameOverManager.MostrarTelaGameOver(); 
                }
            }
        }
        else
        {
            // LÓGICA DO 'R' REMOVIDA
            // aa lógica agora está no GameOverManager.TentarNovamente()
        }
    }
}