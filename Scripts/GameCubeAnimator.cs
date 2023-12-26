using UnityEngine;

public class GameCubeAnimator : MonoBehaviour
{
    public Animation CubeAnimation;         // ������ �� ��������� �������� ������
    public GameCubeThrower GameCubeThrower; // ������ ������� ������

    // ����������� ��������
    public void PlayAnimation() { CubeAnimation.Play(); }

    // ���� ����� �� ������� ����� ������ ��������
    public void OnAnimationEnd() { GameCubeThrower.ContinueAfterCubeAnimation(); }  // ���������� �������� ����� ��������
}
