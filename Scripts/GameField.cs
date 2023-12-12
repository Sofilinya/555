using UnityEngine;

public class GameField : MonoBehaviour
{

    public Transform FirstCellPoint;  // Позиция первой ячейки
    public Vector2 CellSize;          // Размер ячейки (по X и Y)
    public int CellsCount = 100;      // Общее количество ячеек на игровом поле
    public int CellsInRow = 10;       // Количество ячеек в одном ряду

    private Vector2[] _cellsPositions; // Массив из позиций каждой ячейки
    private Vector2[][] _cellsPositions2; // Массив из позиций каждой ячейки

    public void FillCellsPositions()
    {
        _cellsPositions = new Vector2[CellsCount];// Создаём массив с размером, равным общему количеству ячеек

        bool right = true;                            // Заводим переменную, которая отслеживает, где создаются новые ячейки (они будут добавляться вправо и влево)
        _cellsPositions[0] = FirstCellPoint.position; // Делаем позицию первой ячейки в массиве равной заданной позиции первой ячейки

        // Проходим по каждой ячейке, начиная со второй
        for (int i = 1; i < _cellsPositions.Length; i++)
        {
            bool needUp = i % CellsInRow == 0;  // Узнаём, нужно ли подниматься на новый ряд ячеек

            // Если нужно подниматься на новый ряд:
            if (needUp)
            {
                right = !right;  // Меняем направление движения на противоположное

                // Позиция ячейки получается путём смещения на высоту одной ячейки вверх
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * CellSize.y;
            }
            else    // Если не нужно подниматься на новый ряд:
            {
                // Определяем знак смещения по горизонтали в зависимости от направления движения
                float xSign = right ? 1 : -1;

                // Смещение по горизонтали равно ширине одной клетки, умноженной на знак смещения
                float deltaX = xSign * CellSize.x;

                // Позиция ячейки определяется, когда мы смещаем её на указанное значение по горизонтали
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;
            }
        }

        /*for (int y = 0; y <= 10; y++)
        {
          _cellsPositions[x][y] = _cellsPositions[x][y] + y*Vector2.up * CellSize.y;
          for (int x = 1; x <= 10; x++)
          {
            // Определяем знак смещения по горизонтали в зависимости от направления движения
            int xSign = right ? 1 : -1;

            // Смещение по горизонтали равно ширине одной клетки, умноженной на знак смещения
            float deltaX = xSign * CellSize.x;
            _cellsPositions2[x][y] = _cellsPositions2[x + xSign][y] + Vector2.right * deltaX;
          }

          right = !right;
        }*/
    }
}

