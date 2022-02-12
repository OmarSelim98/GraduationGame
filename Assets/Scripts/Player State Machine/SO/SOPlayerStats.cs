using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player Stats File")]
public class SOPlayerStats : ScriptableObject
{
    float gravity = 9.81f;
    float groundedGravity = 0.15f;
    float movementSpeed = 1.75f;
    [SerializeField]
    List<SOWeapon> weapons;
    [SerializeField]
    SOWeapon currentWeapon;
    [Range(1, 10)]
    [SerializeField] float initialJumpSpeed = 5.0f;
    [SerializeField] float distanceToGround = 0.01f;
    [SerializeField] float maxJumpTime = 0.5f;
    [SerializeField] float maxJumpHeight = 5.0f;
    [Range(0, 1)]
    [SerializeField] float rotationFactor = 0.6f;

    [SerializeField] float fallMultiplier = 2.5f;

    [SerializeField] float dashTime = 0.25f;
    [SerializeField] float dashDistance = 5.0f;
    [SerializeField] float dashSpeed;

    public float GRAVITY { get { return gravity; } }
    public float ROTATION_FACTOR { get { return rotationFactor; } }
    public float GROUNDED_GRAVITY { get { return groundedGravity; } }
    public float DISTANCE_TO_GROUND { get { return distanceToGround; } }
    public float INITIAL_JUMP_SPEED { get { return initialJumpSpeed; } }
    public float FALL_MULTIPLIER { get { return fallMultiplier; } }

    public float MOVEMENT_SPEED { get => movementSpeed; set => movementSpeed = value; }
    public SOWeapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }
    public List<SOWeapon> Weapons { get => weapons; }
    public float DASH_SPEED { get => dashSpeed; }
    public float DASH_TIME { get => dashTime; }
    public float DASH_DISTANCE { get => dashDistance; }

    public void SetupJumpVars()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpSpeed = (2 * maxJumpHeight) / timeToApex;
        //setting dash speed
        dashSpeed = dashDistance / dashTime;
    }
}
