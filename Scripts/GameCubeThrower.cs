using UnityEngine;

public class GameCubeThrower : MonoBehaviour
{
    public GameStateChanger GameStateChanger;  // ������ ��������� ��������� ����
    public GameCube GameCubePrefab;    // ������ ��� �������� ������
    public Transform GameCubePoint;     // �����, ��� ����� ���������� �����
    // public GameCubeAnimator CubeThrowAnimator; // ������ �������� ������

    private int _cubeValue;    // ��������, ������� ������ �� ������
    private GameCube _gameCube;     // ��������� ������ ������

    void Start()
    {
        CreateGameCube();   // ������ ����� ����� ��� ������� ����
    }

    private void CreateGameCube()
    {
        _gameCube = Instantiate(GameCubePrefab, GameCubePoint.position, GameCubePoint.rotation, GameCubePoint);    // ������ ����� ����� � ��������� ������� � � ��������� ����� ��������
        _gameCube.HideCube();                                                                                      // �������� �����, ����� ��� �� ���� ����� � ������ ����
    }

    public void ThrowCube()
    {
        _cubeValue = _gameCube.ThrowCube();    // �������� ��������� �������� ������ ������
        //CubeThrowAnimator.PlayAnimation();     // ����������� �������� ������
    }

    public void ContinueAfterCubeAnimation()
    {
        GameStateChanger.DoPlayerTurn(_cubeValue);      // ������� ��������, ������� ������ �� ������, � ������ ��������� ��������� ����
    }
} 