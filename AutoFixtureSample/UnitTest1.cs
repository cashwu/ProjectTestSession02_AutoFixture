using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Linq;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 String
            var fixture = new Fixture();
            var actual = fixture.Create<string>();
            actual.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 String
            // 設定 Inject 給予預設值
            var fixture = new Fixture();
            fixture.Inject("cash");

            var actual = fixture.Create<string>();
            actual.Should().NotBeNullOrEmpty();
            actual.Should().StartWith("cash");
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 String
            // 使用 Create 方法並給予 Seed 參數
            var fixture = new Fixture();
            var seed = "cash";
            var actual = fixture.Create<string>(seed);
            actual.Should().NotBeNullOrEmpty();
            actual.Should().StartWith("cash");
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 使用 AutoFixture 建立 String Collection
            var fixture = new Fixture();

            var actual = fixture.CreateMany<string>();
            actual.Count().Should().BeGreaterThan(1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 Inject 給予預設值

            var fixture = new Fixture();

            var actual = fixture.CreateMany<string>(10);
            actual.Count().Should().Be(10);
        }

        [TestMethod]
        public void TestMethod6()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 CreateMany 方法並給予 Seed
            var fixture = new Fixture();
            fixture.Inject("cash");

            var actual = fixture.CreateMany<string>();

            actual.Any().Should().BeTrue();
            actual.All(x => x.StartsWith("cash")).Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod7()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 CreateMany 方法並給予 Count 參數，讓 Collection 裡有 10 個 String

            var fixture = new Fixture();

            var actual = fixture.CreateMany<string>(10);

            actual.Count().Should().Be(10);
        }

        [TestMethod]
        public void TestMethod8()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 AddManyTo 方法
            var collection = new List<string>();

            var fixture = new Fixture();
            fixture.AddManyTo(collection);

            collection.Any().Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod9()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 AddManyTo 方法，使用 repeatCount 參數，讓 Collection 裡有 10 個 String
            var collection = new List<string>();

            var fixture = new Fixture();
            fixture.AddManyTo(collection, 10);

            collection.Count.Should().Be(10);
        }
    }
}