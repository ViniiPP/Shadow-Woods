using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    private GroundMovement groundMovement;

    void Start()
    {
        groundMovement = FindFirstObjectByType<GroundMovement>();
    }

    public void MostrarTelaGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Pausa o jogo
        }
    }

    public void TentarNovamente()
    {
        // Despausa o jogo
        Time.timeScale = 1f;

        // Reseta os pontos
        PointUI.resetarPontos(); 

        // Reseta as variáveis globais de velocidade
        SpeedGlobal.speed = SpeedGlobal.initialSpeed; 
        SpeedGlobal.isDead = false; 

        // Reseta o movimento do chão
        if (groundMovement != null)
        {
            groundMovement.ResetAll(); 
        }
        else
        {
            // Aviso caso não encontre o script
            Debug.LogWarning("GameOverManager não conseguiu encontrar o GroundMovement!");
        }

        // Recarrega a cena
        SceneManager.LoadScene("Scence");
    }

    public void SairDoJogo()
    {
        Time.timeScale = 1f; 
        SpeedGlobal.isDead = false; 
        SpeedGlobal.speed = SpeedGlobal.initialSpeed; 
        PointUI.resetarPontos(); 

        Debug.Log("Saindo do jogo...");
        Application.Quit();
        SceneManager.LoadScene("Menu"); 
    }
}