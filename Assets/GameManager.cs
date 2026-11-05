using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elemanları")]
    public TextMeshProUGUI moneyText; // Sol üstteki Para metni (Sayaç)

    private decimal totalMoney = 0m;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Oyun açılır açılmaz metni güncelleyerek # işaretini kaldırır ve $0.00 yapar
        UpdateMoneyUI();
    }

    public void AddMoney(decimal amount)
    {
        totalMoney += amount;
        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "Para: $" + totalMoney.ToString("0.00");
        }
    }
}