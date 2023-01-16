using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cow : Animals
{
    private enum Color { Brown, Black, White }

    [SerializeField] private float maxMilk;
    [SerializeField] private float currentMilk;
    [SerializeField] private Color color;
    
    private void Start()
    { 
        animator.SetInteger("color", GetValueCowColor());
        Specie = Species.Cow;
        Move();
        
    }
    private void FixedUpdate()
    {
        Eat(10f);
       
    }
    
    

    public override void Eat(float mount)
    {
        base.Eat(mount);
        //Animacao comer
    }
    


    private int GetValueCowColor()
    {
        switch (color)
        {
            case Color.Brown:
                return 0;
            case Color.Black:
                return 1;
            case Color.White:
                return 2;
        }

        return 0;
    }
}