using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject playerExplosionVFX;

    GameSceneManager gameSceneManager;
    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
    
    gameSceneManager.ReloadLevel();
    Instantiate(playerExplosionVFX, transform.position, Quaternion.identity);
    Destroy(gameObject);
    // Debug.Log($"Acho que colidi com o {other.gameObject.name}, desculpa!");
    }
}
