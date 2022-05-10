namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public BalancedParenthesesSolve()
        {
                
        }
        public bool AreBalanced(string parentheses)
        {
            bool isSolvable = false;

            Stack<char> leftparentheses = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                var current = parentheses[i];

                if(current == '{' || current == '[' || current == '(')
                {
                    leftparentheses.Push(current);
                }
                else
                {
                    if(current == '}')
                    {
                        if(leftparentheses.Count != 0 && leftparentheses.Peek() == '{')
                        {
                            leftparentheses.Pop();
                        }
                        else
                        {
                            return isSolvable;
                        }                      
                    }
                    else if (current == ']')
                    {
                        if (leftparentheses.Count != 0 && leftparentheses.Peek() == '[')
                        {
                            leftparentheses.Pop();
                        }
                        else
                        {
                            return isSolvable;
                        }
                    }
                    else if (current == ')')
                    {
                        if (leftparentheses.Count != 0 && leftparentheses.Peek() == '(')
                        {
                            leftparentheses.Pop();
                        }
                        else
                        {
                            return isSolvable;
                        }
                    }
                }
            }

            if (leftparentheses.Count == 0)
            {
                isSolvable = true;
            }

            return isSolvable;
        }
    }
}
