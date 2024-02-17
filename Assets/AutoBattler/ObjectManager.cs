using Assets.Scripts.Patterns;
using System.Collections;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _playerPool;
    [SerializeField] private ObjectPool _enemyPool;
    public Waves waves;
    public string hello = "Привет!";

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

// - Прописал логику появления волн. Проблема: хотя по логу видно, что все работает
//   корректно, т.е. появляются волны по 2, 4, 6, 8 и 10 врагов, по факту визуально
//   видно, что на сцене вместо этого появляются 2, 4, 5, 7, 8 врагов. Почему?

// - Настроил параметр moveAgain в enemy

// - Поменял внешний вид, все перекрасил и добавил врагам изменение цвета через корутину

// Далее - предусмотреть получение урона при нахождении в радиусе поражения?
// Добавить активную кнопку с кулдауном, которая будет производить какое-то действие?
// Например, урон по площади или заморозка, может сопровождаться визульными эффектами.
// UPD: Пока добавил Heal на G. 
// UPD: Добавил еще Fear на F, но пока из-за этого убегают игроки. См. комментарии в том скрипте.
// UPD: Попытался сделать ресурс Rage для Fear и Heal, пока застрял на настройке полотна и текста