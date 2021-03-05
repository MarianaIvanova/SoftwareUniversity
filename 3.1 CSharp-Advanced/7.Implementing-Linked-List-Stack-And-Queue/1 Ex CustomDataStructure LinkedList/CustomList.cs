using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Ex_CustomDataStructure_LinkedList
{
    public class CustomList
    {
        //Naming constant is with UPPER_LETTERS_WITH_UNDERSCORE
        private const int INITIAL_CAPACITY = 2;
        //private -  variable can be used only in this class

        //If we add readonly to an array - it will make it linked only to the first address we ctreated for it and we can't change
        //the link to be to other array with writing: items = new int[5], but we can do all other things we know with this array
        //private readonly int[] items;
        private int[] items;

        //When I order the methods should be better to have first all public then all private - not done, cause loosing the connections between the methods
        public CustomList()// public variable, method, property can be used in every class in the solution
        {
            this.items = new int[INITIAL_CAPACITY];     
        }

        public int Count { get; private set; }//private set means we can manipulate the count only in this class i.e. this.Count = 1;
        //get is not private and we can print for example from other classes

        //Indexation/indexer method returns that type of data which our array holds. In our case it is int:
        public int this[int index]//Indexation/indexer has no standart name but we write this[int index]. 
            //In this method we use [] brackets. Due to this method we can write list[0] = 5 i.e. we make indexation, without it we can't
        {
            get //this is a function which is int getIndex(int index)
            { 
                if(!this.IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set//this is a function which is void setIndex(int index)
            {
                if(!this.IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        private bool IsValidIndex(int index)//Helper function in this class, user can't see this method outside of the class
        {
            return index < this.Count;
        }
        //Second way to write the method above and it's shorter:
        //private bool IsValidIndex2(int index)//Helper function in this class, user can't see this method outside of the class
        //    => index < this.Count; //In this case => means returns

        private void Resize()//With this we resize the length of the array
        {
            int[] copy = new int[this.items.Length * 2];//we resize when this.items.Length == this.Count, so it doesn't metter which we use
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public void Add(int item)
        {
            if(this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(int);
            //Or all to be 0
            //for (int i = this.Count - 1; i < this.items.Length; i++)
            //{
            //    this.items[i] = default(int);
            //}
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public int RemoveAt(int index)
        {
            if (!IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            int removedItem = this.items[index];
            this.items[index] = default(int); //Gives 0 for int. It is good the value of this.items[index] to be 0.
            this.ShiftToLeft(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4)// if we devide to 2, for 9/2 we will lose 1 so we use /4! This is the ALGORITHM
            {
                Shrink();
            }

            return removedItem;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Insert(int index, int item)
        {
            if(!this.IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if(this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);

            this.items[index] = item;
            this.Count++;
        }

        public bool Contains(int searchedItem)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(this.items[i] == searchedItem)
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if(!(this.IsValidIndex(firstIndex) && this.IsValidIndex(secondIndex)))
            {
                throw new ArgumentOutOfRangeException();
            }

            //Additional variable - takes lots of memory
            int elementAtSecondIndex = this.items[secondIndex];
            this.items[secondIndex] = this.items[firstIndex];
            this.items[firstIndex] = elementAtSecondIndex;
            //Bitwise - see xor bitwise in the net - better for memory but difficult to understand
            //x = x ^ y
            //y = x ^ y
            //x = x ^ y
            //this.items[firstIndex] = this.items[firstIndex] ^ this.items[secondIndex];
            //this.items[secondIndex] = this.items[firstIndex] ^ this.items[secondIndex];
            //this.items[firstIndex] = this.items[firstIndex] ^ this.items[secondIndex];


        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                if(i == this.Count - 1)
                {
                    sb.Append(this.items[i]);
                }
                else
                {
                    sb.Append($"{this.items[i]}, ");
                }

            }

            return sb.ToString().TrimEnd();
        }
    }
}
