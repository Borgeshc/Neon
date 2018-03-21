using UnityEngine;
using EZCameraShake;

public class BounceProjectile : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    public GameObject impact;

    int bounceCount;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * minVelocity;
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bounce"))
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        Instantiate(impact, transform.position, transform.rotation);
        CameraShaker.Instance.ShakeOnce(1f, 1f, .025f, .25f);
        if (bounceCount >= 3)
            Destroy(gameObject);

        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        direction.y = 0;
        rb.velocity = direction * Mathf.Max(speed, minVelocity);

        bounceCount++;
    }
}