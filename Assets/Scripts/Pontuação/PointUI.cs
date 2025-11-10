using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static float score { get; set; }
    

    
    void Start() => AtualizarHUD();

    // Update is called once per frame
    public void AdicionarPontos(float pontos)
    {
        score += pontos;
        AtualizarHUD();
        
    }


    void AtualizarHUD()
    {
        scoreText.text = $"Pontos:{Mathf.RoundToInt(score)}";
    }
}
