using UnityEngine;

public class WallMaterialChanger : MonoBehaviour
{
    public Material solidMaterial; // Solid materyali
    public Material semiTransparentMaterial; // Semi-transparent materyali
    public Material transparentMaterial; // Transparent materyali
    public GameObject wall; // Wall objesi
    public GameObject solidLight;
    public GameObject semiLight;
    public GameObject transparentLight;

    // Solid butonuna basýldýðýnda çaðrýlacak
    public void SetSolidMaterial()
    {
        if (wall != null && solidMaterial != null)
        {
            wall.GetComponent<Renderer>().material = solidMaterial;
            solidLight.SetActive(true);
            semiLight.SetActive(false);
            transparentLight.SetActive(false);
        }
    }

    // Semi-Transparent butonuna basýldýðýnda çaðrýlacak
    public void SetSemiTransparentMaterial()
    {
        if (wall != null && semiTransparentMaterial != null)
        {
            wall.GetComponent<Renderer>().material = semiTransparentMaterial;
            solidLight.SetActive(false);
            semiLight.SetActive(true);
            transparentLight.SetActive(false);
        }
    }

    // Transparent butonuna basýldýðýnda çaðrýlacak
    public void SetTransparentMaterial()
    {
        if (wall != null && transparentMaterial != null)
        {
            wall.GetComponent<Renderer>().material = transparentMaterial;
            solidLight.SetActive(false);
            semiLight.SetActive(false);
            transparentLight.SetActive(true);
        }
    }
}
