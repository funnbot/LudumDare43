using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    public float MaxSize;

    private float size;

    void Start()
    {
        SetScale(MaxSize);
    }

    public void Regen()
    {
        LerpScale(MaxSize);
    }

    public void Diminish() {

    }

    public void Die() {
        LerpScale(0.1f);
    }

    private void SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }

    Coroutine LerpRoutine;
    private void LerpScale(float scale)
    {
        IEnumerator Lerp()
        {   
            float currentScale = size;
            float lerp = 0;
            while (lerp < 1f) {
                lerp += Time.deltaTime * (scale / currentScale);
                float lerpVal = Mathf.Lerp(currentScale, scale, lerp);
                SetScale(lerpVal);
            }
            yield return null;
        }
        if (LerpRoutine != null) StopCoroutine(LerpRoutine);
        LerpRoutine = StartCoroutine(Lerp());
    }

}