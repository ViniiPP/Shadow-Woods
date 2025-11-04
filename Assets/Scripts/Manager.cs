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
            // reatribui caso algum inimigo tenha sido destruído
            if (birdEnemy == null)
                birdEnemy = FindFirstObjectByType<Bird>();

            if (groundEnemy == null)
                groundEnemy = FindFirstObjectByType<Cactus>();

            // obtém os colliders
            BoxCollider2D dinoCol = dino.GetComponent<BoxCollider2D>();
            BoxCollider2D birdCol = birdEnemy != null ? birdEnemy.GetComponent<BoxCollider2D>() : null;
            BoxCollider2D groundCol = groundEnemy != null ? groundEnemy.GetComponent<BoxCollider2D>() : null;

            // verifica colisão real com qualquer um dos dois inimigos
            bool touchedBird = (birdCol != null && dinoCol.IsTouching(birdCol));
            bool touchedGround = (groundCol != null && dinoCol.IsTouching(groundCol));

            if (touchedBird || touchedGround)
            {
                gameOver = true;

                enemySpawn.stopSpawning = true;
                dino.isFreeze = true;

                SpeedGlobal.speed = 0;
                SpeedGlobal.isDead = true;

                // congela os cactus existentes
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
            // restart
            if (Input.GetKeyDown(KeyCode.R))
            {
                dino.isFreeze = false;
                SpeedGlobal.speed = SpeedGlobal.initialSpeed;
                SceneManager.LoadScene(1);
            }
        }
    }
}
