using UnityEngine;

public class GameField : MonoBehaviour
{
    public Transform FirstCellPoint;      // ������� ������ ������
    public Vector2 CellSize;              // ������ ������ (�� X � Y)
    public int CellsCount = 100;          // ����� ���������� ����� �� ������� ����
    public int CellsInRow = 10;           // ���������� ����� � ����� ����

    private Vector2[] _cellsPositions;  // ������ �� ������� ������ ������
    private Vector2[,] _cellsPositions2; // ������ �� ������� ������ ������

    public void FillCellsPositions()
    {
        _cellsPositions = new Vector2[CellsCount];// ������ ������ � ��������, ������ ������ ���������� �����

        float xSign = 1;        // ������� ����������, ������� �����������, ��� ��������� ����� ������ (��� ����� ����������� ������ � �����)
        _cellsPositions[0] = FirstCellPoint.position; // ������ ������� ������ ������ � ������� ������ �������� ������� ������ ������

        // �������� �� ������ ������, ������� �� ������
        for (int i = 1; i < _cellsPositions.Length; i++)
        {
            bool needUp = i % CellsInRow == 0;  // �����, ����� �� ����������� �� ����� ��� �����

            if (needUp)  // ���� ����� ����������� �� ����� ���
            {
                xSign *= -1;  // ������ ����������� �������� �� ���������������
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * CellSize.y; // ������� ������ ���������� ���� �������� �� ������ ����� ������ �����
            }
            else    // ���� �� ����� ����������� �� ����� ���:
            {
                float deltaX = xSign * CellSize.x;                                     // �������� �� ����������� ����� ������ ����� ������, ���������� �� ���� ��������
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;  // ������� ������ ������������, ����� �� ������� � �� ��������� �������� �� �����������
            }
        }
    }

    public void FillCellsPositionsMap()
    {
        _cellsPositions2 = new Vector2[CellsCount / 2, CellsCount / 2]; // ������ ������ � ��������, ������ ������ ���������� �����
        _cellsPositions2[0, 0] = FirstCellPoint.position;            // ������ ������� ������ ������ � ������� ������ �������� ������� ������ ������
        int xSign = 1;
        /*for (int y = 0; y <= 10; y++)
        {
          _cellsPositions2[x][y] = _cellsPositions2[x][y] + y*Vector2.up * CellSize.y;
          for (int x = 0; x <= 10; x++)
          {
            // �������� �� ����������� ����� ������ ����� ������, ���������� �� ���� ��������
            float deltaX = xSign * CellSize.x;
            _cellsPositions2[x, y] = _cellsPositions2[x + xSign, y] + Vector2.right * deltaX;
          }
          xSign *= -1;
        }*/
    }

    public Vector2 GetCellPosition(int id)
    {
        // ���� ����� ������ ������������
        if (id < 0 || id >= _cellsPositions.Length)
        {
            return Vector2.zero;       // ���������� ������� �������� (0, 0)
        }
        return _cellsPositions[id];  // ����� ���������� ������� ������
    }
}
