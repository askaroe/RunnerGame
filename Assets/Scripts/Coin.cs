using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speedY = 0.5f;
    private void Update()
    {
        transform.Rotate(0, 360 * speedY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().CoinCollected();
            Destroy(this.gameObject);
        }
    }
}
