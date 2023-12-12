using UnityEngine;

public class PlayerChipsMover : MonoBehaviour
{
    public GameField gameField;                    // Скрипт игрового поля
    public TransitionSettings TransitionSettings;  // Скрипт с настройками переходов

    private PlayerChip[] _playersChips;   // Массив фишек игроков
    private int[] _playersChipsCellsIds;  // Массив текущих позиций фишек

    public void StartGame(PlayerChip[] playersChips)
    {
        _playersChips = playersChips;                           // Присваиваем массив фишек игроков
        _playersChipsCellsIds = new int[playersChips.Length];   // Создаём массив для хранения текущих позиций фишек
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        // Проходим в цикле по всем фишкам игроков
        for (int i = 0; i < _playersChips.Length; i++)
        {
            RefreshChipPosition(i);   // Вызываем метод для обновления позиции фишки с номером i
        }
    }

    public void MoveChip(int playerId, int steps)
    {
        _playersChipsCellsIds[playerId] += steps;     // Увеличиваем текущую позицию фишки на заданное число шагов

        // Если текущая позиция фишки превышает количество ячеек на игровом поле
        if (_playersChipsCellsIds[playerId] >= gameField.CellsCount)
        {
            _playersChipsCellsIds[playerId] = gameField.CellsCount - 1;   // Устанавливаем фишку на последнюю ячейку
        }

        TryApplyTransition(playerId);

        RefreshChipPosition(playerId);    // Вызываем метод для обновления позиции фишки
    }

    private void RefreshChipPosition(int playerId)
    {
        Vector2 chipPosition = gameField.GetCellPosition(_playersChipsCellsIds[playerId]);    // Получаем позицию ячейки на игровом поле, которая соответствует текущей позиции фишки
        _playersChips[playerId].SetPosition(chipPosition);                                    // Устанавливаем фишку на полученную позицию
    }

    private void TryApplyTransition(int playerId)
    {
        // Получаем новый номер ячейки после хода игрока
        int resultCellId = TransitionSettings.GetTransitionResultCellId(_playersChipsCellsIds[playerId]);

        // Если номер меньше 0
        if (resultCellId < 0)
        {
            return;  // Переход по змее или лестнице не нужен
        }

        _playersChipsCellsIds[playerId] = resultCellId;  // Устанавливаем новый номер ячейки
    }

    public bool CheckPlayerFinished(int playerId)
    {
        // Возвращаем true, если номер текущей клетки указанного игрока больше или равен количеству клеток на игровом поле - 1
        return _playersChipsCellsIds[playerId] >= gameField.CellsCount - 1;
    }
}