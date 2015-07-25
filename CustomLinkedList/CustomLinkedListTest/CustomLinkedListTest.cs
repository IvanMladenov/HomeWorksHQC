using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedListTest
{
    using CustomLinkedList;

    [TestClass]
    public class CustomLinkedListTest
    {
        [TestMethod]
        public void TestValidCountOnNewListCreation()
        {
            DynamicList<int> list = new DynamicList<int>();
            int initialCount = list.Count;
            Assert.AreEqual(0, initialCount, "A newly created list should have a count of 0.");
        }

        [TestMethod]
        public void TestCountAfterAddSomeElements()
        {
            DynamicList<int> list = new DynamicList<int>();
            int expetedCount = 3;

            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            int listCount = list.Count;

            Assert.AreEqual(expetedCount, listCount, "List wiht 3 elements must have count of 3.");
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentOutOfRangeException))]
        public void TestTryingToGetAnElementOnNegativeIndex()
        {
            DynamicList<int> list = new DynamicList<int>();

            int numberOnNegativePosition = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTryingToGetAnElementOnPositionBiggerThanCount()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);

            int numberOnNegativePosition = list[1];
        }

        [TestMethod]
        public void GetElementOnValidPosition()
        {
            DynamicList<int> list = new DynamicList<int>();
            int numberToAdd = 5;
 
            list.Add(numberToAdd);
            int getElement = list[0];
            
            Assert.AreEqual(numberToAdd, getElement, "Added and taken element must be equal.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTryingToSetElementOnNegativeIndex()
        {
            DynamicList<int> list = new DynamicList<int>();

            list[-1] = 3;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTryingToSetElementOnPositionBiggerThanCount()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list[1] = 3;
        }

        [TestMethod]
        public void TestSetElementOnValidPosition()
        {
            DynamicList<int> list = new DynamicList<int>();
            int numberToAdd = 5;
            int numberToChange = 3;

            list.Add(numberToAdd);
            list[0] = numberToChange;
            int changedNumber = list[0];

            Assert.AreEqual(numberToChange, changedNumber, "Changed element and element on position must be equal.");
        }

        [TestMethod]
        public void TestRemovingElementAtValidPosition()
        {
            DynamicList<string>list=new DynamicList<string>();
            list.Add("first");
            list.Add("second");

            list.RemoveAt(0);
            string elementOnZeroPosition = list[0];

            Assert.AreEqual("second", elementOnZeroPosition, "After removing at 0 element on position 1 must be set at 0.");
        }

        [TestMethod]
        public void TestCountAfterRemovingElementAtValidPosition()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.Add("second");

            list.RemoveAt(0);
            int count = list.Count;

            Assert.AreEqual(1, count, "After removing element the count must be 1 less");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementFromEmptyList()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementOnNegativeIndex()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementOnIndexBiggerThanCount()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.RemoveAt(1);
        }

        //Start testing Remove method
        [TestMethod]
        public void TestRemoveUnexistingElement()
        {
            DynamicList<string> list=new DynamicList<string>();
            list.Add("first");
            list.Add("second");

            int returnResult = list.Remove("third");

            Assert.AreEqual(-1, returnResult,"If element not exist the method must return -1");
        }

        [TestMethod]
        public void TestRemoveExistingElement()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.Add("second");

            int returnResult = list.Remove("first");

            Assert.AreEqual(0, returnResult,
                "If element is sucsessfully removed, the method should return index of the element");
        }

        [TestMethod]
        public void TestListMembersAfterRemoveExistingElement()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");

            list.Remove("second");
            string first = list[0];
            string second = list[1];

            Assert.AreEqual("first", first, "The first element in the list should be the first one entered");
            Assert.AreEqual("third", second , "The second element should be the third entered");
        }

        [TestMethod]
        public void TestCountAfterRemoveExistingElement()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            int countBeforeRemoving = list.Count;

            list.Remove("second");
            int countAfterRemoving = list.Count;

            Assert.AreEqual(countAfterRemoving+1, countBeforeRemoving, "Count after removing must be less by 1.");
        }

        [TestMethod]
        public void TestCountAfterRemoveUnexistingElement()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            int countBeforeRemoving = list.Count;

            list.Remove("Pesho");
            int countAfterRemoving = list.Count;

            Assert.AreEqual(
                countAfterRemoving,
                countBeforeRemoving,
                "Count when removing unexisting element should be unchanged.");
        }

        //Start testing IndexOf method
        [TestMethod]
        public void TestIndexOfNonExistingElement()
        {
            DynamicList<string>list=new DynamicList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");

            int index = list.IndexOf("five");

            Assert.AreEqual(-1, index, "If try to get index of non existing element the method should return -1");
        }

        [TestMethod]
        public void TestIndexOfExistingElement()
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");

            int index = list.IndexOf("third");

            Assert.AreEqual(2, index, "If try to get index of existing element the method should return its index");
        }

        //Start testing Contains method
        [TestMethod]
        public void TestContainsWithNonExistingElement()
        {
            
            DynamicList<int>list=new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool result = list.Contains(5);

            Assert.AreEqual(false,result,"If list not contains element should return false");
        }

        [TestMethod]
        public void TestContainsWithExistingElement()
        {

            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool result = list.Contains(3);

            Assert.AreEqual(true, result, "If list contains element should return true");
        }
    }
}
