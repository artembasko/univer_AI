using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    public InputField Temperature_IF;
    public InputField Age_IF;


    public List<Param_of_Item> A_0;
    public List<string> Temper;
    public List<string> Ages;

    public int Line_to_Ekval;
    public List<int> Number_colum;
    
    // Use this for initialization

    void Start()
    {
        //Циклы для обобщения можно вынести в функции
        for (int k = 0; k < A_0.Count; k++)
        {
            for (int i = 0; i < Temper.Count; i++)
            {
                if (A_0[k].Line1[i].NameFunc == Temper[i])
                {
                    if (i + 1 < Temper.Count)
                    {
                        A_0[k].Line1.Add(new Float_String());
                        A_0[k].Line1[i + 1] = Level_Up(A_0[k].Line1[i]);
                    }
                }
            }
            for (int i = 0; i < Ages.Count; i++)
            {
                if (A_0[k].Line2[i].NameFunc == Ages[i])
                {
                    if (i + 1 < Ages.Count)
                    {
                        A_0[k].Line2.Add(new Float_String());
                        A_0[k].Line2[i + 1] = Level_Up(A_0[k].Line2[i]);
                    }
                }

            }
        }



    }
	


    public Float_String Level_Up(Float_String element) // povishaet poriyadok obobsheniya
    {
        Float_String temp = new Float_String();
        temp.Anulyacia();
        switch (element.NameFunc)
        {
            case "T1":
                {
                    temp = T2(element); 
                }
                break;
            case "T2":
                {
                    temp = T3(element);
                }
                break;
            case "T3":
                {
                    temp = T4(element);
                }
                break;
            case "B1":
                {
                    temp = B2(element);
                }
                break;
            default:
                {
                    temp = null;
                }
                break;

        }
        return temp;

    }
    /*
    public bool Uslovie(Float_String element_temperature , Float_String element_age)
    {
        if (
                (element_temperature.NameFunc != Index_Temperature[Index_Temperature.Count - 1] && element_age.NameFunc != Index_Age[Index_Age.Count - 1]) ||
                (element_temperature.NameFunc != null && element_age.NameFunc != Index_Age[Index_Age.Count - 1]) ||
                (element_temperature.NameFunc != Index_Temperature[Index_Temperature.Count - 1] && element_age.NameFunc != null) ||
                (element_temperature.NameFunc != null && element_age.NameFunc != null)
            )
        {

            return true;
        }
        else
        {
            return false;
        }
    }
    */

    #region Temperature
    public void T1()
    {
        //nachalnie dannie
    }
    public Float_String T2(Float_String temp)
    {
        if (temp.Param_f >= 34.0 && temp.Param_f <= 35.0)
        {
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T2";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Резкая гипотермия";
            temp2.Z = temp.Z;
            return temp2;
        }
        else if (temp.Param_f > 35.0 && temp.Param_f < 36.5)
        {
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T2";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Гипотермия";
            temp2.Z = temp.Z;
            return temp2;
            //gipotermiya
        }
        else if (temp.Param_f >= 36.5 && temp.Param_f <= 36.9)
        {
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T2";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Норма";
            temp2.Z = temp.Z;
            return temp2;
            //Norma
        }
        else if (temp.Param_f > 36.9 && temp.Param_f <= 37.5)
        {
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T2";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Субфебрильная температура";
            temp2.Z = temp.Z;
            return temp2;
            //sybfibrilnaya 
        }
        else if (temp.Param_f > 37.5 && temp.Param_f <= 42.0)
        {
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T2";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Фебрильная температура";
            temp2.Z = temp.Z;
            return temp2;
            //Febrilnaya
        }
        else
        {
            return null;
        }
    }
    public Float_String T3(Float_String temp)
    {
        if (temp.Param_f < 36.5)
        {
            //Пониженная
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T3";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Пониженная";
            temp2.Z = temp.Z;
            return temp2;
        }
        else if (temp.Param_f > 36.9)
        {
            //Povishenaya
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T3";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Повышенная";
            temp2.Z = temp.Z;
            return temp2;
        }
        else
        {
            //Norma
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T3";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Норма";
            temp2.Z = temp.Z;
            return temp2;
        }

    }
    public Float_String T4(Float_String temp)
    {
        if (temp.Param_f >= 36.5 && temp.Param_f <= 36.9)
        {
            //Norma
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T4";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Норма";
            temp2.Z = temp.Z;
            return temp2;
        }
        else
        {
            //Nenorma
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "T4";
            temp2.Param_f = temp.Param_f;
            temp2.Param_s = "Ненорма";
            temp2.Z = temp.Z;
            return temp2;
        }
    }
    #endregion

    #region Age
    public void B1()
    {
        //nach dannie
    }
    public Float_String B2(Float_String age)
    {
        if (age.Param_i > 0 && age.Param_i <= 33)
        {
            //molodoy
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "B2";
            temp2.Param_i = age.Param_i;
            temp2.Param_s = "Молодой";
            temp2.Z = age.Z;
            return temp2;
        }
        else if (age.Param_i >= 34 && age.Param_i <= 55)
        {
            //srednih let
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "B2";
            temp2.Param_i = age.Param_i;
            temp2.Param_s = "Средних лет";
            temp2.Z = age.Z;
            return temp2;
        }
        else if (age.Param_i >= 56 && age.Param_i <= 70)
        {
            //Pogiloy
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "B2";
            temp2.Param_i = age.Param_i;
            temp2.Param_s = "Пожилой";
            temp2.Z = age.Z;
            return temp2;
        }
        else if (age.Param_i >= 71 && age.Param_i <= 100)
        {
            //starchskiy
            Float_String temp2 = new Float_String();
            temp2.Anulyacia();
            temp2.NameFunc = "B2";
            temp2.Param_i = age.Param_i;
            temp2.Param_s = "Старческий";
            temp2.Z = age.Z;
            return temp2;
        }
        else
        {
            return null;
        }
    }
    #endregion
}
[Serializable]
public class Param_of_Item
{
    public List<Float_String> Line1;//Один набор
    public List<Float_String> Line2;//Один набор


}

[Serializable]
public class Float_String//тип переменной которая может содержать либо флоат либо стринг
{
   public string NameFunc;
   public float Param_f;
   public int Param_i;
   public string Param_s;
   public int Z;


   public void Anulyacia()
   {
       NameFunc = null;
       Param_f = 0.0f;
       Param_i = 0;
       Param_s = null;
       // Param_L.Clear();
   }
}
