using System;
using System.Collections.Generic;

namespace algorithm_practise
{
    public class BracketMatching
    {
        // lets define our brackets start and end
        private static readonly char[] _startBrackets = {'(', '[', '{'};
        private static readonly char[] _endBrackets = {')', ']', '}'};

        public static bool IsBalanced(string input)
        {
            // indices of the currently open brackets:
            Stack<int> bracketIndices = new Stack<int>();

            foreach (char chr in input)
            {
                int index;

                // check if the 'chr' is the start bracket, and get its index:
                if ((index = Array.IndexOf(_startBrackets, chr)) != -1)
                {
                    bracketIndices.Push(index); // add index to stack
                }
                // check if the 'chr' is a end bracket, and get its index:
                else if ((index = Array.IndexOf(_endBrackets, chr)) != -1)
                {
                    // return 'false' if the stack is empty or if the currently
                    // start bracket is not paired with the 'chr':
                    if (bracketIndices.Count == 0 || bracketIndices.Pop() != index)
                        return false;
                }
            }

            // return 'true' if there is no start bracket, and 'false' - otherwise:
            return bracketIndices.Count == 0;
        }
    }
}