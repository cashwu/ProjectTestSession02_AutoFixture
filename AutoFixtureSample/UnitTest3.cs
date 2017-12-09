using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;
using System.Linq;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 Person 物件
            // 已在 Person 類別的屬性加上 DataAnnotation Attribute
            // 驗證 AutoFixture 所建立的物件屬性值是否符合限制
            var fixture = new Fixture();

            var actual = fixture.Create<Person>();

            actual.Name.Length.Should().Be(10);
            actual.Age.Should().BeInRange(18, 80);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 Person 物件
            // 使用 CreateMany 方法，建立多個物件
            // 指定 Person 的 Age 在 30 ~ 50 之間

            // 驗證每個物件的 Age 都必須要在 30 ~ 50 之間
            var fixture = new Fixture();
            fixture.Customizations.Add
            (
                new RandomNumericSequenceGenerator(30, 50)
            );

            var actual = fixture.CreateMany<Person>();

            // 驗證每個物件的 Age 都必須要在 30 ~ 50 之間
            actual.Select(x => x.Age).ToList()
                  .ForEach(x => x.Should().BeInRange(30, 50));
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 Person 物件
            // Person 類別增加屬性 CreateTime (DateTime)
            // 使用 CreateMany 方法，建立多個物件
            // 指定 Person 的 Age 在 30 ~ 50 之間
            // 指定 CreateTime 在 2017-02-15 ~ 2017-12-01 之間

            // 驗證每個物件的 Age 都必須要在 30 ~ 50 之間
            // 驗證每個物件的 CreateTime 都必須要在 2017-02-15 ~ 2017-12-01 之間

            var minDate = new DateTime(2017, 2, 15);
            var maxDate = new DateTime(2017, 12, 1);

            var fixture = new Fixture();
            fixture.Customizations.Add
            (
                new RandomNumericSequenceGenerator(30, 50)
            );
            fixture.Customizations.Add
            (
                new RandomDateTimeSequenceGenerator(minDate, maxDate)
            );

            var actual = fixture.CreateMany<Person>();

            // 驗證每個物件的 Age 都必須要在 30 ~ 50 之間
            // 驗證每個物件的 CreateTime 都必須要在 2017-02-15 ~ 2017-12-01 之間

            actual.Select(x => x.Age).ToList().ForEach(x => x.Should().BeInRange(30, 50));
            actual.Select(x => x.Test).ToList().ForEach(x => x.Should().BeInRange(30, 50));
            var createTimes = actual.Select(x => x.CreateTime).ToList();
            createTimes.ForEach
            (
                x => x.Should().BeOnOrAfter(minDate)
                      .And
                      .BeOnOrBefore(maxDate)
            );
        }
    }
}