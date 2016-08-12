using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tree.NUnit
{
    [TestFixture]
    public class TreeTest
    {
        #region Data setup

        private class Dummy
        {
            public string Foo { get; set; }
        }

        private Tree<Dummy> _tree = new Tree<Dummy>();

        private long _root1Id;
        private Dummy _root1Data;

        private long _root2Id;
        private Dummy _root2Data;

        private long _child1Id;
        private Dummy _child1Data;

        private long _child2Id;
        private Dummy _child2Data;

        #endregion

        [SetUp]
        protected void SetUp()
        {
            _root1Id = 42;
            _root1Data = new Dummy { Foo = "root 1" };

            _root2Id = -1;
            _root2Data = new Dummy { Foo = "root 2" };

            _child1Id = 1;
            _child1Data = new Dummy { Foo = "child 1" };

            _child2Id = 2;
            _child2Data = new Dummy { Foo = "child 2" };

            _tree = new Tree<Dummy>();

            _tree.AddChild(null, _root1Id, _root1Data);
            _tree.AddChild(null, _root2Id, _root2Data);
            _tree.AddChild(_root1Id, _child1Id, _child1Data);
            _tree.AddChild(_root1Id, _child2Id, _child2Data);
        }

        [Test]
        public void InitializationCheck()
        {
            Assert.IsTrue(_tree.Data.Count == 4);
            Assert.IsTrue(_tree.Links.Count == 4);
        }

        [Test]
        public void RootsDefined()
        {
            Assert.IsNotNull(_tree.Roots);
            Assert.IsTrue(_tree.Roots.Count == 2);
            Assert.IsTrue(_tree.Roots[0] == _root1Id);
        }

        [Test]
        public void LeavesDefined()
        {
            Assert.IsNotNull(_tree.Leaves);
            Assert.IsTrue(_tree.Leaves.Count == 3);
            Assert.IsTrue(_tree.Leaves[1] == _child1Id);
            Assert.IsTrue(_tree.Leaves[2] == _child2Id);
        }

        [Test]
        public void CanNavigateById()
        {
            Assert.IsTrue(_tree[_root1Id].Data == _root1Data);
            Assert.IsTrue(_tree[_child1Id].Data == _child1Data);
            Assert.IsTrue(_tree[_child2Id].Data == _child2Data);
        }

        [Test]
        public void NextAreSets()
        {
            Assert.IsTrue(_tree[_child2Id].Link.Next == _child1Id);
        }

        [Test]
        public void ChildrenAreSets()
        {
            Assert.IsFalse(_tree[_root1Id].Link.Child == _child1Id);
            Assert.IsTrue(_tree[_root1Id].Link.Child == _child2Id);
        }

        [Test]
        public void DepthDefined()
        {
            Assert.IsTrue(_tree[_root1Id].Link.Depth == 0);
            Assert.IsTrue(_tree[_child1Id].Link.Depth == 1);
            Assert.IsTrue(_tree[_child2Id].Link.Depth == 1);
        }

        [Test]
        public void ContainsId()
        {
            Assert.IsTrue(_tree.Contains(_root1Id));
        }

        [Test]
        public void NodeAlreadyExistsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _tree.AddChild(null, _root1Id, _root1Data);
            });
        }

        [Test]
        public void EnumeratorReachable()
        {
            Assert.IsTrue(_tree.Cast<NodeLink>().Count() == 4);
        }

        [Test]
        public void ParentNotFoundArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _tree.AddChild(99999999, 42, new Dummy());
            });
        }
    }
}
