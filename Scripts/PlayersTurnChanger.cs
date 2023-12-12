using UnityEngine;
using TMPro;

public class PlayersTurnChanger : MonoBehaviour
{
    // Надпись для отображения текущего игрока
    public TextMeshProUGUI PlayerText;

    // Массив фишек всех игроков
    private PlayerChip[] _playersChips;

    // Номер текущего игрока
    private int _currentPlayerId;

public void StartGame(PlayerChip[] playersChips)
{
    // Присваиваем массив фишек игроков
    _playersChips = playersChips;

    // Текущему игроку задаём номер -1
    _currentPlayerId = -1;

    // Вызываем метод для перехода к следующему игроку
    MovePlayerTurn();
}

public int GetCurrentPlayerId()
{
    // Получаем номер текущего игрока
    return _currentPlayerId;
}

public void MovePlayerTurn()
{
    // Увеличиваем номер текущего игрока на 1
    _currentPlayerId++;

    // Если номер стал больше или равен количеству фишек игроков
    if(_currentPlayerId >= _playersChips.Length)
    {
        // Обнуляем номер текущего игрока
        _currentPlayerId = 0;
    }
    // Вызываем метод для установки надписи с номером игрока
    SetPlayerText(_currentPlayerId);
}

private void SetPlayerText(int playerId)
{
    // Надпись отображает номер текущего игрока
    PlayerText.text = $"Игрок {playerId + 1}";
}



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
