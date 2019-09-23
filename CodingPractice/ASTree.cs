using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPrograms
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public bool visited = false;
        public Node(int value)
        {
            data = value;
        }
    }
    public class BinaryTree
    {

        public Node Insert(Node root, int v)
        {
            if (root == null)
            {
                return new Node(v);
            }

            if (root.data > v)
            {
                root.left = Insert(root.left, v);
            }
            else
            {
                root.right = Insert(root.right, v);
            }
            return root;
        }
        public Node Search(Node root, int v)
        {
            if (root == null || root.data == v)
            {
                return root;
            }
            if (root.data > v)
            {
                return Search(root.left, v);
            }

            return Search(root.right, v); ;
        }
        public Node Delete(Node root, int v)
        {
            return null;
        }
        public Boolean isBalanced(Node root)
        {
            return true;
        }
        public Node InOrderTraversal(Node root)
        {
            return null;
        }
        private Node Balance(Node root)
        {
            return root;
        }
        public bool isExist(Node root, int v)
        {
            return false;
        }

        public int Hieght(Node root)
        {
            return 0;
        }
    }

}
