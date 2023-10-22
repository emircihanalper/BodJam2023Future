using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KaybolmaAnimasyonu : MonoBehaviour
{
    private SpriteRenderer spriteRendererr;
    private float kaybolmaSure = 1f; // Kaybolma s�resi (�rne�in 1 saniye)

    void Start()
    {
        spriteRendererr = GetComponent<SpriteRenderer>();
        // Kaybolma animasyonunu ba�lat
        StartCoroutine(Kaybolmaanimasyonu());
    }

    IEnumerator Kaybolmaanimasyonu()
    {
        float zaman = 0f;
        while (zaman < kaybolmaSure)
        {
            // Zamanla alpha de�erini azaltarak kaybolma efektini olu�tur
            spriteRendererr.color = new Color(spriteRendererr.color.r, spriteRendererr.color.g, spriteRendererr.color.b, Mathf.Lerp(1f, 0f, zaman / kaybolmaSure));
            zaman += Time.deltaTime;
            yield return null;
        }
        // Nesneyi yok et veya istedi�iniz bir i�lemi ger�ekle�tirin
        Destroy(gameObject);
    }
}
