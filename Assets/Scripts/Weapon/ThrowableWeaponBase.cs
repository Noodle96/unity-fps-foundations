using UnityEngine;

public abstract class ThrowableWeaponBase : WeaponBase
{
    [Header("Throw Settings")]
    [SerializeField] protected Transform throwPoint;
    [SerializeField] protected GameObject throwablePrefab;
    [SerializeField] protected float throwForce = 15f;
    [SerializeField] protected float upwardForce = 2f;

    [Header("Sound")]
    [SerializeField] protected AudioClip throwSound;

    protected AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Use()
    {
        PlaySound();
        Throw();
    }

    protected virtual void Throw()
    {
        GameObject obj = Instantiate(
            throwablePrefab,
            throwPoint.position,
            Quaternion.identity
        );

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 throwDir = throwPoint.forward + Vector3.up * upwardForce;
            rb.AddForce(throwDir.normalized * throwForce, ForceMode.Impulse);
        }
    }

    protected void PlaySound()
    {
        if (audioSource != null && throwSound != null)
            audioSource.PlayOneShot(throwSound);
    }
}
