using System;
using TreeViewForString.Models;

namespace TreeViewForString
{
    class Program
    {
        private static TreeView treeView { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Tree view için string değer giriniz.");

            string treeString = Console.ReadLine();

            PrepareTreeView(treeString);

            int tabLevel = 0;
            treeView.RenderView(ref tabLevel);


            Console.ReadKey();

        }
        //abccbdeeda
        private static void PrepareTreeView(string value)
        {
            char[] chars = value.ToCharArray();

            string firstNodeName = chars[0].ToString();
            string childs = value.Remove(0, 1);
            childs = childs.Remove(childs.Length - 1);
            treeView = new TreeView(firstNodeName,childs);

            Console.WriteLine(treeView.subItems.Count);
        }
    }
}
