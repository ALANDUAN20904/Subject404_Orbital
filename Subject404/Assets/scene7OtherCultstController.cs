using System.Collections;
using UnityEngine;

public class scene7OtherCultistController : MonoBehaviour
{
    public void TriggerDisappear()
    {
        StartCoroutine(DeactivateCultist(1.0f));
    }

    private IEnumerator DeactivateCultist(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
