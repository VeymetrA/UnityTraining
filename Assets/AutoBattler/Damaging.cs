using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Patterns;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.SearchService;


public class Damaging : MonoBehaviour
{
    public int hp;
    public int damage;
    public int reloadTime = 5;
    public bool reloaded = true;
    public TextMeshProUGUI health;
    public ObjectPool pool;
    public TextMeshProUGUI TMP;
    public int rage = 0;
    public void SetUpHealth(int value)
    {
        hp = value;
        health.text = hp.ToString();
    }

    public IEnumerator Reloading()
    {

        reloaded = false;
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;

    }

    public void Attack(Damaging otherObject)
    {
        if(reloaded)
        {
            if (otherObject != null)
            {
                StartCoroutine(Reloading());
                otherObject.GetDamaged(damage);
            }
        }
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
        health.text = hp.ToString();
        if (hp < 0)
        {
            pool.Despawn(gameObject);
        }
    }

    public void Fear()
    {
        GameObject[] possibleFearTargets;//сделал массив объектов
        possibleFearTargets = GameObject.FindGameObjectsWithTag("Enemy");//добавил в массив всех врагов
        GameObject fearTarget = possibleFearTargets[Random.Range(0, possibleFearTargets.Length)];//беру одного из возможных врагов случайным образом. Это ведь номер элемента массива?
        //target = GameObject.FindWithTag("Enemy"); //вместо этого три строки выше
        fearTarget.GetComponent<SpriteRenderer>().flipY = true;
        fearTarget.GetComponent<Damaging>().damage = 0;
        fearTarget.GetComponent<CharacterMovement>().movementSpeed = 5;
        Debug.Log("Враг испуган!");
        return;
    }//Не работает, как надо. нужно разобраться с otherObject, но почему убегают несколько врагов?

    public int Heal()
    {
        Debug.Log("Игрок подлечился!");
        return gameObject.GetComponent<Damaging>().hp += 100;
    }

    void Start()
    {
        health.text = hp.ToString();
        //TMP.text = rage.ToString();
    }

    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Fear();
            }
        }

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Heal();
            }
        }
    }
}
