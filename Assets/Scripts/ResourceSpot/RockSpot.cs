using UnityEngine;

public class RockSpot : ResourceSpot
{
    [SerializeField] SpotStatus status;

    private void Awake()
    {
        spotStatus = status;
    }
}
