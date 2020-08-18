using System;
using System.Collections;

namespace algorithm_practise
{
    public class Queue  
    {
        private readonly Stack _s1 = new Stack();
        private readonly Stack _s2 = new Stack();  
  
        public void EnQueue(int x)  
        {  
            // Move all elements from _s1 to _s2  
            while (_s1.Count > 0)  
            {  
                _s2.Push(_s1.Pop());  
                //_s1.Pop();  
            }  
  
            // Push item into _s1  
            _s1.Push(x);  
  
            // Push everything back to _s1  
            while (_s2.Count > 0)  
            {  
                _s1.Push(_s2.Pop());  
                //s2.Pop();  
            }  
        }  
  
        // Dequeue an item from the queue  
        public int DeQueue()  
        {  
            // if first stack is empty  
            if (_s1.Count == 0)  
            {  
                Console.WriteLine("Q is Empty");  
            }  
  
            // Return top of _s1  
            int x = (int)_s1.Peek();  
            _s1.Pop();
            
            return x;  
        }  
        
        public int? Peek() {
            if (Size() == 0) {
                return null;
            }
            if (_s2.Count == 0) {
                ShiftStacks();
            }
            return (int)_s2.Peek();
        }
        
        /* Only shifts stacks if necessary */
        private void ShiftStacks() 
        {
            if (_s2.Count == 0) { // shifting items while stack2 contains items would mess up our queue's ordering
                while (_s1.Count != 0) {
                    _s2.Push(_s1.Pop());
                }
            }
        }

        private int Size() {
            return _s1.Count + _s2.Count;
        }
    };  
}