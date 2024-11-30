using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ballRigidbody;

    void Start()
    {
        // Bilyeye bir baþlangýç kuvveti uygulayabilirsiniz (isteðe baðlý)
        ballRigidbody = GetComponent<Rigidbody>();
    }
}