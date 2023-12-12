using UnityEngine;

public class PlayersChipsMover : MonoBehaviour
{
    // Скрипт игрового поля
    public GameField GameField;

    // Массив фишек игроков
    private PlayerChip[] _playersChips;

    // Массив текущих позиций фишек
    private int[] _playersChipsCellsIds;

    public void StartGame(PlayerChip[] playersChips)
    {
        // Присваиваем массив фишек игроков
        _playersChips = playersChips;

        // Создаём массив для хранения текущих позиций фишек
        _playersChipsCellsIds = new int[playersChips.Length];

        // Вызываем метод для обновления позиций всех фишек
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        // Проходим в цикле по всем фишкам игроков
        for (int i = 0; i < _playersChips.Length; i++)
        {
            // Вызываем метод для обновления позиции фишки с номером i
           // RefreshChipPosition(i);
        }
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
