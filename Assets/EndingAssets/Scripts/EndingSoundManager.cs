using UnityEngine;

public class EndingSoundManager : MonoBehaviour
{
    public enum SE_Type
    {
        cancel
    }

    [SerializeField] AudioSource BGMAudio;
    [SerializeField] AudioSource SEAudio;

    [SerializeField] AudioClip[] SEClips;

    public void PlaySE(SE_Type type)
    {
        SEAudio.PlayOneShot(SEClips[(int)type]);
    }
}
