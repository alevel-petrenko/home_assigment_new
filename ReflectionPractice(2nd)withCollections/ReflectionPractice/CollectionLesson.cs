using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ReflectionPractice
{
    class CollectionLesson
    {
        public void ArrExample()
        {
            ArrayList arrList = new ArrayList();
            Console.WriteLine(arrList.Capacity);
            arrList.Add('*');
            arrList.AddRange(new object[] { "Hello", 123, '+'});
            //arrList.Sort();

            arrList.Insert(2, true);

            Console.WriteLine(arrList.Count);
            Console.WriteLine(arrList.Capacity);

            ArrayList arrList2 = arrList.GetRange(2, 2);

            foreach (var item in arrList)
            {
                Console.WriteLine(item);
            }

            //////////////

            SortedList list = new SortedList();
            list.Add(2, "hello");

            //////////////

            Stack stack = new Stack();
            // LIFO
            stack.Push(1);
            stack.Push(2);

            stack.Peek();
            stack.Pop();

            //////////////

            Queue queue = new Queue();
            // FIFO
            queue.Enqueue("A");
            queue.TrimToSize();

            //////////////
            ///

            //////////////

            Action a = new Action(() =>
            {
               List<int> listInt = new List<int>();
               listInt.AddRange(new int[] { 5, 6, 8, 9 });

               foreach (var item in listInt)
               {
                   Console.WriteLine(item);
               }

                listInt.ForEach(item => Console.WriteLine(item));
               // the same as usuall foreach
               var list2 = listInt.Where(x => x < 10).Select(x => x * 5).ToArray();
            });
        }
    }
}
