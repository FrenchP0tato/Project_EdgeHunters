
using System;
using UnityEngine;
using UnityEngine.Events;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float sideSpeed = 10f;
    [SerializeField] private float smoothTime = .2f;
    [SerializeField] private float limit = 5f;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private float rollStrength = 10f;
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float levelUpSpeedIncr = 10f;
    //[SerializeField] private float jumpforce = 100f;

    private Vector3 currentVelocity =Vector3.zero;
    private Vector3 currentDirection =Vector3.zero;
    private float currentDistanceTraveled = 0f;
    private float inLevelDistanceTraveled = 0f;

    //public Rigidbody rb;

    public UnityEvent<Vector3> onSetVelocity;
    public UnityEvent<float> onSetDistance; // not used anymore
    public UnityEvent<int> onLevelUp;

    void Update()
    {
        Move();
        ApplyRoll();

    }


    private void Move()
    {
        var velocity = Vector3.back * moveSpeed * Time.deltaTime;
        TravelDistance(velocity.magnitude);
        onSetVelocity.Invoke(velocity);


        currentDirection = Vector3.SmoothDamp(currentDirection, GetInputDirection(), ref currentVelocity, smoothTime);
        transform.Translate(currentDirection * sideSpeed * Time.deltaTime);
    }

    private void ShipLevelUp()
    {
        moveSpeed = moveSpeed + levelUpSpeedIncr * (GameController.instance.currentLevel - 1);
        sideSpeed = sideSpeed+ levelUpSpeedIncr * (GameController.instance.currentLevel -1);
        onLevelUp.Invoke(GameController.instance.currentLevel - 1);
        Debug.Log("LevelUp from ship");
        //prio2: change ship model
    }

    public void TravelDistance(float distance)
    {
        currentDistanceTraveled = distance;
        GameController.instance.setDistance(currentDistanceTraveled);
        inLevelDistanceTraveled += distance;
        if (inLevelDistanceTraveled>=GameController.instance.distanceBetweenLevels)
        {
            ShipLevelUp();
            inLevelDistanceTraveled = 0;
        }
    }


    private Vector3 GetInputDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
            direction += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        if (transform.position.x>limit)
            direction = Vector3.left;
        if(transform.position.x< -limit)
            direction = Vector3.right;

        return direction;
    }

    private void ApplyRoll()
    {
        float rollAmp=-currentDirection.x*rollStrength;
        Quaternion targetRotation = Quaternion.Euler(0, 0, rollAmp);
        bodyTransform.transform.rotation = targetRotation;

    }

}
