using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallaxable : MonoBehaviour
{
    [SerializeField] private float parallaxFactor = 0.5f;
    [SerializeField] private bool useGlobalSpeed = true;
    [SerializeField] private float overlapOffset = 0.05f;

    private float spriteWidth;
    private Camera cam;
    private Vector3 startPos;

    void Start()
    {
        cam = Camera.main;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        spriteWidth = sprite.bounds.size.x;
        startPos = transform.position;
    }

    void Update()
    {
        float moveSpeed = useGlobalSpeed ? SpeedGlobal.speed : 5f;
        float moveX = moveSpeed * parallaxFactor * Time.deltaTime;

     
        transform.position += Vector3.left * moveX;

        float cameraLeftEdge = cam.transform.position.x - cam.orthographicSize * cam.aspect;

       
        if (transform.position.x + spriteWidth / 2 < cameraLeftEdge - overlapOffset)
        {
            transform.position += Vector3.right * spriteWidth * 1.9f;
        }
    }
}
