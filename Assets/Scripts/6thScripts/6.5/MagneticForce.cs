using UnityEngine;

public class MagneticForce : MonoBehaviour
{
    public Transform otherMagnet;
    public MagneticForceValue magneticForceValue;
    private Rigidbody rb;
    private MagneticPole magneticPole;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        magneticPole = GetComponent<MagneticPole>();
    }

    void FixedUpdate()
    {
        float magneticForce = magneticForceValue.magneticForce;
        if (otherMagnet == null) return;

        MagneticPole otherMagneticPole = otherMagnet.GetComponent<MagneticPole>();
        Vector3 direction = otherMagnet.position - transform.position;
        float distance = direction.magnitude;

        // Kuvvetin büyüklüðünü hesapla (ters kare yasasý)
        Vector3 force = direction.normalized * magneticForce / (distance * distance);

        // Kutuplara göre kuvvet yönünü belirle
        if (magneticPole.isNorthPole == otherMagneticPole.isNorthPole)
            force = -force; // Ayný kutuplar iter
        else
            force = force; // Zýt kutuplar çeker

        rb.AddForce(force);
    }
}
