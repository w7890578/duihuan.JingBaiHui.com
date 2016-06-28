using JingBaiHui.Exchange.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JingBaiHui.Exchange.Model;
using System.Collections.Generic;

namespace JingBaiHui.Exchange.Test
{


    /// <summary>
    ///这是 TenantBLLTest 的测试类，旨在
    ///包含所有 TenantBLLTest 单元测试
    ///</summary>
    [TestClass()]
    public class TenantBLLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Create 的测试
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值

            Tenant entity = new Tenant() { 
                Id=Guid.NewGuid(),
                TenantName="测试",
                TenantLoginPage="<a href='sdfsdf'></a>",
                CreateTime=DateTime.Now,
                CreateUserId=Guid.Empty
            }; // TODO: 初始化为适当的值
            target.Create(entity);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///Delete 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Guid Id = new Guid(); // TODO: 初始化为适当的值
            target.Delete(Id);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///Get 的测试
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Guid Id = new Guid(); // TODO: 初始化为适当的值
            Tenant expected = null; // TODO: 初始化为适当的值
            Tenant actual;
            actual = target.Get(Id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetEasyUiDataList 的测试
        ///</summary>
        [TestMethod()]
        public void GetEasyUiDataListTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Tenant entity = null; // TODO: 初始化为适当的值
            int pageIndex = 1; // TODO: 初始化为适当的值
            int pageSize = 15; // TODO: 初始化为适当的值
            string order = string.Empty; // TODO: 初始化为适当的值
            EasyUiDataGrid<Tenant> expected = null; // TODO: 初始化为适当的值
            EasyUiDataGrid<Tenant> actual;
            actual = target.GetEasyUiDataList(entity, pageIndex, pageSize, order);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetList 的测试
        ///</summary>
        [TestMethod()]
        public void GetListTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Tenant entity = null; // TODO: 初始化为适当的值
            IList<Tenant> expected = null; // TODO: 初始化为适当的值
            IList<Tenant> actual;
            actual = target.GetList(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetList 的测试
        ///</summary>
        [TestMethod()]
        public void GetListTest1()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Tenant entity = null; // TODO: 初始化为适当的值
            int pageIndex = 0; // TODO: 初始化为适当的值
            int pageSize = 0; // TODO: 初始化为适当的值
            string order = string.Empty; // TODO: 初始化为适当的值
            IList<Tenant> expected = null; // TODO: 初始化为适当的值
            IList<Tenant> actual;
            actual = target.GetList(entity, pageIndex, pageSize, order);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetRecordCount 的测试
        ///</summary>
        [TestMethod()]
        public void GetRecordCountTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Tenant entity = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetRecordCount(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Update 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            TenantBLL_Accessor target = new TenantBLL_Accessor(); // TODO: 初始化为适当的值
            Tenant entity = null; // TODO: 初始化为适当的值
            target.Update(entity);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        [TestMethod()]
        public void InstanceTest()
        {
            TenantBLL actual;
            actual = TenantBLL.Instance;
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
