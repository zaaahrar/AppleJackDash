using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    private const int NumberStartScene = 0;

    public void Die() => _sceneLoader.LoadScene(NumberStartScene);
}
