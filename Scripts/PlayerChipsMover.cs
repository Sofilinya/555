using UnityEngine;

public class PlayerChipsMover : MonoBehaviour
{
    public GameField gameField;                    // ������ �������� ����
    public TransitionSettings TransitionSettings;  // ������ � ����������� ���������

    private PlayerChip[] _playersChips;   // ������ ����� �������
    private int[] _playersChipsCellsIds;  // ������ ������� ������� �����

    public void StartGame(PlayerChip[] playersChips)
    {
        _playersChips = playersChips;                           // ����������� ������ ����� �������
        _playersChipsCellsIds = new int[playersChips.Length];   // ������ ������ ��� �������� ������� ������� �����
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        // �������� � ����� �� ���� ������ �������
        for (int i = 0; i < _playersChips.Length; i++)
        {
            RefreshChipPosition(i);   // �������� ����� ��� ���������� ������� ����� � ������� i
        }
    }

    public void MoveChip(int playerId, int steps)
    {
        _playersChipsCellsIds[playerId] += steps;     // ����������� ������� ������� ����� �� �������� ����� �����

        // ���� ������� ������� ����� ��������� ���������� ����� �� ������� ����
        if (_playersChipsCellsIds[playerId] >= gameField.CellsCount)
        {
            _playersChipsCellsIds[playerId] = gameField.CellsCount - 1;   // ������������� ����� �� ��������� ������
        }

        TryApplyTransition(playerId);

        RefreshChipPosition(playerId);    // �������� ����� ��� ���������� ������� �����
    }

    private void RefreshChipPosition(int playerId)
    {
        Vector2 chipPosition = gameField.GetCellPosition(_playersChipsCellsIds[playerId]);    // �������� ������� ������ �� ������� ����, ������� ������������� ������� ������� �����
        _playersChips[playerId].SetPosition(chipPosition);                                    // ������������� ����� �� ���������� �������
    }

    private void TryApplyTransition(int playerId)
    {
        // �������� ����� ����� ������ ����� ���� ������
        int resultCellId = TransitionSettings.GetTransitionResultCellId(_playersChipsCellsIds[playerId]);

        // ���� ����� ������ 0
        if (resultCellId < 0)
        {
            return;  // ������� �� ���� ��� �������� �� �����
        }

        _playersChipsCellsIds[playerId] = resultCellId;  // ������������� ����� ����� ������
    }

    public bool CheckPlayerFinished(int playerId)
    {
        // ���������� true, ���� ����� ������� ������ ���������� ������ ������ ��� ����� ���������� ������ �� ������� ���� - 1
        return _playersChipsCellsIds[playerId] >= gameField.CellsCount - 1;
    }
}