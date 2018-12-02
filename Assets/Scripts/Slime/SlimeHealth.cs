using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeHealth : MonoBehaviour
{
    public float MaxSize;
    public float DamageHealthStep;
    public float DeathSize;
    public UnityEvent OnDeath;
    public float Size
    {
        get { return size; }
    }

    private float size;

    void Start()
    {
        size = MaxSize;
        SetScale(MaxSize);
    }

    public void Regen()
    {
        LerpScale(MaxSize);
    }

    public void Damage()
    {   
        float healthStep = DamageHealthStep * Time.deltaTime;
        float newSize = size - healthStep;
        size = newSize;
        if (newSize <= DeathSize) Kill();
        else SetScale(newSize);
    }

    public void Kill()
    {
        LerpScale(0.5f);
        if (OnDeath != null) OnDeath.Invoke();
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
            size = scale;
            float lerp = 0;
            while (lerp < 1f)
            {
                lerp += Time.deltaTime * (scale - currentScale);
                float lerpVal = Mathf.Lerp(currentScale, scale, lerp);
                SetScale(lerpVal);
                yield return null;
            }
        }
        if (LerpRoutine != null) StopCoroutine(LerpRoutine);
        LerpRoutine = StartCoroutine(Lerp());
    }

}