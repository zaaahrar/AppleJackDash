using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy _))
            _player.Die();

        if (collision.TryGetComponent(out Bullet _))
            _player.Die();

        if (collision.TryGetComponent(out Border _))
            _player.Die();
            
    }
}
