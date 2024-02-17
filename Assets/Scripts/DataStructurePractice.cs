using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tree<T>
        where T : IComparable<T>
    {
        private TreeNode<T> Root { get; set; }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(value);
            }
            else
            {
                Root.Add(value);
            }
        }

        private class TreeNode<T>
            where T : IComparable<T>
        {
            public T Value;

            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }

            public TreeNode(T value)
            {
                Value = value;
            }

            public void Add(T value)
            {
                if (Value.CompareTo(value) > 0)
                {
                    //right
                    if (Right == null)
                    {
                        Right = new TreeNode<T>(value);
                    }
                    else
                    {
                        Right.Add(value);
                    }
                }
                else
                {
                    //left
                    if (Left == null)
                    {
                        Left = new TreeNode<T>(value);
                    }
                    else
                    {
                        Left.Add(value);
                    }
                }
            }
        }
    }

    public class DataStructurePractice : MonoBehaviour
    {
        //int[] numbers = { 3, 9, 12, 2, 1, 10, 15, 6, 6 };// массив обычный, для сравнения
        List<string> names = new();// список (массив)
        LinkedList<float> floats = new(new[] { 0.2f, 0.1f, 35.2f, 100, 99f, 25.25f });// связанный список
        Dictionary<string, int> colleaguesAge = new Dictionary<string, int>() // словарь
        {
            { "Борис", 50 },
            { "Василий", 35 },
            { "Петр", 75 }
        };
        Stack<string> cyphers = new Stack<string>(); // стек (LIFO)
        Queue<int> queue;// очередь (FIFO)


        // Use this for initialization
        void Start()
        {
            //Array.Resize(ref numbers, numbers.Length + 1);// массив обычный
            //numbers[numbers.Length - 1] = 33;
            //var tmp = numbers.ToList();
            //tmp.RemoveAt(2);
            //var numbersNew = tmp.ToArray();
            //for (int i = 0; i < numbersNew.Length; i++)
            //{
            //    Debug.Log("Element in index " + i + ": " + numbersNew[i]);
            //}
            //this.enabled = false;

            names.Add("Петя");// массив (список)
            names.Add("Вася");
            names.Add("Маша");
            names.Add("Саша");
            names.Add("Боря");
            names.RemoveAt(0);
            names.Sort(); //по хэшу
            Debug.Log("Массив (Список)");
            Debug.Log($"Боря на позиции: {names.IndexOf("Боря")}");
            Debug.Log($"Боря на позиции: {names.Find(x => x == "Боря")}");//лямбда функция 
            Debug.Log($"Боря на позиции: {names.Find(Predicate)}");//локальная функция

            bool Predicate(string x)
            {
                return x == "Боря";
            }

            Debug.Log($"Количество имен в массиве: {names.Count}");
            foreach (string i in names)
            {
                Debug.Log(i);
            }

            Debug.Log("Список");
            floats.AddLast(111.11f);// список
            foreach (float i in floats)
            {
                Debug.Log(i);
            }
            Debug.Log(($"Содержит ли список 123? {floats.Contains(123)}"));


            Debug.Log("Словарь");
            colleaguesAge.Add("Федор", 22);// словарь
            foreach (KeyValuePair<string, int> kvp in colleaguesAge)
            {
                Debug.Log(kvp.Key);
            }

            int value = colleaguesAge["Федор"];// что если? нет ключа 1 - опасно для получения
            colleaguesAge["Петя"] = 11;//для записи нормально

            if (colleaguesAge.TryGetValue("Федор", out int f))// 2 - самое оптимальное
            {
                f = f + 1;
                colleaguesAge["Федор"] = f;
            }

            foreach (var item in colleaguesAge) //ОШИБКИ, нельзя!
            {
                colleaguesAge.Add("", 10);
                colleaguesAge.Remove(item.Key);
            }

            //foreach (var item in colleaguesAge)      другая запись, короче
            //{

            //}

            Debug.Log("Стек");
            cyphers.Push("one");// стек
            cyphers.Push("two");
            cyphers.Push("three");
            cyphers.Push("four");
            cyphers.Push("five");
            cyphers.Pop(); //берет и удаляет 
            cyphers.Peek();//берет

            foreach (string cypher in cyphers)
            {
                Debug.Log(cypher);
            }
            Debug.Log($"Следующий в стеке: {cyphers.Peek()}");
            Debug.Log($"Есть ли в стеке 11? {cyphers.Contains("eleven")}");

            Debug.Log("Очередь");
            Queue<string> cyphers2 = new Queue<string>();// очередь
            cyphers2.Enqueue("nine");
            cyphers2.Enqueue("eight");
            cyphers2.Enqueue("seven");
            cyphers2.Enqueue("six");
            cyphers2.Enqueue("five");
            cyphers2.Dequeue();//берет и удалет 
            cyphers2.Peek();//берет
            foreach (string cypher in cyphers2)
            {
                Debug.Log(cypher);
            }
            Debug.Log($"Следующий в очереди: {cyphers2.Peek()}");
            Debug.Log($"Есть ли в очереди 7? {cyphers2.Contains("seven")}");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}