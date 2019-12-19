using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldSpear : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
