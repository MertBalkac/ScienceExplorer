using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    public bool isNorthPole = true; // Baþlangýçta Kuzey Kutbu
    private Renderer sphereRenderer;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    void OnMouseDown()
    {
        isNorthPole = !isNorthPole; // Kutuplarý deðiþtir
        UpdateColor();
    }

    void UpdateColor()
    {
        // Kuzey kutbu ise kýrmýzý, güney kutbu ise mavi
        sphereRenderer.material.color = isNorthPole ? Color.red : Color.blue;
    }
}