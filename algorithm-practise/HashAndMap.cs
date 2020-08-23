using System.Collections.Generic;
using System.Linq;

namespace algorithm_practise
{
    public class HashAndMap
    {
        public static int[] IceCreamParlorOn2(int m, int[] arr) {

            var indices = new List<int>();

            for(var i = 0; i < arr.Length; i++)
            {
                for(var j = 1; j < arr.Length -1 ; j++)
                {
                    if (arr[i] + arr[j] == m)
                    {
                        indices.Add(i);
                        indices.Add(j);

                        return indices.OrderBy(x => x).ToArray();
                    }
                }
            }

            return indices.OrderBy(x => x).ToArray();

        }
    }
}