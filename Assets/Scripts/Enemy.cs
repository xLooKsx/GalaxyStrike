using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int healthPoints = 6;
    [SerializeField] int scoreValue = 3;

    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessDamage();
    }

    private void ProcessDamage()
    {
        healthPoints--;
        if (healthPoints <= 0)
        {
            scoreboard.UpdateScore(scoreValue);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
