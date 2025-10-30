using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ResourceSpotFactory resourceSpotFactory;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            resourceSpotFactory.GenerateSpots();
        }
    }
}
