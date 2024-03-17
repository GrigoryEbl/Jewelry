using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class MoneyStacker : MonoBehaviour
{
    [SerializeField] private Transform _moneyStack;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private float _minCatchDistance = 0.01f;

    private void Start()
    {
        _places = new Transform[_moneyStack.childCount];

        for (int i = 0; i < _moneyStack.childCount; i++)
        {
            _places[i] = _moneyStack.GetChild(i);
        }
    }

    public void Stacking(Transform money)
    {
        for (int i = 0; i < _places.Length; i++)
        {
            if (_places[i].childCount == 0)
            {
                money.transform.SetParent(_places[i]);

                StartCoroutine(MoveToPlace(money, _places[i]));

                return;
            }
        }
    }

    private IEnumerator MoveToPlace(Transform money, Transform target)
    {
        while (true)
        {
            money.position = Vector3.MoveTowards(money.position, target.position, _speed * Time.deltaTime);

            //if (Vector3.Distance(money.position, target.position) <= _minCatchDistance)
            //    break;

            yield return null;
        }
    }
}
