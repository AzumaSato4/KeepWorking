using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _BGMAudio;

    void Update()
    {
        if (GameManager.currentState == GameManager.GameState.end) _BGMAudio.Stop();
    }
}
