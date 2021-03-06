﻿using System;
using static System.BitConverter;   //требуется для выполнения задания №4
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_LabRab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                // *** ЗАДАНИЕ 1 ***
                int i = 4;          //инициализация при создании
                double d;           //инициализация 
                d = 4.2;            //после создания
                bool b1, b2;        //инициализация булевых переменных
                b2 = (i < d);       //переменную b2 инициализируем через выражение
                b1 = b2;            //и через другую переменную

                //все перечисленные выше переменные относятся к типам значений
                /*
                Система общих типов CTS определяет способ объявления, использования и управления типами в среде CLR, 
                а также является важной составной частью поддержки межъязыковой интеграции в среде выполнения. 
                Система общих типов выполняет следующие функции.

                Типы в .NET

                Все типы на платформе .NET делятся на типы значений и ссылочные типы.

                Типы значений — это типы данных, объекты которых представлены фактическим значением объекта. Если 
                экземпляр типа значения присваивается переменной, то эта переменная получает новую копию значения.
                
                Ссылочные типы — это типы данных, объекты которых представлены ссылкой (аналогичной указателю) на 
                фактическое значение объекта. Если экземпляр ссылочного типа присваивается переменной, то эта 
                переменная будет ссылаться (указывать) на исходное значение. Копирования при этом не происходит.

                Система общих типов CTS на платформе .NET поддерживает следующие пять категорий типов:
                Классы
                Структуры
                Перечисления
                Интерфейсы
                Делегаты*/

                // *** ЗАДАНИЕ 2 *** 

                double dI = i;      //пример неявного приведения типа из меньшего типа в больший
                int iD1 = (int)d;   //пример явного приведения типа, здесь (int) - оператор явного преобразования
                string str4 = "4";  //строка со значением 4
                int iD3 = Int32.Parse(str4);    //пример преобразования с использованием вспомогательных классов -
                //- парсим строку на предмет нахождения значения, которое можно присвоить переменнной типа int

                //ПРИМЕРЫ ОШИБОК
                //int iD2 = d;      //пример неявного приведения типа, который приведет к ошибке при компиляции

                /*ошибка во время выполнения может возникнуть тогда, когда производится явное преобразование ссылочных типов.
                подробнее из поддержки MSFT: https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/casting-and-type-conversions 
                Например, имеется класс Animal. Его экстендят классы Reptile и Mammal.
                Если производить следующие приведения типов, ошибки не возникнет:

                Animal anim = new Animal();
                Reptile rep1 = anim;       - неявное приведение типа Animal к Reptile
                Mammal mam1 = new Mammal();
                Animal anim2 = (anim)mam1; - явное приведение типа Mammal к Animal, при этом anim2 передаются значения 
                только полей, определенных базовым классом Animal

                Ошибка возникнет в момент выполнения программы тогда, когда программа попытается выполнить следующий оператор:
                Reptile rep2 = (Reptile) mam1; , т.к. невозможно выполнить приведение одного дочернего класса к другому, даже
                если у них один и тот же предок
                */                
                
                //объявление строк 
                string str1 = "double dI = i;       //пример неявного приведения типа";
                string str2 = "int iD1 = (int)d;    //пример явного приведения типа";
                string str3 = "int iD2 = d;         //еще один пример неявного приведения типа, который приведет к ошибке при компиляции";
                string[] aStr = {str1, str2, str3}; //и массива из объявленных выше строк

                Console.WriteLine("Значения переменных: \ni = "+i+"\nd = "+d+"\niD3 = "+iD3+"\n");

                for (int iter = 0; iter < aStr.Length; iter++){ 
                    Console.WriteLine(aStr[iter]);
                }

                // *** ЗАДАНИЕ 3 ***

                Object obj1 = i;    //переменной типа Object можно присвоить любое значение, в данном случае int i упакована до Object
                Object obj2 = b2;   //хоть целочисленное, хоть булевое
                Object obj3 = str4; //хоть String

                //в выражении ниже происходит распаковка Object до типа int, а затем автоматическое приведение к значению double 
                double result1 = ((int)obj1 + dI - iD3) * 2;
                Console.WriteLine("\n((int)obj1 + dI - iD3) * 2 = "+result1);  //(4 + 4 - 4) * 2 = 8
                //итого в данном примере осуществлены одна успешная запаковка и одна успешная распаковка значения в/из Object

                //Еще одна возможность показать еще один пример ошибки приведения типов с отрабатыванием исключения System.InvalidCastException
                Console.WriteLine("Для того, чтобы вывести ошибку, введите число, больше 5. Чтобы пропустить, введите число, не больше 5.");
                int x = Int32.Parse(Console.ReadLine());        //выполнено задание 5 ранее по тексту)))
                if (x > 5) {
                Console.WriteLine("\nСледующее выражение вызовет исключение System.InvalidCastException, которое будет описано блоком catch:\n((short)obj1 + dI - iD3) * 2;  - это вызвано вследствии неверного приведения типа Object.\n");
                double result2 = ((short)obj1 + dI - iD3) * 2; 
                } 
                
                // *** ЗАДАНИЕ 4 ***
                
                byte[] aByte = new byte[4] {0x0A, 0x0B, 0x00, 0x00}; //объявление массива байт
                Console.WriteLine("\nВывод массива байт: ");
                for (int j = 0; j<aByte.Length; j++){
                    Console.WriteLine(aByte[j]);
                }

                Console.WriteLine("");
                int y = ToInt32(aByte, 0);  //используем static System.BitConverter.ToInt32(массив байт, индекс первого байта)
                Console.WriteLine("Массив байт aByte = {0x0A, 0x0B, 0x00, 0x00} после преобразования в int = "+y); //0B0A = 2826

                // *** ЗАДАНИЕ 5 ***
                // см. строку 94 int x = Int32.Parse(Console.ReadLine()); 

                // *** ЗАДАНИЕ 6 ***
                //программу будем выполнять здесь

                Console.WriteLine("");
                string inputstr;

                Console.WriteLine("Введите строку, подлежащую разбору:");
                inputstr = Console.ReadLine();
                char[] aChar = inputstr.ToCharArray();  //переводим введенную строку в массив символов
                
                int iterat = 0;                             //итератор для красивого вывода строки в следующем цикле
                foreach (char letter in aChar){             //цикл - для каждого символа letter в массиве aChar выполнить:
                    int value = Convert.ToInt32(letter);    //объявить новый int value и присвоить ему int значение очередного letter
                    Console.WriteLine("aChar["+iterat+"] = "+value);//вывести value
                    string hexOutput = String.Format("{0:X}", value);//данный value перевести в hex-код, записать в строку
                    Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);//вывести строку с hex-кодом
                    iterat++;
                }

                for (int j = 0; j < aChar.Length; j++){     //тот же самый цикл, но через for
                    Console.WriteLine("aChar["+j+"] - "+aChar[j]+" in dec = "+Convert.ToInt32(aChar[j])+", in hex = "+String.Format("{0:X}", Convert.ToInt32(aChar[j])));
                }
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
            finally{
                Console.Write("Press <Enter>");
                Console.ReadLine();
            }
        }
    }
}