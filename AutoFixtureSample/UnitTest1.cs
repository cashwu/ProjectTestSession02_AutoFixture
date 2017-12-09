using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 String
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 String
            // 設定 Inject 給予預設值
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 String
            // 使用 Create 方法並給予 Seed 參數
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 使用 AutoFixture 建立 String Collection
        }

        [TestMethod]
        public void TestMethod5()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 Inject 給予預設值
        }

        [TestMethod]
        public void TestMethod6()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 CreateMany 方法並給予 Seed
        }

        [TestMethod]
        public void TestMethod7()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 CreateMany 方法並給予 Count 參數，讓 Collection 裡有 10 個 String
        }

        [TestMethod]
        public void TestMethod8()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 AddManyTo 方法
        }

        [TestMethod]
        public void TestMethod9()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 AddManyTo 方法，使用 repeatCount 參數，讓 Collection 裡有 10 個 String
        }
    }
}