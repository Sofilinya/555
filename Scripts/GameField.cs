using UnityEngine;

public class GameField : MonoBehaviour
{
    public Transform FirstCellPoint;      // ѕозици€ первой €чейки
    public Vector2 CellSize;              // –азмер €чейки (по X и Y)
    public int CellsCount = 100;          // ќбщее количество €чеек на игровом поле
    public int CellsInRow = 10;           //  оличество €чеек в одном р€ду

    private Vector2[] _cellsPositions;  // ћассив из позиций каждой €чейки
    private Vector2[,] _cellsPositions2; // ћассив из позиций каждой €чейки

    public void FillCellsPositions()
    {
        _cellsPositions = new Vector2[CellsCount];// —оздаЄм массив с размером, равным общему количеству €чеек

        float xSign = 1;        // «аводим переменную, котора€ отслеживает, где создаютс€ новые €чейки (они будут добавл€тьс€ вправо и влево)
        _cellsPositions[0] = FirstCellPoint.position; // ƒелаем позицию первой €чейки в массиве равной заданной позиции первой €чейки

        // ѕроходим по каждой €чейке, начина€ со второй
        for (int i = 1; i < _cellsPositions.Length; i++)
        {
            bool needUp = i % CellsInRow == 0;  // ”знаЄм, нужно ли подниматьс€ на новый р€д €чеек

            if (needUp)  // ≈сли нужно подниматьс€ на новый р€д
            {
                xSign *= -1;  // ћен€ем направление движени€ на противоположное
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * CellSize.y; // ѕозици€ €чейки получаетс€ путЄм смещени€ на высоту одной €чейки вверх
            }
            else    // ≈сли не нужно подниматьс€ на новый р€д:
            {
                float deltaX = xSign * CellSize.x;                                     // —мещение по горизонтали равно ширине одной клетки, умноженной на знак смещени€
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;  // ѕозици€ €чейки определ€етс€, когда мы смещаем еЄ на указанное значение по горизонтали
            }
        }
    }

    public void FillCellsPositionsMap()
    {
        _cellsPositions2 = new Vector2[CellsCount / 2, CellsCount / 2]; // —оздаЄм массив с размером, равным общему количеству €чеек
        _cellsPositions2[0, 0] = FirstCellPoint.position;            // ƒелаем позицию первой €чейки в массиве равной заданной позиции первой €чейки
        int xSign = 1;
        /*for (int y = 0; y <= 10; y++)
        {
          _cellsPositions2[x][y] = _cellsPositions2[x][y] + y*Vector2.up * CellSize.y;
          for (int x = 0; x <= 10; x++)
          {
            // —мещение по горизонтали равно ширине одной клетки, умноженной на знак смещени€
            float deltaX = xSign * CellSize.x;
            _cellsPositions2[x, y] = _cellsPositions2[x + xSign, y] + Vector2.right * deltaX;
          }
          xSign *= -1;
        }*/
    }

    public Vector2 GetCellPosition(int id)
    {
        // ≈сли номер €чейки некорректный
        if (id < 0 || id >= _cellsPositions.Length)
        {
            return Vector2.zero;       // ¬озвращаем нулевые значени€ (0, 0)
        }
        return _cellsPositions[id];  // »наче возвращаем позицию €чейки
    }
}
