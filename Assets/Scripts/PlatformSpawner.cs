using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundPlatform;
    private Vector3 _nextSpawnPoint;
    [SerializeField] private GameObject[] platformTiles;

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    public void SpawnPlatform()
    {
        GameObject temp = Instantiate(groundPlatform, _nextSpawnPoint, Quaternion.identity);
        _nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }
}
