using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PROG_POE_Jake_young_ST10081936
{

    //------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Enumeration Defining Colors
    /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
    /// </summary>
    enum ColorOptions
    {
        Red,
        Black
    }
    //------------------------------------------------------------------------------------------------------------------



    //------------------------------------------------------------------------------------------------------------------
    struct DeweyData
    {
        //the dewey call number as a string to preserve any data that is exluded when formatted as a number such as any prefixing 0's such as with 001 being read and displayed at 1
        public string deweyCallNumber;

        //the associated dewey decimal description
        public string deweyDescription;

        //the list level in the multi-level list
        public int listLevel;
    }
    //------------------------------------------------------------------------------------------------------------------



    internal class RedBlackTree
    {

        //------------------------------------------------------------------------------------------------------------------
        ///Class defining a Node - Be careful of defining a class within  Class!
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Object of type Node contains 5 properties
        /// Colour
        /// Left
        /// Right
        /// Parent
        /// DeweyData
        /// Data
        /// </summary>
        public class Node
        {
            public ColorOptions colour;
            public Node left;
            public Node right;
            public Node parent;
            public DeweyData entryData;
            public int data;

            
            public Node(int data, DeweyData entryData) { this.data = data; this.entryData = entryData; }
            public Node(ColorOptions colour) { this.colour = colour; }
            public Node(int data, DeweyData entryData, ColorOptions colour) { this.data = data; this.entryData = entryData; this.colour = colour; }
            
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to return the list path of the third level node
        /// </summary>
        /// <param name="existingThirdLevelNode"></param>
        /// <returns></returns>
        public List<Node> FindDeweyPath(Node existingThirdLevelNode)
        {
            //list to contain the node path in terms of first, second and third level
            List<Node> nodePath = new List<Node>();

            //collection of all first level nodes
            var firstLevelNodes = FindMatchingNodesLevel(1);

            //the first level node that matches the third level node given in the input
            var matchingFirstLevel = from found in firstLevelNodes where found.entryData.deweyCallNumber[0].ToString() == existingThirdLevelNode.entryData.deweyCallNumber[0].ToString() select found;

            //add the first level node to the path collection
            nodePath.Add(matchingFirstLevel.First());


            //collection of all second level nodes
            var secondLevelNodes = FindMatchingNodesLevel(2);

            //the second level node that matches the third level node given in the input
            var matchingSecondLevel = from found in secondLevelNodes where found.entryData.deweyCallNumber[0].ToString() == existingThirdLevelNode.entryData.deweyCallNumber[0].ToString() && found.entryData.deweyCallNumber[1].ToString() == existingThirdLevelNode.entryData.deweyCallNumber[1].ToString()  select found;

            //add the second level node to the path collection
            nodePath.Add(matchingSecondLevel.First());


            //add the third level node to the path collection
            nodePath.Add(existingThirdLevelNode);
            
            
            return nodePath;
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to return a list of nodes matching the level search criteria
        /// source - https://chat.openai.com/share/19c6bf9b-abfe-4505-9e7b-a6a290bfb6e5
        /// </summary>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        public List<Node> FindMatchingNodesLevel(int targetValue)
        {
            List<Node> matchingNodes = new List<Node>();
            FindMatchingNodesLevelRecursive(root, targetValue, matchingNodes);
            return matchingNodes;
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to add nodes that match the level search criteria to a list
        /// source - https://chat.openai.com/share/19c6bf9b-abfe-4505-9e7b-a6a290bfb6e5
        /// </summary>
        /// <param name="current"></param>
        /// <param name="targetValue"></param>
        /// <param name="matchingNodes"></param>
        private void FindMatchingNodesLevelRecursive(Node current, int targetValue, List<Node> matchingNodes)
        {
            if (current != null)
            {
                FindMatchingNodesLevelRecursive(current.left, targetValue, matchingNodes);

                // Check if the current node matches the criteria
                if (current.entryData.listLevel == targetValue)
                {
                    matchingNodes.Add(current);
                }

                FindMatchingNodesLevelRecursive(current.right, targetValue, matchingNodes);
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Root node of the tree (both reference & pointer)
        /// </summary>
        private Node root;
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        ///Constructor
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// New instance of a Red-Black tree object
        /// </summary>
        public RedBlackTree()
        {
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Left Rotate
        /// </summary>
        /// <param name="X"></param>
        /// <returns>void</returns>
        private void LeftRotate(Node X)
        {
            Node Y = X.right; // set Y
            X.right = Y.left;//turn Y's left subtree into X's right subtree
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent;//link X's parent to Y
            }
            if (X.parent == null)
            {
                root = Y;
            }
            if (X.parent != null)
            { 
            if (X == X.parent.left)
            {
                X.parent.left = Y;
            }
            else
            {
                X.parent.right = Y;
            }
            }
            Y.left = X; //put X on Y's left
            if (X != null)
            {
                X.parent = Y;
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Rotate Right
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>void</returns>
        private void RightRotate(Node Y)
        {
            // right rotate is simply mirror code from left rotate
            Node X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y.parent != null && Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y.parent != null && Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;//put Y on X's right
            if (Y != null)
            {
                Y.parent = X;
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Display Tree
        /// </summary>
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (root != null)
            {
                InOrderDisplay(root);
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Find item in the tree
        /// </summary>
        /// <param name="key"></param>
        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key < temp.data)
                {
                    temp = temp.left;
                }
                if (temp != null && key > temp.data)
                {
                    temp = temp.right;
                }
                if (temp != null && key == temp.data)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found", key);
                return null;
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Insert a new object into the RB Tree
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int item, DeweyData data)
        {
            Node newItem = new Node(item, data);
            if (root == null)
            {
                root = newItem;
                root.colour = ColorOptions.Black;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.data < X.data)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.data < Y.data)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = ColorOptions.Red;//colour the new node red
            InsertFixUp(newItem);//call method to check for violations and fix
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Display the tree data in the console
        /// </summary>
        /// <param name="current"></param>
        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.WriteLine("({0}) ", current.data);
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Evaluate tree after insert
        /// </summary>
        /// <param name="item"></param>
        private void InsertFixUp(Node item)
        {
            //Checks Red-Black Tree properties
            while (item != root && item.parent.colour == ColorOptions.Red)
            {
                /*We have a violation*/
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == ColorOptions.Red)//Case 1: uncle is red
                    {
                        item.parent.colour = ColorOptions.Black;
                        Y.colour = ColorOptions.Black;
                        item.parent.parent.colour = ColorOptions.Red;
                        item = item.parent.parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = ColorOptions.Black;
                        item.parent.parent.colour = ColorOptions.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    //mirror image of code above
                    Node X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.colour == ColorOptions.Black)//Case 1
                    {
                        item.parent.colour = ColorOptions.Red;
                        X.colour = ColorOptions.Red;
                        item.parent.parent.colour = ColorOptions.Black;
                        item = item.parent.parent;
                    }
                    else //Case 2
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = ColorOptions.Black;
                        item.parent.parent.colour = ColorOptions.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = ColorOptions.Black;//re-colour the root black as necessary
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Deletes a specified node from the tree
        /// </summary>
        /// <param name="item"></param>
        public void DeleteGivenNode(Node item)
        {
            
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.data = Y.data;
            }
            if (Y.colour == ColorOptions.Black)
            {
                DeleteFixUp(X);
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Deletes a specified value from the tree
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.data = Y.data;
            }
            if (Y.colour == ColorOptions.Black)
            {
                DeleteFixUp(X);
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// Checks the tree for any violations after deletion and performs a fix
        /// </summary>
        /// <param name="X"></param>
        private void DeleteFixUp(Node X)
        {

            while (X != null && X != root && X.colour == ColorOptions.Black)
            {
                if (X == X.parent.left)
                {
                    Node W = X.parent.right;
                    if (W.colour == ColorOptions.Red)
                    {
                        W.colour = ColorOptions.Black; //case 1
                        X.parent.colour = ColorOptions.Red; //case 1
                        LeftRotate(X.parent); //case 1
                        W = X.parent.right; //case 1
                    }
                    if (W.left.colour == ColorOptions.Black && W.right.colour == ColorOptions.Black)
                    {
                        W.colour = ColorOptions.Red; //case 2
                        X = X.parent; //case 2
                    }
                    else if (W.right.colour == ColorOptions.Black)
                    {
                        W.left.colour = ColorOptions.Black; //case 3
                        W.colour = ColorOptions.Red; //case 3
                        RightRotate(W); //case 3
                        W = X.parent.right; //case 3
                    }
                    W.colour = X.parent.colour; //case 4
                    X.parent.colour = ColorOptions.Black; //case 4
                    W.right.colour = ColorOptions.Black; //case 4
                    LeftRotate(X.parent); //case 4
                    X = root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    Node W = X.parent.left;
                    if (W.colour == ColorOptions.Red)
                    {
                        W.colour = ColorOptions.Black;
                        X.parent.colour = ColorOptions.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == ColorOptions.Black && W.left.colour == ColorOptions.Black)
                    {
                        W.colour = ColorOptions.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == ColorOptions.Black)
                    {
                        W.right.colour = ColorOptions.Black;
                        W.colour = ColorOptions.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = ColorOptions.Black;
                    W.left.colour = ColorOptions.Black;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = ColorOptions.Black;
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private Node Minimum(Node X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// source - https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private Node TreeSuccessor(Node X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }
        //------------------------------------------------------------------------------------------------------------------



    }

}
