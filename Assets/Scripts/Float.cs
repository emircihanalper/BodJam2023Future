using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    [SerializeField] private GameObject battery;
    private float yInitial; // Nesnenin ba�lang�� y�ksekli�i
    private float floatHeight = 0.3f; // Sal�n�m�n zirve noktas�
    private float floatSpeed = 0.6f; // Sal�n�m h�z�
    private bool floatingUpward = true; // Nesnenin yukar� m� a�a�� m� hareket etti�ini belirten flag

    // Start is called before the first frame update
    void Start()
    {
        yInitial = battery.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Sal�n�m h�z�n� hesapla
        float deltaHeight = floatSpeed * Time.deltaTime;

        // Y�n de�i�tirme kontrol�
        if (floatingUpward)
        {
            battery.transform.position += new Vector3(0f, deltaHeight, 0f);
        }
        else
        {
            battery.transform.position -= new Vector3(0f, deltaHeight, 0f);
        }

        // Zirveye ula��ld���nda y�n� tersine �evir
        if (battery.transform.position.y >= yInitial + floatHeight)
        {
            floatingUpward = false;
        }
        else if (battery.transform.position.y <= yInitial - floatHeight)
        {
            floatingUpward = true;
        }
    }
}
