using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    public bool isNorthPole = true;
    private Renderer sphereRenderer;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    void OnMouseDown()
    {
        isNorthPole = !isNorthPole;
        UpdateColor();
    }

    void UpdateColor()
    {
        sphereRenderer.material.color = isNorthPole ? Color.red : Color.blue;
    }
}