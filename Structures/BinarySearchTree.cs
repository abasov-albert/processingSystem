using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Queues;

namespace Structures
{
    class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T t = default(T), BinaryTreeNode<T> l = null, BinaryTreeNode<T> r = null)
        {
            Data = t;
            Left = l;
            Right = r;
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }

    public class BinarySearchTree<T>: IQueueable<T>
            where T : IComparable<T>
    {
        public T Item()
        {
            // самый правый
            /*BinaryTreeNode<T> tmp = root;
            for (; tmp.Right != null; tmp = tmp.Right) ;
            return tmp.Data;*/
            // рекурсивно
            return Item(root);            
        }

        public void Put(T t)
        {
            /*if (root == null)
                root = new BinaryTreeNode<T>(t);
            else
            {
                BinaryTreeNode<T> tmp = root, parent = root;
                for (; tmp != null; parent = tmp, tmp = t.CompareTo(tmp.Data) <= 0 ? tmp.Left : tmp.Right);
                    if (t.CompareTo(parent.Data) <= 0)
                        parent.Left = new BinaryTreeNode<T>(t);
                    else
                        parent.Right = new BinaryTreeNode<T>(t);
            }*/
            // рекурсивно
            Put(ref root, t);
            count++;
        }
        public void Remove()
        {
            /*if (root.Right == null) // корень - самый правый
                root = root.Left;
            else
            {
                BinaryTreeNode<T> tmp = root, rightestParent = root;
                for (; tmp.Right != null; rightestParent = tmp, tmp = tmp.Right) ; // предок самого правого
                rightestParent.Right = tmp.Left;
            }*/
            // рекурсивно
            Remove(ref root);
            count--;
        }
        
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void Clear()
        {
            root = null;
            count = 0;
        } 
        
        public T[] ToArray()
        {
            T[] result = new T[Count];
            int nodeNum = 0;
            traverseRRtL(root, result, ref nodeNum);
            return result;
        }
        
        private BinaryTreeNode<T> root;
        private int count;
        
        private void traverseRRtL(BinaryTreeNode<T> btn, T[] res, ref int curr)
        {
            if (btn != null)
            {
                traverseRRtL(btn.Right, res, ref curr);
                res[curr++] = btn.Data;
                traverseRRtL(btn.Left, res, ref curr);
            }
        }

        [Pure]
        private T Item(BinaryTreeNode<T> btn)
        {
            /*if (btn.Right == null)
                return btn.Data;
            return Item(btn.Right);*/
            return btn.Right == null ? btn.Data : Item(btn.Right);
        }
        private void Put(ref BinaryTreeNode<T> btn, T t)
        {
            if (btn == null)
                btn = new BinaryTreeNode<T>(t);
            else
                if (t.CompareTo(btn.Data) <= 0)
                {
                    BinaryTreeNode<T> l = btn.Left;
                    Put(ref l, t);
                    btn.Left = l;
                }
                else
                {
                    BinaryTreeNode<T> r = btn.Right;
                    Put(ref r, t);
                    btn.Right = r;
                }
        }
        private void Remove(ref BinaryTreeNode<T> btn)
        {
            if (btn.Right == null)
                btn = btn.Left;
            else
            {
                BinaryTreeNode<T> r = btn.Right;
                Remove(ref r);
                btn.Right = r;
            }
        }
    }
}
