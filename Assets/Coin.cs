using UnityEngine;
using UnityEngine.EventSystems; // UI tıklamalarını algılamak için gerekli

public class Coin : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public decimal coinValue; // PurseClick'ten gelen para değeri

    // Coin masaya fırlatıldığında çağrılır (Para hemen artmaz, sadece pozisyon ayarlanır)
    public void LaunchToTable(Vector2 targetAnchoredPosition)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // UI elemanlarını Canvas içinde konumlandırmanın doğru yolu anchoredPosition'dır
            rectTransform.anchoredPosition = targetAnchoredPosition;
        }
    }

    // Oyuncu masadaki coine tıkladığında bu fonksiyon çalışır
    public void OnPointerClick(PointerEventData eventData)
    {
        // GameManager'a haber verip parayı artırıyoruz
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddMoney(coinValue);
        }

        // Coini yok et (kasanın içine girmiş gibi kaybolur)
        Destroy(gameObject);
    }
}