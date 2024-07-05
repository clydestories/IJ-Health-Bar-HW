using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_InputField _healAmount;
    [SerializeField] private TMP_InputField _damageAmount;

    public void Attack()
    {
        int.TryParse(_damageAmount.text, out int amount);
        _health.TakeDamage(amount);
    }

    public void Heal()
    {
        int.TryParse(_healAmount.text, out int amount);
        _health.Heal(amount);
    }
}
