using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCreate : MonoBehaviour, ICreatable
{
    [SerializeField] TurretFactory _turretFactory;

    public void OnCreate(InputAction.CallbackContext context)
    {
        if (context.performed)
        Create();
    }

    public void Create()
    {
        _turretFactory.GenerateTurret(new Vector3(transform.position.x, 0, 0));
    }
}
