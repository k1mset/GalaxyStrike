using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laserEffect;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    AudioSource audioSource;
    bool isFiring = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
        MoveTargetPoint();
    }

    void LateUpdate()
    {
        MoveCrosshair();
        AimLasers();
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in laserEffect)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;

        if (isFiring)
        {
            audioSource.volume = 0.5f;
        }
        else
        {
            audioSource.volume = 0f;
        }
    }

    void AimLasers()
    {
        foreach (GameObject laser in laserEffect)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
