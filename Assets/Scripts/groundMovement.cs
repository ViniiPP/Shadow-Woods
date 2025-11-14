using Unity.VisualScripting;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [Header("FirstMap")]
    public Sprite[] groundSprites;
    public SpriteRenderer[] grounds;

    [Header("Transition")]
    public GameObject transitionMap;
    public GameObject removeGround;
    public GameObject removeBackGround;

    [Header("SecondMap")]
    public GameObject secondBackGround;   // vai ser instanciado

    public GameObject fullGroundCave;       // referência do objeto instanciado
    public Sprite[] groundSpritesCave;
    public SpriteRenderer[] groundsCave;
    public SpriteRenderer[] InstancegroundsCave;



    bool spawnedSecondBack = false;
    bool spawnedFullGround = false;

    bool startedTransition = false;

    Vector2 endPosition = new Vector2(-5.72f, -1f);
    Vector2 startPosition = new Vector2(6.00f, -1f);
    Vector2 caveStartPosition = new Vector2(9.98F, -1.252f);

    void Update()
    {
        SpeedGlobal.UpdateAceleration();

        switch (ManageMap.Instance.GetCurrentMap())
        {
            case MapList.FirstMap:
                
                for (int i = 0; i < grounds.Length; i++)
                {
                    grounds[i].transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime;

                    if (grounds[i].transform.position.x <= endPosition.x)
                    {
                        grounds[i].transform.position = startPosition;
                        grounds[i].sprite = groundSprites[Random.Range(0, groundSprites.Length)];
                    }
                }

      

                if (PointUI.score >= 600)
                {
                    ManageMap.Instance.SetCurrentMap(MapList.TransitionMap);

                 
                    transitionMap = Instantiate(transitionMap, new Vector2(6.5f, 1.07f), Quaternion.identity);
                    transitionMap.transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime;
                }

                break;
            case MapList.TransitionMap:

                if (!startedTransition)
                {
                    startedTransition = true;
                }

                transitionMap.transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime;

                removeGround.transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime;

                if (removeGround.transform.position.x <= endPosition.x - 10f)
                {
                    removeGround.SetActive(false);
                    Destroy(removeBackGround);
                }


                float largura = GetObjectWidth(transitionMap);    // ex: 30
                float limiteInterno = largura * 0.6f;             // ex: 30% dentro desses 30 → 9

                // x onde o transitionMap está agora
                float xAtual = transitionMap.transform.position.x;

                // quando a ponta esquerda dele passar esse limite interno
                if (xAtual <= (endPosition.x + limiteInterno))
                {
                    Debug.Log("⚠️ já passou do trecho interno da largura!");
                }
              
               if (PointUI.score >= 625)
                {
                    ManageMap.Instance.SetCurrentMap(MapList.SecondMap);
                }

                break;


            case MapList.SecondMap:

                if (!spawnedSecondBack)
                {
                    secondBackGround = Instantiate(secondBackGround, new Vector2(-0.547f, 1.33f), Quaternion.identity);
                    spawnedSecondBack = true;
                }

                if (!spawnedFullGround)
                {
                    groundsCave = fullGroundCave.GetComponentsInChildren<SpriteRenderer>();
                    spawnedFullGround = true;
                }

                for (int i = 0; i < groundsCave.Length; i++)
                {
                    groundsCave[i].transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime;

                    if (groundsCave[i].transform.position.x <= endPosition.x)
                    {
                        groundsCave[i].transform.position = caveStartPosition;
                        groundsCave[i].sprite = groundSpritesCave[Random.Range(0, groundSpritesCave.Length)];
                    }
                }

                // ✅ transição continua saindo
                if (transitionMap != null && !transitionMap.IsDestroyed())
                {
                    transitionMap.transform.position += Vector3.left * SpeedGlobal.speed * Time.deltaTime;

                    if (transitionMap.transform.position.x <= endPosition.x - 20f)
                        Destroy(transitionMap);
                }

                break;
        }
    }


    public static float GetObjectWidth(GameObject obj)
    {
        Bounds b = new Bounds(obj.transform.position, Vector3.zero);

        foreach (Renderer r in obj.GetComponentsInChildren<Renderer>())
            b.Encapsulate(r.bounds);

        return b.size.x;
    }

    public void ResetAll()
    {
        // destruir instanciados
        if (secondBackGround) Destroy(secondBackGround);
   
 

        // reset flags
        spawnedSecondBack = false;
        spawnedFullGround = false;
        startedTransition = false;

        // reset score
        PointUI.score = 0;

        // reset velocidade
        SpeedGlobal.speed = SpeedGlobal.initialSpeed;

        // reset mapa para o primeiro
        ManageMap.Instance.SetCurrentMap(MapList.FirstMap);

        // resetar posições iniciais do chão normal
        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.position = startPosition;
            grounds[i].sprite = groundSprites[Random.Range(0, groundSprites.Length)];
        }

        Debug.Log("✔️ RESET TOTAL FEITO — sem reload de cena");
    }

}


