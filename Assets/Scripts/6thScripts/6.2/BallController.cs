using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ballRigidbody;

    void Start()
    {
        // Bilyeye bir ba�lang�� kuvveti uygulayabilirsiniz (iste�e ba�l�)
        ballRigidbody = GetComponent<Rigidbody>();
    }
}