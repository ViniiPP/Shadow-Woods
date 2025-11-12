using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

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
        Time.timeScale = 1f; // Despausa o jogo
        SpeedGlobal.isDead = false; // Reseta o estado "morto"
        SpeedGlobal.speed = SpeedGlobal.initialSpeed; // Reseta a velocidade

        SceneManager.LoadScene("Scence");
    }

    public void SairDoJogo()
    {
        Time.timeScale = 1f;
        SpeedGlobal.isDead = false;
        SpeedGlobal.speed = SpeedGlobal.initialSpeed;

        Debug.Log("Saindo do jogo...");
        Application.Quit();
        SceneManager.LoadScene("Menu");
    }
}