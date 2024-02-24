using Assets.Scripts.Patterns;
using System.Collections;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _playerPool;
    [SerializeField] private ObjectPool _enemyPool;
    public Waves waves;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        int enemiesIndex = 0;//элемент в массиве врагов
        int timeIndex = 0;//элемент в массиве времени
        foreach (int c in waves.enemiesCount)//перебираю каждый элемент массива enemiesCount
        {
            Debug.Log("Новая волна!");//разделитель волн
            int i = 0;//ввел счетчик
            int delay = waves.timer[timeIndex];//вводим переменную задержки = соответствующий элемент массива времени
            while (i < waves.enemiesCount[enemiesIndex])//создаем врагов, пока i не будет = необходимому кол-ву врагов
            {
                GameObject enemy = _enemyPool.Spawn();
                enemy.transform.position = new Vector3(8, -3f);
                Debug.Log($"Появился враг No. {i + 1}");//счетчик вргов в пределах волны
                Damaging enemyDamaging = enemy.GetComponent<Damaging>();
                enemyDamaging.pool = _enemyPool;
                enemyDamaging.SetUpHealth(waves.enemyHealth);
                yield return new WaitForSeconds(0.5f);//задержка при появлении, чтобы не накладывались
                i++;
            }
            yield return new WaitForSeconds(delay);//здесь ждем столько секунд, сколько указано в эл-те массива времени
            Debug.Log($"Началась задержка {delay} секунд");//комментарий про задержку после волны
            timeIndex++;//следующий элемент в массиве времени
            enemiesIndex++;//следующий элемент в массиве врагов
        }
    }

    public void CreatePlayer()
    {
        GameObject player = _playerPool.Spawn();
        player.transform.position = new Vector3(-8f, -3f);
        Damaging playerDamaging = player.GetComponent<Damaging>();
        playerDamaging.pool = _playerPool;
    }
}