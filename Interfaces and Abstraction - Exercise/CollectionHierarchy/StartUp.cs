using System;
using System.Text;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            var sb = new StringBuilder();
            var firstLine = new StringBuilder();
            var secondLine = new StringBuilder();
            var thirdLine = new StringBuilder();

            foreach (var item in input)
            {
                firstLine.Append(addCollection.Add(item) + " ");
                secondLine.Append(addRemoveCollection.Add(item) + " ");
                thirdLine.Append(myList.Add(item) + " ");
            }

            sb.AppendLine(firstLine.ToString().TrimEnd());
            sb.AppendLine(secondLine.ToString().TrimEnd());
            sb.AppendLine(thirdLine.ToString().TrimEnd());

            firstLine.Clear();
            secondLine.Clear();
            thirdLine.Clear();

            for (int i = 0; i < n; i++)
            {
                firstLine.Append(addRemoveCollection.Remove()+" ");
                secondLine.Append(myList.Remove() + " ");
            }

            sb.AppendLine(firstLine.ToString().TrimEnd());
            sb.Append(secondLine.ToString().TrimEnd());

            Console.WriteLine(sb);
        }
    }
}
