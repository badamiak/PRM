using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using crm2.Extensions;
using crm2.Utils;
using System.Windows.Controls;
using crm2.Controls;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class ExtensionsTests : INotifyPropertyChanged
    {

        [TestMethod]
        [ExpectedException(typeof(PropertyChangedPassedException))]
        public void NotifyPropertyChangedSafeRiseTest()
        {
            PropertyChanged += new PropertyChangedEventHandler(PropertyChangedHandler);
            PropertyChanged.SafeRise(this, "test");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(object sender, EventArgs args)
        {
            throw new PropertyChangedPassedException();
        }

        [TestMethod]
        public void ObjectGetNameTest()
        {
            var testObject = new object();
            var testObjectName = HardType.GetName(() => testObject);
            Assert.AreEqual("testObject", testObjectName);
        }

        private void AddTab(TabControl tabControl, TabItem tab)
        {
            tabControl.Items.Add(tab);
        }
        [TestMethod]
        public void AddTabTest()
        {
            var tabControl = new TabControl();
            var tab = new TabItem();
            var tabHeader = new TabHeader();
            tab.Header = tabHeader;

            AddTab(tabControl, tab);

            Assert.IsTrue(tabControl.Items.Contains(tab));
        }
        [TestMethod]
        public void RemoveTabTest()
        {
            var tabControl = new TabControl();
            var tab = new TabItem();
            var tabHeader = new TabHeader();
            tab.Header = tabHeader;

            AddTab(tabControl, tab);
            tabControl.RemoveTabItem(tabHeader);

            Assert.IsTrue(!tabControl.Items.Contains(tab));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void InvalidObjectCastExtensionTest()
        {
            var preCast = new List<object>();
            preCast.Cast<TabControl>();
        }

        private static void MockEventHandlerAction(object sender, EventArgs args)
        {
            throw new MockEventHandlerException(sender, args);
        }
        public event EventHandler MockEvent;
        EventHandler mockEventHandler = new EventHandler(MockEventHandlerAction);


        [TestMethod]
        public void EventRaiseTest()
        {
            MockEvent += mockEventHandler;

            try
            {
                MockEvent.Raise(this, new EventArgs());
            }
            catch (MockEventHandlerException)
            {
                Assert.IsTrue(true);
            }
            finally
            {
                MockEvent -= mockEventHandler;
            }

        }
        [TestMethod]
        public void EventRaiseEmptyTest()
        {
            MockEvent += mockEventHandler;

            try
            {
                MockEvent.RaiseEmpty(this);
            }
            catch (MockEventHandlerException exc)
            {
                Assert.AreEqual(exc.args, EventArgs.Empty);
            }
            finally
            {
                MockEvent -= mockEventHandler;
            }
        }

        [TestMethod]
        public void NullEventRaiseTest()
        {
            Debug.WriteLine("MockEvent: " + MockEvent);
            try
            {
                MockEvent.Raise(this, EventArgs.Empty);
                MockEvent.RaiseEmpty(this);
                MockGenericEvent.Raise(this, new PropertyChangedEventArgs("mockPropoerty"));
            }
            catch (Exception e)
            {
                Assert.Fail("Exception was thrown on null event raise: " + e);
            }
            Assert.IsTrue(MockEvent == null);
            Assert.IsTrue(true);
        }

        private event EventHandler<PropertyChangedEventArgs> MockGenericEvent;
        [TestMethod]
        public void EventHandlerGenericRaiseTest()
        {
            MockGenericEvent += new EventHandler<PropertyChangedEventArgs>((o, a) => { throw new MockEventHandlerException(o, a); });
            try
            {
                MockGenericEvent.Raise(this, new PropertyChangedEventArgs("mockProperty"));
            }
            catch (MockEventHandlerException moex)
            {
                Assert.AreEqual((moex.args as PropertyChangedEventArgs).PropertyName,"mockProperty");
                Assert.AreEqual((moex.sender), this);
            }
            catch
            {
                Assert.Fail();
            }

        }
        object nullObject { get { return null; } }
        [TestMethod]
        public void IsObjectNullTest()
        {
            var testObject = new List<object>();
            
            Assert.IsFalse(testObject.IsNull());
            Assert.IsTrue(nullObject.IsNull());
        }

    }
}
