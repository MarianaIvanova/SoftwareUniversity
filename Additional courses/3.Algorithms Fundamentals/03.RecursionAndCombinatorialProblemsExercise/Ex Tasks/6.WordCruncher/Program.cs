using System;
using System.Collections.Generic;

namespace _6.WordCruncher
{
    class Program
    {
        //Идеята е за всеки индекс да намерим кои са възможните думички, които можем да постаним на него!
        private static string searchedWord;
        private static Dictionary<int, List<string>> wordsByIndex;//На кой индекс, кои думи могат да се пазят
        private static Dictionary<string, int> wordsCount;//Тук ще запишем думата колко пъти се среща в списъка, те калко пъти можем да я ползваме
        //Можем да ползваме List, но е по-бавен, затова използваме:
        private static LinkedList<string> usedWords;
        static void Main(string[] args)
        {
            var allWords = Console.ReadLine().Split(", ");
            searchedWord = Console.ReadLine();

            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (var word in allWords)
            {
                var index = searchedWord.IndexOf(word);//Дали текущата дума се съдържа в търсената дума

                if(index == -1)//Ако не се съдържа - връща -1
                {
                    continue;
                }

                if(wordsCount.ContainsKey(word))
                {
                    wordsCount[word] += 1;
                    continue;
                }

                //Тук заради continue-то от предишния if е ясно, че думата се среща само един път, ако е продължил кода до тук:
                wordsCount[word] = 1;

                while(index != -1)
                {
                    if(!wordsByIndex.ContainsKey(index))
                    {
                        wordsByIndex[index] = new List<string>();
                    }

                    wordsByIndex[index].Add(word);

                    index = searchedWord.IndexOf(word, index + 1); //index = searchedWord.IndexOf(word, index + word.Length);

                }
            }

            GenSolutions(0);
        }

        private static void GenSolutions(int index)
        {
            //Base - дали сме излезли извън думата
            if(index == searchedWord.Length)//Излизаме извън думата надясно, нали се движим все надясно...
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            //Имаме ли думичка, която да можем да сложим на текущия индекс
            if(!wordsByIndex.ContainsKey(index))
            {
                return;
            }
            
            //За всички думи, които имаш на този индекс
            foreach (var word in wordsByIndex[index])
            {
                if(wordsCount[word] == 0)//виж тая дума можеш ли да я ползваш
                {
                    continue;
                }

                //Това е някаква форма на backtracking
                wordsCount[word] -= 1;//Намаляме броя на пътите, в които можем да ползваме думата
                usedWords.AddLast(word);//Добавяме думата накрая

                GenSolutions(index + word.Length);

                wordsCount[word] += 1;//Увеличаваме броя на пътите, в които можем да ползваме думата
                usedWords.RemoveLast();//Махаме думата накрая, ако списъка не е довел до решение.
            }
        }
    }
}
