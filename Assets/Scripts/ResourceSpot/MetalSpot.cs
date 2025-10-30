using UnityEngine;

public class MetalSpot : ResourceSpot
{
    [SerializeField] SpotStatus status;

    private void Awake()
    {
        spotStatus = status;
    }
}
