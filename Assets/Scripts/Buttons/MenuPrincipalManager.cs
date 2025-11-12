using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;

    public void jogar()
    {
        Time.timeScale = 1f; // Garante que o jogo não está pausado
        SpeedGlobal.isDead = false; // Reseta o estado "morto"
        SpeedGlobal.speed = SpeedGlobal.initialSpeed; // Reseta a velocidade

        SceneManager.LoadScene("Scence");
    }

    public void sairJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}