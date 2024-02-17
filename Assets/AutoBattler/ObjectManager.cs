using Assets.Scripts.Patterns;
using System.Collections;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _playerPool;
    [SerializeField] private ObjectPool _enemyPool;
    public Waves waves;
    public string hello = "������!";

    // Start is called before the first frame update
    IEnumerator Start()
    {
        int enemiesIndex = 0;//������� � ������� ������
        int timeIndex = 0;//������� � ������� �������
        foreach (int c in waves.enemiesCount)//��������� ������ ������� ������� enemiesCount
        {
            Debug.Log("����� �����!");//����������� ����
            int i = 0;//���� �������
            int delay = waves.timer[timeIndex];//������ ���������� �������� = ��������������� ������� ������� �������
            while (i < waves.enemiesCount[enemiesIndex])//������� ������, ���� i �� ����� = ������������ ���-�� ������
            {
                GameObject enemy = _enemyPool.Spawn();
                enemy.transform.position = new Vector3(8, -3f);
                Debug.Log($"�������� ���� No. {i + 1}");//������� ����� � �������� �����
                Damaging enemyDamaging = enemy.GetComponent<Damaging>();
                enemyDamaging.pool = _enemyPool;
                enemyDamaging.SetUpHealth(waves.enemyHealth);
                yield return new WaitForSeconds(0.5f);//�������� ��� ���������, ����� �� �������������
                i++;
            }
            yield return new WaitForSeconds(delay);//����� ���� ������� ������, ������� ������� � ��-�� ������� �������
            Debug.Log($"�������� �������� {delay} ������");//����������� ��� �������� ����� �����
            timeIndex++;//��������� ������� � ������� �������
            enemiesIndex++;//��������� ������� � ������� ������
        }
    }

    public void Test()
    {

    }

    public void CreatePlayer()
    {
        GameObject player = _playerPool.Spawn();
        player.transform.position = new Vector3(-8f, -3f);
        Damaging playerDamaging = player.GetComponent<Damaging>();
        playerDamaging.pool = _playerPool;
    }
}

// - �������� ������ ��������� ����. ��������: ���� �� ���� �����, ��� ��� ��������
//   ���������, �.�. ���������� ����� �� 2, 4, 6, 8 � 10 ������, �� ����� ���������
//   �����, ��� �� ����� ������ ����� ���������� 2, 4, 5, 7, 8 ������. ������?

// - �������� �������� moveAgain � enemy

// - ������� ������� ���, ��� ���������� � ������� ������ ��������� ����� ����� ��������

// ����� - ������������� ��������� ����� ��� ���������� � ������� ���������?
// �������� �������� ������ � ���������, ������� ����� ����������� �����-�� ��������?
// ��������, ���� �� ������� ��� ���������, ����� �������������� ���������� ���������.
// UPD: ���� ������� Heal �� G. 
// UPD: ������� ��� Fear �� F, �� ���� ��-�� ����� ������� ������. ��. ����������� � ��� �������.
// UPD: ��������� ������� ������ Rage ��� Fear � Heal, ���� ������� �� ��������� ������� � ������