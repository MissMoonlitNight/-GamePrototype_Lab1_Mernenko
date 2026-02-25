using UnityEngine;
using UnityEngine.UI;

///<summary>
/// Управление пользовательским интерфейсом: отображение позиции игрока.
///</summary>
public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Text positionText;

    [Header("Player Reference")]
    [SerializeField] private Transform player;

    private Color defaultColor = Color.white;
    private Color warningColor = Color.yellow;

    private void Start()
    {
        if (positionText == null)
        {
            Debug.LogWarning("UIManager: positionText не назначен в инспекторе!");
        }
        if (player == null)
        {
            Debug.LogWarning("UIManager: player не назначен в инспекторе!");
        }
    }

    private void Update()
    {
        UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
        if (player != null && positionText != null)
        {
            Vector3 pos = player.position;

            // Форматируем каждую координату отдельно с 1 знаком после запятой
            string x = pos.x.ToString("F1");
            string y = pos.y.ToString("F1");
            string z = pos.z.ToString("F1");

            // Отображаем все три координаты в удобочитаемом формате
            positionText.text = $"Pos: X:{x} Y:{y} Z:{z}";

            // Цвет меняется при высоком прыжке
            if (pos.y > 2.0f)
            {
                positionText.color = warningColor;
            }
            else
            {
                positionText.color = defaultColor;
            }
        }
    }
}