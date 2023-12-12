using UnityEngine;

public class PlayerChipsCreator : MonoBehaviour
{
    //public int PlayersCount = 2;                       // Количество игроков в игре

    public PlayerChip PlayerChipPrefab;
    public Sprite[] PlayerChipSprites = new Sprite[0];
    private PlayerChip[] playersChips;

    public PlayerChip PlayerChipPrefab;                // Префаб фишки игрока
  public Sprite[] PlayerChipSprites = new Sprite[0]; // Массив спрайтов фишек игроков размером 0



    public PlayerChip[] SpawnPlayersChips(int count)
    {
        // Создаём массив нужной длины для фишек игроков
        playersChips = new PlayerChip[count];

        // Проходим по циклу длиной в количество игроков
        for (int i = 0; i < count; i++)
        {
            // Если спрайтов фишек не хватает для всех игроков
            if (i >= PlayerChipSprites.Length)
            {
                // Прекращаем создание фишек (выходим из цикла)
                break;
            }
            // Создаём фишку для текущего игрока из массива спрайтов
            playersChips[i] = SpawnPlayerChip(PlayerChipSprites[i]);
        }
        // Возвращаем массив созданных фишек игроков
        return playersChips;
    }

    private PlayerChip SpawnPlayerChip(Sprite sprite)
    {
        // Если спрайт отсутствует
        if (!sprite)
        {
            // Возвращаем null (пустое множество)
            return null;
        }
        // Создаём новую фишку игрока из префаба фишки
        PlayerChip newPlayerChip = Instantiate(PlayerChipPrefab, transform.position, transform.rotation);

        // Устанавливаем спрайт фишки
        newPlayerChip.SetSprite(sprite);

        // Возвращаем созданную фишку игрока
        return newPlayerChip;
    }
}
