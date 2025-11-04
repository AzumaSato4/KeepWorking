using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    public enum SE_Type
    {
        click,
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
