using System.Collections;
using UnityEngine;
using System.Collections.Generic;


namespace Assets.Scripts.Patterns
{
    public class ObjectPool : MonoBehaviour
    {
        private Stack<GameObject> _pool = new Stack<GameObject>();
        [SerializeField] private GameObject _prefab;

        public GameObject Spawn()
        {
            GameObject something = null;

            if (_pool.Count > 0)
            {
                something = _pool.Pop();
                something.SetActive(true);
            }
            else
            {
                something = Instantiate(_prefab);
            }
            return something;
        }

        public void Despawn(GameObject obj)
        {
            _pool.Push(obj);
            obj.SetActive(false);
        }
    }
}