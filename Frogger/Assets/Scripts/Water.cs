using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.AppearedOverWater();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.NoLongerOverWater();
    }
}
