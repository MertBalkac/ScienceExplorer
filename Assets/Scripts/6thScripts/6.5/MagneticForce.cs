using UnityEngine;

public class MagneticForce : MonoBehaviour
{
    public Transform otherMagnet; // Di�er k�re
    public float magneticForce = 10f; // Manyetik kuvvetin b�y�kl���
    private Rigidbody rb;
    private MagneticPole magneticPole;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        magneticPole = GetComponent<MagneticPole>();
    }

    void FixedUpdate()
    {
        if (otherMagnet == null) return;

        MagneticPole otherMagneticPole = otherMagnet.GetComponent<MagneticPole>();
        Vector3 direction = otherMagnet.position - transform.position;
        float distance = direction.magnitude;

        // Kuvvetin b�y�kl���n� hesapla (ters kare yasas�)
        Vector3 force = direction.normalized * magneticForce / (distance * distance);

        // Kutuplara g�re kuvvet y�n�n� belirle
        if (magneticPole.isNorthPole == otherMagneticPole.isNorthPole)
            force = -force; // Ayn� kutuplar iter
        else
            force = force; // Z�t kutuplar �eker

        rb.AddForce(force);
    }
}
