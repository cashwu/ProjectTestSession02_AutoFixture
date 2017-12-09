using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 設定 Inject 給予預設值
            // 使用 Create 方法
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Build 方法以及 OmitAutoProperties
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Build 方法以及 Without 和 With
        }

        [TestMethod]
        public void TestMethod5()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 CreateMany 方法，讓物件集合裡有 5 個物件
        }

        [TestMethod]
        public void TestMethod6()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 With 方法，讓物件的屬性 Orders 有 3 個 order 物件
        }

        [TestMethod]
        public void TestMethod7()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Do 方法，讓物件的屬性 Orders 有 3 個 Order 物件
        }
    }
}