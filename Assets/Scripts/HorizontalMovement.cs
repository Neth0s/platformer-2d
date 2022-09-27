using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Header("Speed and acceleration")]
    [SerializeField] private float maxSpeed = 10f;
    [Tooltip("Time necessary to get from 0 to max speed.")]
    [SerializeField] private float timeToMax = 0.5f;

    private Manette inputActions;
    private float speed = 0;

    public float HorizontalSpeed { get { return speed; } }

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new Manette();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime / timeToMax);

        float movement = speed * Time.deltaTime * inputActions.Player.Move.ReadValue<float>();
        transform.position += Vector3.right * movement;
    }
}
