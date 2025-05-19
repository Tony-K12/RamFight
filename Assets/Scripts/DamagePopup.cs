using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public TextMeshPro textMesh;

    public static void Create(Vector3 position, float damage)
    {
        var prefab = Resources.Load<GameObject>("DamagePopup");
        var popup = Instantiate(prefab, position, Quaternion.identity);
        popup.GetComponent<DamagePopup>().Setup(damage);
    }

    public void Setup(float damage)
    {
        textMesh.text = damage.ToString("F0");
        Destroy(gameObject, 1f); // auto destroy
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
}
