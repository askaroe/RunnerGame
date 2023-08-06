using UnityEngine;

public class PlatformTile : MonoBehaviour
{
    PlatformSpawner platformSpawner;

    private void Start()
    {
        platformSpawner = GameObject.FindObjectOfType<PlatformSpawner>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        platformSpawner.SpawnPlatform();
        Destroy(this.gameObject, 2f);
    }
}
