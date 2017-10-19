using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;

public class Main_2 : MonoBehaviour
{
    [Header("First")]
    public List<mass> Temperature;
    
    public List<mass> Age;
    public List<mass> Result;
    [Range(0, 3)]
    public int line_0;
    [Range(0, 3)]
    public int column_0;
    //[Range(0, 3)]
    //public int line_1;
    [Range(4, 5)]
    public int column_1;

    public Text FindResult;

    [Header("Second")]
    public List<parent> Pa;

    public List<int> Test;
    public string Test_T;//"T3"
    public string Test_A; //"B2"
    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 4; i++)
        {
            Temperature[1].CountParam[i] = null;
            Temperature[1].CountParam[i] = T2(float.Parse(Temperature[0].CountParam[i]));
            Temperature[2].CountParam[i] = null;
            Temperature[2].CountParam[i] = T3(float.Parse(Temperature[0].CountParam[i]));
            Temperature[3].CountParam[i] = null;
            Temperature[3].CountParam[i] = T4(float.Parse(Temperature[0].CountParam[i]));
        }
        for (int i = 0; i < 4; i++)
        {
            Age[1].CountParam[i] = null;
            Age[1].CountParam[i] = B2(float.Parse(Age[0].CountParam[i]));
        }
        ShowTable();
        

    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDeclaration xmlDec = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlDoc.AppendChild(xmlDec);

            #region testxml
            ///*<!--база данных-->*/  
            ////комментарий уровня root  
            ////-> //XmlComment Comment0 = XmlDoc.CreateComment("база данных");
            ////добавляем в документ  
            ////-> //XmlDoc.AppendChild(Comment0);   
            ///*<database name="abc"></database>*/ 
            ////создание корневого элемента  
            //XmlElement ElementDatabase = XmlDoc.CreateElement("database");
            ////создание атрибута 
            //ElementDatabase.SetAttribute("name", "abc");
            ////добавляем в документ  
            //XmlDoc.AppendChild(ElementDatabase);   

            ///*<!--описание структуры таблицы-->*/ 
            ////комментарий уровня вложенности root/child  
            //XmlComment Comment1 = XmlDoc.CreateComment("описание структуры таблицы");
            ////добавляем в ElementDatabase 
            //ElementDatabase.AppendChild(Comment1);  

            ///*<table_structure name="books"></table_structure>*/  
            ////создание дочернего элемента уровня вложенности root/child  
            //XmlElement ElementTable_Structure = XmlDoc.CreateElement("table_structure");
            ////создание атрибута 
            //ElementTable_Structure.SetAttribute("name", "books");  
            ////добавляем в ElementDatabase 
            //ElementDatabase.AppendChild(ElementTable_Structure);

            ///*<field Field="id" type="uint"></field>*/ 
            ////создание дочернего элемента уровня вложенности root/child/child 
            //XmlElement ElementField0 = XmlDoc.CreateElement("field");
            ////создание атрибута 
            //ElementField0.SetAttribute("Field",  "id"); 
            //ElementField0.SetAttribute("type", "uint");
            ////добавляем в ElementTable_Structure 
            //ElementTable_Structure.AppendChild(ElementField0);

            ///*<field Field="name" type="string"></field>*/ 
            ////создание дочернего элемента уровня вложенности root/child/child  
            //XmlElement ElementField1 = XmlDoc.CreateElement("field");
            ////создание атрибута
            //ElementField1.SetAttribute("Field", "name"); 
            //ElementField1.SetAttribute("type", "string");
            ////добавляем в ElementTable_Structure  
            //ElementTable_Structure.AppendChild(ElementField1);  


            ///*<field Field="amount" type="int"></field>*/
            ////создание дочернего элемента уровня вложенности root/child/child  
            //XmlElement ElementField2 = XmlDoc.CreateElement("field");
            ////создание атрибута 
            //ElementField2.SetAttribute("Field", "amount"); 
            //ElementField2.SetAttribute("type", "int");
            ////добавляем в ElementTable_Structure 
            //ElementTable_Structure.AppendChild(ElementField2);

            ///*<field Field="price" type="decimal"></field>*/  
            ////создание дочернего элемента уровня вложенности root/child/child  
            //XmlElement ElementField3 = XmlDoc.CreateElement("field");
            ////создание атрибута 
            //ElementField3.SetAttribute("Field", "price");  
            //ElementField3.SetAttribute("type", "decimal");
            ////добавляем в ElementTable_Structure
            //ElementTable_Structure.AppendChild(ElementField3);  

            ///*<!--данные таблицы-->*/  
            ////комментарий уровня вложенности root/child  
            //XmlComment Comment2 = XmlDoc.CreateComment("данные таблицы");
            ////добавляем в ElementDatabase 
            //ElementDatabase.AppendChild(Comment2);  

            ///*<table_data name="books"></table_data>*/ 
            ////создание дочернего элемента уровня вложенности root/child 
            //XmlElement ElementTable_Data = XmlDoc.CreateElement("table_data");
            ////создание атрибута 
            //ElementTable_Data.SetAttribute("name", "books"); 
            ////добавляем в ElementDatabase 
            //ElementDatabase.AppendChild(ElementTable_Data);
            #endregion
            XmlElement ElementMain = XmlDoc.CreateElement("main");
            XmlDoc.AppendChild(ElementMain);
            WriteData(XmlDoc, ElementMain, 0, Test, Test_T, Test_A);
            WriteData(XmlDoc, ElementMain, 1, Test, Test_T, Test_A);

            XmlDoc.Save("Data/Save.xml");
            Debug.Log("Ok");

        }
    }

    void WriteData(XmlDocument XmlDoc,XmlElement Main, int number, List<int> DataLVL, string Current_Temperature, string Current_Age)//Запись одного елемента
    {
        XmlElement ElementDatabase = XmlDoc.CreateElement("database_"+number.ToString());
        ElementDatabase.SetAttribute("name_0", Current_Temperature);
        ElementDatabase.SetAttribute("name_1", Current_Age);
        ElementDatabase.SetAttribute("LvL_piramid", DataLVL.Count.ToString());
        Main.AppendChild(ElementDatabase);

        XmlComment Comment1 = XmlDoc.CreateComment("Массив уровней (LVL)");
        ElementDatabase.AppendChild(Comment1);  
        XmlElement ElementLVL_childs = XmlDoc.CreateElement("LVL_childs");
        ElementLVL_childs.SetAttribute("name", "LVL");
        ElementDatabase.AppendChild(ElementLVL_childs);

            foreach (int temp in DataLVL)//Writing LVL
            {
                XmlElement ElementField0 = XmlDoc.CreateElement("field");
                ElementField0.SetAttribute("Index", temp.ToString());
                ElementField0.SetAttribute("type", "int");
                ElementLVL_childs.AppendChild(ElementField0);
            }

        XmlElement ElementCurrent_Temperature = XmlDoc.CreateElement("Current_Temperature");
        ElementCurrent_Temperature.SetAttribute("name", Current_Temperature);
        ElementCurrent_Temperature.SetAttribute("type", "string");
        ElementDatabase.AppendChild(ElementCurrent_Temperature);

        XmlElement ElementCurrent_Age = XmlDoc.CreateElement("Current_Age");
        ElementCurrent_Age.SetAttribute("name", Current_Age);
        ElementCurrent_Age.SetAttribute("type", "string");
        ElementDatabase.AppendChild(ElementCurrent_Age);


    }
    public void FindRes()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Result[0].CountParam[line_0] != Result[0].CountParam[i])//то проверяем
            {
                if (Temperature[column_0].CountParam[i] == Temperature[column_0].CountParam[line_0] && Age[column_1 - 4].CountParam[i] == Age[column_1 - 4].CountParam[line_0])
                {
                    FindResult.text = ("Конфликт!" + "  Line = "+i) ;
                    return;
                }
                else
                {
                    FindResult.text = "Нет Конфликта";
                }
            }

        }

    }
    public void ShowTable()
    {
        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text = Temperature[0].CountParam[i];
            gameObject.transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text = Temperature[1].CountParam[i];
            gameObject.transform.GetChild(i + 1).transform.GetChild(2).GetComponent<Text>().text = Temperature[2].CountParam[i];
            gameObject.transform.GetChild(i + 1).transform.GetChild(3).GetComponent<Text>().text = Temperature[3].CountParam[i];
            gameObject.transform.GetChild(i + 1).transform.GetChild(4).GetComponent<Text>().text = Age[0].CountParam[i];
            gameObject.transform.GetChild(i + 1).transform.GetChild(5).GetComponent<Text>().text = Age[1].CountParam[i];
            gameObject.transform.GetChild(i + 1).transform.GetChild(6).GetComponent<Text>().text = Result[0].CountParam[i];
        }
    }

    public void Obobschenie_2()
    {
        //добавить условие если нет конфликтов то выполнять ниже
        Pa[0].Current_Temperature = ("T" + (column_0 + 1).ToString());
        Pa[0].Current_Age = ("B" + (column_1 - 3).ToString());
        Pa[0].LVL.Add(0);
        Pa[0].Obobschenie();
        /*
        foreach (parent temp in Pa[0].childs)
        {
            temp.Obobschenie();
        }
            for(int i =0; i< Pa[0].childs.Count; i++)
            {
                foreach (parent temp in Pa[0].childs[i].childs)
                {
                temp.Obobschenie();
                }
            }
        /*Pa[0].First_Temperature = float.Parse(Temperature[0].CountParam[line_0]);
        Pa[0].First_Age = int.Parse(Age[0].CountParam[line_0]);
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                Pa[0].childs[i].Current_Temperature = Level_Up_Name(Pa[0].Current_Temperature);
                Pa[0].childs[i].Current_Age = Pa[0].Current_Age;
                Pa[0].childs[i].First_Temperature = Pa[0].First_Temperature;
                Pa[0].childs[i].First_Age = Pa[0].First_Age;
            }
            else if (i == 1)
            {
                Pa[0].childs[i].Current_Temperature = Pa[0].Current_Temperature;
                Pa[0].childs[i].Current_Age = Level_Up_Name(Pa[0].Current_Age);
                Pa[0].childs[i].First_Temperature = Pa[0].First_Temperature;
                Pa[0].childs[i].First_Age = Pa[0].First_Age;
            }
            else if (i == 2)
            {
                Pa[0].childs[i].Current_Temperature = Pa[0].Current_Temperature;
                Pa[0].childs[i].Current_Age = null;
                Pa[0].childs[i].First_Temperature = Pa[0].First_Temperature;
                Pa[0].childs[i].First_Age = Pa[0].First_Age;
            }
            else if (i == 3)
            {
                Pa[0].childs[i].Current_Temperature = null;
                Pa[0].childs[i].Current_Age = Pa[0].Current_Age;
                Pa[0].childs[i].First_Temperature = Pa[0].First_Temperature;
                Pa[0].childs[i].First_Age = Pa[0].First_Age;
            }

        }*/
         

    }
    public string Level_Up(string NameFunc, float element) // povishaet poriyadok obobsheniya
    {
        switch (NameFunc)
        {
            case "T1":
                {
                    return T2(element);
                }
            case "T2":
                {
                    return T3(element);
                }
            case "T3":
                {
                    return T4(element);
                }
            case "B1":
                {
                    return B2(element);
                }
            default:
                {
                    return null;
                }

        }

    }
    /*
    public string Level_Up_Name(string NameFunc) // povishaet poriyadok obobsheniya
    {
        switch (NameFunc)
        {
            case "T1":
                {
                    return "T2";
                }
            case "T2":
                {
                    return "T3";
                }
            case "T3":
                {
                    return "T4";
                }
            case "B1":
                {
                    return "B2";
                }
            default:
                {
                    return null;
                }

        }

    }
    */
    #region Temperature

    public string T2(float temp)
    {
        if (temp >= 34.0 && temp <= 35.0)
        {
            return "Резкая гипотермия";
        }
        else if (temp > 35.0 && temp < 36.5)
        {
            return "Гипотермия";
        }
        else if (temp >= 36.5 && temp <= 36.9)
        {
            return "Норма";
        }
        else if (temp > 36.9 && temp <= 37.5)
        {
            return "Субфебрильная температура";
        }
        else if (temp > 37.5 && temp <= 42.0)
        {
            return "Фебрильная температура";
        }
        else
        {
            return "Error";
        }
    }
    public string T3(float temp)
    {
        if (temp < 36.5)
        {
            return "Пониженная";
        }
        else if (temp > 36.9)
        {
            return "Повышенная";
        }
        else
        {
            return "Норма";
        }

    }
    public string T4(float temp)
    {
        if (temp >= 36.5 && temp <= 36.9)
        {
            return "Норма";
        }
        else
        {
            return "Ненорма";
        }
    }
    #endregion

    #region Age
    public string B2(float age)
    {
        if (age > 0 && age <= 33)
        {
            return "Молодой";
        }
        else if (age >= 34 && age <= 55)
        {
            return "Средних лет";
        }
        else if (age >= 56 && age <= 70)
        {
            return "Пожилой";
        }
        else if (age >= 71 && age <= 100)
        {
            return "Старческий";
        }
        else
        {
            return "Error";
        }
    }
    #endregion
}
[Serializable]
public class mass
{
   public List<string> CountParam;
}
[Serializable]
public class parent
{
    public List<int> LVL = new List<int>();
    public string Current_Temperature;//"T3"
    public string Current_Age; //"B2"
    string Limit_Name_Temperature = "T4";// придельное значение Ообщения Т4
    string Limit_Name_Age = "B2";// придельное значение Ообщения B2
                                 //  public float First_Temperature;//T1 = 36.0
                                 // public int First_Age;// B1 = 12
    public List<parent> childs = new List<parent>(); //Все порожедения [T3;B2], а ето 1.
    public string Level_Up_Name(string NameFunc) // povishaet poriyadok obobsheniya
    {
        switch (NameFunc)
        {
            case "T1":
                {
                    return "T2";
                }
            case "T2":
                {
                    return "T3";
                }
            case "T3":
                {
                    return "T4";
                }
            case "B1":
                {
                    return "B2";
                }
            default:
                {
                    return null;
                }

        }

    }
    void ravno(List<int> otkuda, List<int> cuda)
    {
        foreach (int temp in otkuda)
        {
            cuda.Add(temp);
        }
    }
    public void Obobschenie()
    {
        if ((Current_Temperature != Limit_Name_Temperature && Current_Age != Limit_Name_Age) || (Current_Age != Limit_Name_Age && Current_Temperature != null) || (Current_Age != null && Current_Temperature != Limit_Name_Temperature))
        {
            
            if (Current_Temperature != null && Current_Age != null)//добавить условие если нет конфликтов то выполнять ниже
            {

                for (int i = 0, j = 0; i < 4 && j < 4; i++)
                {
                    if (i == 0)
                    {
                        if (Level_Up_Name(Current_Temperature) != null && Current_Age != null)
                        {
                            childs.Add(new parent());
                            ravno(LVL, childs[j].LVL);
                            childs[j].LVL.Add(j);
                            childs[j].Current_Temperature = Level_Up_Name(Current_Temperature);
                            childs[j].Current_Age = Current_Age;
                            j++;
                        }
                    }
                    else if (i == 1)
                    {
                        if (Current_Temperature != null && Level_Up_Name(Current_Age) != null)
                        {
                            childs.Add(new parent());
                            ravno(LVL, childs[j].LVL);
                            childs[j].LVL.Add(j);
                            childs[j].Current_Temperature = Current_Temperature;
                            childs[j].Current_Age = Level_Up_Name(Current_Age);
                            j++;
                        }
                    }
                    else if (i == 2)
                    {
                        if (Current_Temperature != null)
                        {
                            childs.Add(new parent());
                            ravno(LVL, childs[j].LVL);
                            childs[j].LVL.Add(j);
                            childs[j].Current_Temperature = Current_Temperature;
                            childs[j].Current_Age = null;
                            j++;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Current_Age != null)
                        {
                            childs.Add(new parent());
                            ravno(LVL, childs[j].LVL);
                            childs[j].LVL.Add(j);
                            childs[j].Current_Temperature = null;
                            childs[j].Current_Age = Current_Age;
                            j++;
                        }
                    }

                }
            }
            else // if( Current_Temperature != null || Current_Age != null)
            {
                for (int i = 0, j = 0; i < 4 && j < 4; i++)
                {
                    //childs.Add(new parent());
                    if (i == 0)
                    {
                        if (Level_Up_Name(Current_Temperature) != null && Current_Age == null)
                        {
                            childs.Add(new parent());
                            //childs[j].LVL = LVL;
                            ravno(LVL, childs[j].LVL);
                            childs[j].LVL.Add(j);
                            childs[j].Current_Temperature = Level_Up_Name(Current_Temperature);
                            childs[j].Current_Age = Current_Age;
                            j++;
                        }
                    }
                    else if (i == 1)
                    {
                        if (Current_Temperature == null && Level_Up_Name(Current_Age) != null)
                        {
                            childs.Add(new parent());
                            ravno(LVL, childs[j].LVL);
                            childs[j].LVL.Add(j);
                            childs[j].Current_Temperature = Current_Temperature;
                            childs[j].Current_Age = Level_Up_Name(Current_Age);
                            j++;
                        }                      
                    }
                }
            }
           // Obobschenie();
        }
        else
        {
            return;
        }
        
        // Obobschenie(); //Если визвать ету же функцию в самой функции то пишет: Запрошенная операция вызвала переполнение стека,


    }
    
}
[Serializable]
public class child
{
    public List<string> childs;
}

