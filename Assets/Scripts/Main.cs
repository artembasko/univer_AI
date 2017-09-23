using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class Main : MonoBehaviour
{
    public InputField Temperature_IF;
    public InputField Age_IF;

    public float Temperature;
    public int Age;
    public List<Float_String> A_0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void FindAnswers()
    {
        Temperature = 0.0f;//Zbros
        Temperature = float.Parse(Temperature_IF.text);
        Age = 0;//Zbros
        Age = int.Parse(Age_IF.text);
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
[Serializable]
public class Test_Temp_Age
{
    public List<Float_String> TTA;

}

[Serializable]
public class Float_String//тип переменной которая может содержать либо флоат либо стринг
{
   public float Param_f;
   public string Param_s;
  // public List<Float_String> Param_L;

   public void Anulyacia()
   {
       Param_f = 0.0f;
       Param_s = null;
       // Param_L.Clear();
   }
}
