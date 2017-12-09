using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 Person 物件
            // 使用 CreateMany 方法，建立多個物件
            // 指定 Person 的 Age 在 30 ~ 50 之間


            // 驗證每個物件的 Age 都必須要在 30 ~ 50 之間
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
        }
    }
}