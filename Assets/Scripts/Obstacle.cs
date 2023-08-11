using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.Lose();
        }
    }
}
