using UnityEngine;

[RequireComponent(typeof(PlayerShooting))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private KeyCode _shootKey = KeyCode.Mouse0;
    private KeyCode _jumpKey = KeyCode.Space;

    private PlayerMover _playerMover;
    private PlayerShooting _playerShooting;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerShooting = GetComponent<PlayerShooting>();
    }

    void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
            _playerMover.FlyUp();
        else if (Input.GetKeyDown(_shootKey))
            _playerShooting.ShootBullet();
    }
}
