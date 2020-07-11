using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeCamera : MonoBehaviour
{
    private Vector3 _position;

    public void Start()
    {
        _position = transform.position;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            
            transform.position = new Vector3(x, y, _position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        transform.position = _position;
    }
}
