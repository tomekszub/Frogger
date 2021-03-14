using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    [SerializeField]
    Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.ArrivedSafe();
    }
}
