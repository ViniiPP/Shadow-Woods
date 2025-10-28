using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => AtualizarHUD();

    // Update is called once per frame
    public void AdicionarPontos(int pontos)
    {
        score += pontos;
        AtualizarHUD();
    }


    void AtualizarHUD()
    {
        scoreText.text = $"Pontos: {score}";
    }
}
