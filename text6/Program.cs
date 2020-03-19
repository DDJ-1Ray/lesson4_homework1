using System;

namespace text6
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            head = tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
                head = tail = n;
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void Print()
        {
            if (head == null)
                Console.WriteLine("空表");
            else
            {
                Console.WriteLine("表中元素有:");
                Node<T> node = head;
                while (node != null)
                {
                    Console.WriteLine(node.Data);
                    node = node.Next;
                }
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> node = head;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue, min = int.MaxValue, sum = 0;
            
            GenericList<int> intlist = new GenericList<int>();
            for(int n = 0; n < 10; n++)
            {
                intlist.Add(n);
            }
            Action action=intlist.Print;
            
            intlist.ForEach(m =>
            {
                if (max < m)
                    max = m;
            });
            Console.WriteLine("最大值是{0}", max);
            
            intlist.ForEach(m =>
            {
                if (min > m)
                    min = m;
            });
            Console.WriteLine("最小值是{0}", min);
            intlist.ForEach(m => { sum += m; });
            Console.WriteLine("總和是{0}", sum);



        }
    }
}
