using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_11_Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        //The input will be within the constaints specified above and will always be valid. There is no need to check it explicitly.
        //There will never be a case where Sam breaks the lock and ends up with а negative balance.
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());//barrel = цев
            int[] bullets = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);
            int countBulletsFired = 0;
            while(bulletsStack.Count > 0 && locksQueue.Count > 0)
            {
                int currentBullet = bulletsStack.Peek();
                int currentLock = locksQueue.Peek();
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                    bulletsStack.Pop();
                    countBulletsFired++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                    countBulletsFired++;
                }

                if(countBulletsFired == gunBarrelSize)
                {
                    if(bulletsStack.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        countBulletsFired = 0;
                    }
                }
            }

            if(bulletsStack.Count == 0 && locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else if(bulletsStack.Count >= 0 && locksQueue.Count == 0)
            {
                int bulletsFired = bullets.Length - bulletsStack.Count;
                int bulletsFiredPrice = bulletPrice* bulletsFired;
                int moneyEarned = intelligence - bulletsFiredPrice;
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
