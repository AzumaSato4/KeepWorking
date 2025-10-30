using UnityEngine;

public class SpotGenerator : MonoBehaviour
{
    [SerializeField] GameObject spotPrefab;

    private void Start()
    {
        GameObject obj = Instantiate(spotPrefab, transform.position, Quaternion.identity);
        obj.AddComponent<ResourceSpot>();
    }
}
