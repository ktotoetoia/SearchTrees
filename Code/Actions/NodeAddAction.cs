﻿namespace Trees.Actions
{
    public class NodeAddAction : INodeAction
    {
        protected INodeFactory _nodeFactory;
        protected INode _node;

        public NodeAddAction(INode node, INodeFactory nodeFactory)
        {
            _node = node;
            _nodeFactory = nodeFactory;
        }

        public INode DoAction(IComparable value)
        {
            if (_node.Value.CompareTo(value) >= 0)
            {
                return AddToLeftNode(value);
            }

            return AddToRightNode(value);
        }

        protected virtual INode AddToLeftNode(IComparable value)
        {
            if (_node.Left == null)
            {
                _node.Left = _nodeFactory.Create(value);
         
                return _node.Left;
            }

            return _node.Left.Add(value);
        }

        protected virtual INode AddToRightNode(IComparable value)
        {
            if (_node.Right == null)
            {
                _node.Right = _nodeFactory.Create(value);
                
                return _node.Right;
            }

            return _node.Right.Add(value);
        }
    }
}