using UnityEngine;

public class Status<T> : MonoBehaviour where T : ScriptableObject
{
    [SerializeField] T _mainStatus;
    public T MainStatus => _mainStatus;
}
