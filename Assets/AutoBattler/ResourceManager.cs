using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.AutoBattler
{
    public class ResourceManager : MonoBehaviour
    {
        public int resource = 0;
        public TextMeshProUGUI resources;
        public TextMeshProUGUI notEnoughResources;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(ResourceGeneration());
        }

        // Update is called once per frame
        IEnumerator ResourceGeneration()
        {
            while (true)
            {
                resource += 1;
                resources.text = resource.ToString();
                yield return new WaitForSeconds(0.3f);
            }
        }

        public bool TrySpendResources(int resourcesSpent)
        {
            if (resource >= resourcesSpent)
            {
                resource -= resourcesSpent;
                return true;
            }

            else
            {
                StartCoroutine(Error());
                return false;
            }
        }

        IEnumerator Error()
        {
            notEnoughResources.text = "Not enough resources!";
            notEnoughResources.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            notEnoughResources.gameObject.SetActive(false);
        }
    }
}