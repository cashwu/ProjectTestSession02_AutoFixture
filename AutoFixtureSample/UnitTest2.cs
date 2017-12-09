using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System.Linq;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            var fixture = new Fixture();
            var actual = fixture.Create<MyClass>();
            actual.Should().NotBeNull();
            actual.Should().BeOfType<MyClass>();
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 設定 Inject 給予預設值
            // 使用 Create 方法

            var fixture = new Fixture();
            fixture.Inject("cash");

            var actual = fixture.Create<MyClass>();

            actual.Name.Should().StartWith("cash");
            actual.Orders.Select(x => x.Name).All(x => x.StartsWith("cash")).Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Build 方法以及 OmitAutoProperties
            var expected = new MyClass();

            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                .OmitAutoProperties()
                                .Create();

            actual.Should().NotBeNull();
            expected.ToExpectedObject().ShouldEqual(actual);

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Build 方法以及 Without 和 With
            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                .With(x => x.Name, "cash")
                                .Without(x => x.Age)
                                .Create();

            actual.Name.Should().Be("cash");
            actual.Age.Should().Be(0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 CreateMany 方法，讓物件集合裡有 5 個物件
            var fixture = new Fixture();

            var actual = fixture.CreateMany<MyClass>(5);

            actual.Count().Should().Be(5);
        }

        [TestMethod]
        public void TestMethod6()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 With 方法，讓物件的屬性 Orders 有 3 個 order 物件
            var fixture = new Fixture();

            //var orders = fixture.CreateMany<Order>(3);

            //var actual = fixture.Build<MyClass>()
            //                    .With(x => x.Orders, orders.ToList())
            //                    .Create();

            var actual = fixture.Build<MyClass>()
                                .With(x => x.Orders, fixture.CreateMany<Order>(3).ToList())
                                .Create();

            actual.Orders.Any().Should().BeTrue();
            actual.Orders.Count.Should().Be(3);
        }

        [TestMethod]
        public void TestMethod7()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Do 方法，讓物件的屬性 Orders 有 3 個 Order 物件
            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                .Do(x => x.Orders.AddRange(fixture.CreateMany<Order>(3)))
                                .Create();

            actual.Orders.Any().Should().BeTrue();
            actual.Orders.Count.Should().Be(3);
        }
    }
}