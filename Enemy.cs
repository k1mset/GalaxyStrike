using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyEffects;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 1;

    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            scoreboard.ModifyScore(scoreValue);
            Instantiate(destroyEffects, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
