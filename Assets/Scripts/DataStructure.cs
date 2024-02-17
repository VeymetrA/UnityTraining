using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public struct TestStruct
    {
        public int number;
    }

    public partial class Programm
    {
        public int number = 250;
        public DataStructure sref = new DataStructure();
        public TestStruct testStruct = new TestStruct();

        public void Main()
        {
            //testStruct.number += 1;
            //Test(out sref);//101
            //testStruct.number += 100;//
            Test(out int y);//?? 250

        }

        private void Test(out int x)
        {
            x = 100;
            x += 150;
        }
    }

    public class DataStructure
    {

        public int number = 100; //точка
        public int[] numbers;//массив {1,2,3,4,5,6,7,8,9} L = 9
        public List<int> numbers2;//массив

        public LinkedList<int> linkedList;//список 
        public Dictionary<int, string> hashTable;//таблица // foreach
        public HashSet<int> number3;//уникальные значения

        /// <summary>
        /// ????
        /// </summary>
        public Queue<int> queue;
        public Stack<int> stack;


        public void Main()
        {
            numbers2.Find(x => x > 10);
            numbers2.Find(Check);

            numbers[2] = 1;
            numbers2[2] = 11;
            numbers2.Add(11);
            numbers2.Remove(11);
            numbers2.RemoveAt(2);

            bool Check(int x)
            {
                return x > 10;
            }
        }
    }
}
