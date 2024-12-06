using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    public bool isNorthPole = true; // Ba�lang��ta Kuzey Kutbu
    private Renderer sphereRenderer;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    void OnMouseDown()
    {
        isNorthPole = !isNorthPole; // Kutuplar� de�i�tir
        UpdateColor();
    }

    void UpdateColor()
    {
        // Kuzey kutbu ise k�rm�z�, g�ney kutbu ise mavi
        sphereRenderer.material.color = isNorthPole ? Color.red : Color.blue;
    }
}