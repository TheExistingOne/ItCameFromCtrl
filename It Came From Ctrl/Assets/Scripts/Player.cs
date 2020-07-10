using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 20f;

    private Vector2 _movement;

    void Update()
    {
        CalculateMovement();
        transform.Translate(_movement);
    }
    
    void CalculateMovement()
    {
        _movement = Vector2.zero;
        _movement.x += Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
        _movement.y += Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
    }
}
