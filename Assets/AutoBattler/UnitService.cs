using System.Collections;
using UnityEngine;

namespace Assets.AutoBattler
{
    public class UnitService : MonoBehaviour
    {
        public ObjectManager objectManager;
        public ResourceManager resourceManager;
        public UnitPrices unitPrices;


        public void PlayerCreatesUnit(string id)
        {
            if (resourceManager.TrySpendResources(unitPrices.GetPrice(id)))
            {
                objectManager.CreatePlayer();
            }
        }
    }
}