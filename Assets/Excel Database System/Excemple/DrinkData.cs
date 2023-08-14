using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrinkData : ScriptableObject
{
    [SerializeField] protected uint _id;
    [SerializeField] protected string _name;
    [SerializeField] protected float _capacity;
    [SerializeField] protected int _price;
    [SerializeField] protected string _description;
}
