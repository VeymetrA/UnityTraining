using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public void Bark()
    {

    }

    public override void Voice()
    {
        throw new System.NotImplementedException();
    }
}

public class Cat : Animal
{
    public void Meow()
    {

    }

    public override void Voice()
    {
        throw new System.NotImplementedException();
    }
}
// public abstract void Voice();
public abstract class Animal
{
    public int years;
    public string name; 

    public void Eat()
    {

    }

    public abstract void Voice();
}


public class Polygon : MonoBehaviour
{
    //есть собака, которая умеет гавкать и кушать...характеристики количество лет и имя
    //есть кошка, которая умеет мяукает и кушать...характеристики количество лет и имя

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
