using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamShake : MonoBehaviour
{
   public IEnumerator Shake (float duration, float magitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magitude;
            float y = Random.Range(-1f, 1f) * magitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null; 
        }

        transform.localPosition = originalPos;
    }
}
