using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ResourceSpotFactory _resourceSpotFactory;
    public static ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = gameObject.AddComponent<ResourceManager>();
        resourceManager.Initialize();

        for (int i = 0; i < 30; i++)
        {
            _resourceSpotFactory.GenerateSpot();
        }
    }
}
