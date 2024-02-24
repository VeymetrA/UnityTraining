using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.AutoBattler
{
    [CreateAssetMenu(fileName = "UnitPrice", menuName = "Data/UnitPrice")]
    public class UnitPrices : ScriptableObject
    {
        [SerializeField] private List<Data> datas;

        public int GetPrice(string id)
        {
            Data data = datas.Find(x => x.id == id);
            return data.price;
        }

        /*
        private bool FindData(Data x, string id)
        {
            return x.id == id;
        }
        ///*/

        [Serializable]
        private struct Data
        {
            public int price;
            public string id;
        }
    }
}