using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ResourceSpotFactory _resourceSpotFactory;
    [SerializeField] UIManager _UIManager;
    public static ResourceManager resourceManager;

    [SerializeField] float _timer = 300; //残り時間
    public float Timer => _timer;

    private void Start()
    {
        resourceManager = gameObject.AddComponent<ResourceManager>();
        resourceManager.Initialize();
        _UIManager.Initialize();

        for (int i = 0; i < 30; i++)
        {
            _resourceSpotFactory.GenerateSpot();
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
    }
}
