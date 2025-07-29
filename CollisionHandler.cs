using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyVFX;
    GameSceneManager gameSceneManager;

    bool crashable = false;

    void Start()
    {
        StartCoroutine(MakeCrashable());
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    private IEnumerator MakeCrashable()
    {
        yield return new WaitForSeconds(1.5f);
        crashable = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (crashable)
        {
            Instantiate(playerDestroyVFX, this.transform.position, Quaternion.identity);
            gameSceneManager.ReloadLevel();
            Destroy(this.gameObject);
        }
    }
}
