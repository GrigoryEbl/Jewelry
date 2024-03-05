using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyFolder : MonoBehaviour
{

    [SerializeField] private GameObject _place;
    [SerializeField] private LayerMask _moneylayer;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private Utilizer _utilizer;
    private Money[] _moneys;

    private void Awake()
    {
        _utilizer = GetComponentInParent<Utilizer>();
        _moneys = new Money[30];
        _places = new Transform[30];

        for (int i = 0; i < _place.transform.childCount; i++)
        {
            _places[i] = _place.transform.GetChild(i);
        }
    }

    private void OnEnable()
    {
        _utilizer.MoneyExit += AddMoney;
    }

    private void OnDisable()
    {
        _utilizer.MoneyExit -= AddMoney;
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.TryGetComponent(out Money money))
    //    {

    //    }
    //}

    private void AddMoney()
    {
        Collider[] moneyColliders = Physics.OverlapSphere(transform.position, 10f, _moneylayer);

        for (int i = 0; i < moneyColliders.Length; i++)
        {
            if (moneyColliders[i].TryGetComponent(out Money money))
            {
                _moneys[i] = money;
            }
        }

    }

    private void Update()
    {
        if (_moneys == null)
            return;

        for (int i = 0; i < _moneys.Length; i++)
        {
            _moneys[i].transform.position = Vector3.MoveTowards(_moneys[i].transform.position, _places[i].position, _speed * Time.deltaTime);
                if(_moneys[i].transform.position == _places[i].position)
            {
                _moneys[i].gameObject.isStatic = true;
            }    
        }

    }
}
