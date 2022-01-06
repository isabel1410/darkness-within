using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputProcessor : MonoBehaviour
{
    public delegate void MoveChangedEvent(Vector2 input);
    public static event MoveChangedEvent OnMoveChanged;

    public delegate void AttackMeleeEvent();
    public static event AttackMeleeEvent OnAttackMelee;

    public delegate void AttackRangedEvent();
    public static event AttackRangedEvent OnAttackRanged;

    public delegate void AttackSpecialEvent();
    public static event AttackSpecialEvent OnAttackSpecial;

    public void MoveChanged(InputAction.CallbackContext context)
    {
        OnMoveChanged?.Invoke(context.ReadValue<Vector2>());
    }

    public void AttackMelee(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnAttackMelee?.Invoke();
        }
    }

    public void AttackRanged(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnAttackRanged?.Invoke();
        }
    }

    public void AttackSpecial(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnAttackSpecial?.Invoke();
        }
    }
}
