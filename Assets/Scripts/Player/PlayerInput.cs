using UnityEngine;

[RequireComponent(typeof(PlayerShooting))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerShooting _playerShooting;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerShooting = GetComponent<PlayerShooting>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _playerMover.FlyUp();
        else if (Input.GetKeyDown(KeyCode.Mouse0))
            _playerShooting.ShootBullet();
    }
}
