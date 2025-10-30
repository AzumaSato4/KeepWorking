using UnityEngine;
using UnityEngine.UI;

public class WoodSpot : ResourceSpot
{
    [SerializeField] SpotStatus status;
    [SerializeField] Slider slider;

    private void Awake()
    {
        spotStatus = status;
    }
    private void Update()
    {
        slider.maxValue = _maxHealth;
        slider.value = _health;

        if (_health <= 0)
        {
            Dead();
            return;
        }

        _timer += Time.deltaTime;
        if (_health >= _maxHealth)
        {
            _timer = 0;
        }
        else if (_timer >= _recoverTime)
        {
            RestoreHealth();
        }
    }
}
