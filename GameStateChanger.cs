using UnityEngine;
using TMPro;

public class GameStateChanger : MonoBehaviour
{
    public int PlayersCount = 2;                     // Количество игроков

    public PlayerChipsCreator PlayersChipsCreator;   // Скрипт создания фишек
    public PlayersTurnChanger PlayersTurnChanger;    // Скрипт смены хода игроков
    public PlayerChipsMover PlayersChipsMover;       // Скрипт перемещения фишек
    public GameField GameField;                      // Скрипт игрового поля


    private void Start()
    {
        FirstStartGame();   // Делаем первичную настройку игры
    }
    // Метод для первого запуска игры 
    private void FirstStartGame()
    {
        GameField.FillCellsPositions(); // Заполняем позиции клеток на игровом поле
        StartGame();                    // Начинаем новую игру 
    }

    private void StartGame()
    {
        PlayerChip[] playersChips = PlayersChipsCreator.SpawnPlayersChips(PlayersCount);  // Создаём фишки для заданного числа игроков

        PlayersTurnChanger.StartGame(playersChips);     // Готовим игроков к началу игры
        PlayersChipsMover.StartGame(playersChips);      // Задаём начальную позицию фишек игроков
        //SetScreens(true);                               // Показываем экран игры
    }

    // Метод для завершения игры
    private void EndGame()
    {
        //SetScreens(false);    // Показываем экран конца игры
    }

    // Метод для перезапуска по кнопке
    public void RestartGame()
    {
        PlayersChipsCreator.Clear();      // Удаляем фишки игроков
        StartGame();                      // Начинаем новую игру
    }

    // Метод для установки видимости игровых экранов

    public void DoPlayerTurn(int steps)
    {
        int currentPlayerId = PlayersTurnChanger.GetCurrentPlayerId();      // Получаем номер текущего игрока
        PlayersChipsMover.MoveChip(currentPlayerId, steps);                 // Двигаем фишку текущего игрока на заданное число шагов

        // Проверяем, достиг ли игрок финиша
        bool isPlayerFinished = PlayersChipsMover.CheckPlayerFinished(currentPlayerId);
        if (isPlayerFinished)
        {                 // Если игрок на финише
            //SetWinText(currentPlayerId);          // Устанавливаем надпись о победе
            EndGame();                            // Переходим к экрану конца игры
        }
        else
        {
            PlayersTurnChanger.MovePlayerTurn();  // Передаём ход следующему игроку
        }
    }
}