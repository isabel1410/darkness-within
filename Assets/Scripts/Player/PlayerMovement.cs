using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public FacingDirection facingDirection;

    [SerializeField]
    private float movementSpeed;

    private Vector2 movement;

    public void AdjustMovementSpeedPercentage(int percentage)
    {
        movementSpeed *= percentage / 100 + 1;
    }

    // Start is called before the first frame update
    private void Start()
    {
        PlayerInputProcessor.OnMoveChanged += OnMoveChanged;
    }

    private void OnMoveChanged(Vector2 movement)
    {
        if (this.movement == Vector2.zero && movement != Vector2.zero)
        {
            this.movement = movement;
            StartCoroutine(Move());
        }
        else
        {
            //If this is removed in the if part and the just put at the end, the coroutine will make the first run while movement is still Vector2.zero
            this.movement = movement;

            /*//Update direction
            if (movement != Vector2.zero)
            {
                facingDirection = movement.y == 0 ? (movement.x < 0 ? FacingDirection.Left : FacingDirection.Right) : (movement.y < 0 ? FacingDirection.Down : FacingDirection.Up);
            }*/
        }
    }

    private IEnumerator Move()
    {
        while (movement != Vector2.zero)
        {
            transform.position += (Vector3)movement.normalized * movementSpeed / 100;
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }
    }

    /*public enum FacingDirection
    {
        Up,
        Right,
        Down,
        Left
    }*/
}
