using UnityEngine;

public class PlatformTile : MonoBehaviour
{
    PlatformSpawner platformSpawner;

    private void Start()
    {
        platformSpawner = GameObject.FindObjectOfType<PlatformSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        platformSpawner.SpawnPlatform();
        Destroy(this.gameObject, 6f);
    }
}
