using UnityEngine;

public class PurseClick : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform tableSpawnArea; // Masanın merkez noktası

    public void OnPurseClicked()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        if (coinPrefab == null) return;

        // Her tıklamada sabit 1 cent (0.01) çıkacak şekilde ayarlandı
        decimal value = 0.01m;

        // Masanın yerel rect pozisyonuna göre UI uyumlu hedef nokta belirle
        RectTransform tableRect = tableSpawnArea as RectTransform;
        Vector2 baseAnchoredPos = tableRect ? tableRect.anchoredPosition : Vector2.zero;
        
        // Masanın üzerinde rastgele dağılması için piksel tabanlı offset
        Vector2 randomOffset = new Vector2(Random.Range(-150f, 150f), Random.Range(-80f, 80f));
        Vector2 targetAnchoredPosition = baseAnchoredPos + randomOffset;

        // Coin'i masa altında UI elemanı olarak üret
        GameObject newCoinObj = Instantiate(coinPrefab, tableSpawnArea);
        
        // Ölçeği ve yerel pozisyonu düzenle
        RectTransform coinRect = newCoinObj.GetComponent<RectTransform>();
        if (coinRect != null)
        {
            coinRect.localScale = Vector3.one;
            coinRect.anchoredPosition = Vector2.zero; 
        }

        Coin coinScript = newCoinObj.GetComponent<Coin>();
        if (coinScript != null)
        {
            coinScript.coinValue = value;
            coinScript.LaunchToTable(targetAnchoredPosition);
        }
    }
}