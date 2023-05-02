using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;

    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount++;
        gameObject.SetActive(false);
    }
}
