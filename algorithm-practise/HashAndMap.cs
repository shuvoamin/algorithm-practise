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

        public static int[] IceCreamParlorLogN(int totalMoney, int[] icecreamPrices)
        {
            var boughtIcreamIndexes = new int[2];
            var lookup = new Dictionary<int, int>();

            for (var i = 0; i < icecreamPrices.Length; i++)
            {
                if (icecreamPrices[i] < totalMoney)
                {
                    var otherIceCreamPrice = totalMoney - icecreamPrices[i];
                    if (lookup.ContainsKey(otherIceCreamPrice))
                    {
                        //solution found
                        var indexOfOtherIcecream = lookup[otherIceCreamPrice];
                        if (indexOfOtherIcecream < i)
                        {
                            boughtIcreamIndexes[0] = indexOfOtherIcecream + 1;
                            boughtIcreamIndexes[1] = i + 1;
                        }
                        else
                        {
                            boughtIcreamIndexes[0] = i + 1;
                            boughtIcreamIndexes[1] = indexOfOtherIcecream + 1;
                        }
                        break;
                    }
                    else
                    {
                        if (!lookup.ContainsKey(icecreamPrices[i]))
                            lookup.Add(icecreamPrices[i], i);
                    }
                }
            }

            return boughtIcreamIndexes;
        }
    }
}