using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tree.Tests
{
    [TestClass]
    public class TreeTest
    {
        #region Data setup

        private class Dummy
        {
            public string Foo { get; set; }
        }

        private Tree<Dummy> _tree = new Tree<Dummy>();

        private long _rootId;
        private Dummy _rootData;

        private long _child1Id;
        private Dummy _child1Data;

        private long _child2Id;
        private Dummy _child2Data;

        #endregion

        [TestInitialize]
        public void Initialize()
        {
            _rootId = 42;
            _rootData = new Dummy {Foo = "root"};

            _child1Id = 1;
            _child1Data = new Dummy { Foo = "child 1" };

            _child2Id = 2;
            _child2Data = new Dummy { Foo = "child 2" };

            _tree = new Tree<Dummy>();

            _tree.AddChild(null, _rootId, _rootData);
            _tree.AddChild(_rootId, _child1Id, _child1Data);
            _tree.AddChild(_rootId, _child2Id, _child2Data);
        }

        [TestMethod]
        public void RootsDefined()
        {
            Assert.IsNotNull(_tree.Roots);
            Assert.IsTrue(_tree.Roots.Count == 1);
            Assert.IsTrue(_tree.Roots[0] == _rootId);
        }

        [TestMethod]
        public void LeavesDefined()
        {
            Assert.IsNotNull(_tree.Leaves);
            Assert.IsTrue(_tree.Leaves.Count == 2);
            Assert.IsTrue(_tree.Leaves[0] == _child1Id);
            Assert.IsTrue(_tree.Leaves[1] == _child2Id);
        }

        [TestMethod]
        public void CanNavigateById()
        {
            Assert.IsTrue(_tree[_rootId].Data == _rootData);
            Assert.IsTrue(_tree[_child1Id].Data == _child1Data);
            Assert.IsTrue(_tree[_child2Id].Data == _child2Data);
        }

        [TestMethod]
        public void NextAreSets()
        {
            Assert.IsTrue(_tree[_child2Id].Link.Next == _child1Id);
        }

        [TestMethod]
        public void ChildrenAreSets()
        {
            Assert.IsFalse(_tree[_rootId].Link.Child == _child1Id);
            Assert.IsTrue(_tree[_rootId].Link.Child == _child2Id);
        }
        [TestMethod]
        public void DepthDefined()
        {
            Assert.IsTrue(_tree[_rootId].Link.Depth == 0);
            Assert.IsTrue(_tree[_child1Id].Link.Depth == 1);
            Assert.IsTrue(_tree[_child2Id].Link.Depth == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CtorCapacityOutOfRangeException()
        {
            var tree = new Tree<int>(-42);
        }
    }
}
