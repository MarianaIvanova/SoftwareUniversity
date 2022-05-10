using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LabImplementList
{
    public class CoolList<T>//Ще го орежем, но в основата си ще работи като един C# List<T>.
    {
        private T[] array;
        private int index = 0;

        public CoolList(int initialCapacity = 4)//Първоначалният капацитет по дефолт е 4, ако някой не ни го подаде отвън.
        {
            array = new T[initialCapacity];//първоначалния е 4. Ако знаем, че масива трябва да е с 1000 елемента, още от самото начало го правим new T[1000]

        }

        public int Count { get { return index; } }//В get-а се връща index, за да видим колко ни е големината на листа във всеки момент, който проверим. На тази част, която има добавени елементи, не целия оразмеряван масив - array. Това е размера на list-а.

        public int InternalArrayCount { get { return array.Length;  } }// Тук имаме вече цялата дължина на вътрешния масив.
        public T this[int i]//Така се прави indexer
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }

        public void Add(T element)
        {
            if(index == array.Length)
            {
                array = DoubleArraySize(array);
            }
            array[index] = element;//Може и вместо два реда да напишем array[index++] = element;
            index++;
        }

        private T[] DoubleArraySize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }
    }
}
