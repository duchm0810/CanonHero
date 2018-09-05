using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingCamera : MonoBehaviour {

	public IEnumerator Shake(float duration, float manitude)
    {
        Vector3 orginalPos = transform.localPosition;
        float eslap = 0;
        while(eslap < duration)
        {
            float x = Random.Range(-1, 1) * manitude;
            float y = Random.Range(-1, 1) * manitude;
            transform.position = new Vector3(x, y, orginalPos.z);
            eslap += Time.deltaTime;
            yield return null;
        }
    }
}
