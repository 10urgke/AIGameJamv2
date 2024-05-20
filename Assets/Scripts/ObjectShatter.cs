using UnityEngine;

public class ObjectShatter : MonoBehaviour
{
    public GameObject[] fragments; // Parçaları bu diziye ekleyin
    public float explosionForce = 1000f; // Parçaların fırlama kuvveti
    public float explosionRadius = 5f; // Patlamanın etki alanı
    public float upwardsModifier = 0.5f; // Parçaların yukarı doğru fırlama miktarı

    void Start()
    {
        // Objeyi parçalara ayır
        Shatter();
    }

    void Shatter()
    {
        foreach (GameObject fragment in fragments)
        {
            // Her bir parçayı aktif hale getir ve objenin pozisyonuna taşı
            fragment.SetActive(true);
            fragment.transform.position = transform.position;

            // Parçada Rigidbody komponenti olup olmadığını kontrol et
            Rigidbody rb = fragment.GetComponent<Rigidbody>();
            if (rb == null)
            {
                // Rigidbody yoksa, ekle
                rb = fragment.AddComponent<Rigidbody>();
            }

            // Rastgele bir yön oluştur
            Vector3 randomDirection = Random.insideUnitSphere;
            randomDirection.y += upwardsModifier; // Yukarı doğru hafif bir yönlendirme

            // Patlama kuvvetini uygula
            rb.AddForce(randomDirection * explosionForce);
        }
    }
}
