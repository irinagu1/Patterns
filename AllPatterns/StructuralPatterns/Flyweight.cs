using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    class GeneralTree
    {
        string name { get; init; }
        string color {  get; init; }
        public GeneralTree(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
    }

    class Tree
    {
        public GeneralTree GeneralTree { get; init; }
        public int X { get; set; }
        public int Y { get; set; }
        public Tree(GeneralTree generalTree, int x, int y)
        {
            GeneralTree = generalTree;
            X = x;
            Y = y;
        }
    }
    class FlyweightTreeFactory
    {
        private GeneralTree[] treeTypes;
        public FlyweightTreeFactory()
        {
            InitTypes();
        }
        public void Show()
        {
            var green1 = new Tree(treeTypes[0], 1, 1);
            var green2 = new Tree(treeTypes[0], 3, 4);
            Console.WriteLine($"First hash: {green1.GeneralTree.GetHashCode()}, " +
                $"second hash: {green2.GeneralTree.GetHashCode()}");
        }
        private void InitTypes()
        {
            treeTypes = new GeneralTree[2];
            treeTypes[0] = new GeneralTree("1", "green");
            treeTypes[1] = new GeneralTree("2", "blue");
        }
    }

   
}
