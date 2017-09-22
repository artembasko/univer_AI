using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public float Temperature;
    public int Age;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #region Temperature
    public void T1()
    {
        //nachalnie dannie
    }
    public void T2(float temp)
    {
        if (temp >= 34.0 && temp <= 35.0)
        {
            //Rezkaya gipotermiya
        }
        else if (temp > 35.0 && temp < 36.5)
        {
            //gipotermiya
        }
        else if (temp >= 36.5 && temp <= 36.9)
        {
            //Norma
        }
        else if (temp > 36.9 && temp <= 37.5)
        {
            //sybfibrilnaya 
        }
        else if(temp>37.5 && temp<=42.0)
        {
            //Febrilnaya
        }
    }
    public void T3(float temp)
    {
        if (temp < 36.5)
        {
            //Пониженная
        }
        else if (temp > 36.9)
        {
            //Povishenaya
        }
        else
        {
            //Norma
        }

    }
    public void T4(float temp)
    {
        if (temp >= 36.5 && temp <= 36.9)
        {
            //Norma
        }
        else
        {
            //Nenorma
        }
    }
    #endregion

    #region Age
    public void B1()
    {
        //nach dannie
    }
    public void B2(int age)
    {
        if (age > 0 && age <= 33)
        {
            //molodoy
        }
        else if (age >= 34 && age <= 55)
        {
            //srednih let
        }
        else if (age >= 56 && age <= 70)
        {
            //Pogiloy
        }
        else if(age>=71 && age<=100)
        {
            //starchskiy
        }
    }
    #endregion
}
