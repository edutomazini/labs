using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LlabsDomain;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class InsertEmployee
    {
        [TestMethod]
        //para rodar os testes comente a linha 15 da classe RepositoryEmployee
        public void Insert()
        {
            int id = 0;
            Employee Emp = new Employee() { Name = "edu", Email = "edu@nada.com", Department = "depart" };

            //insert
            LlabsApplication.AppEmployee EmpInsert = new LlabsApplication.AppEmployee();
            id = EmpInsert.Insert(Emp);

            EmpInsert.Delete(id);
        }

        [TestMethod]
        public void Delete()
        {
            LlabsApplication.AppEmployee EmpDelete = new LlabsApplication.AppEmployee();

            EmpDelete.Delete(0);
        }

        [TestMethod]
        public void List()
        {
            int pagenumber = 1;
            int pagesize = 10;
            Result rEmployee = new Result();
            List<Employee> lstEmployee = new List<Employee>();
            LlabsApplication.AppEmployee EmpList = new LlabsApplication.AppEmployee();
            rEmployee = EmpList.List(pagenumber,pagesize);

            if (rEmployee.Settings.PageNumber != pagenumber || rEmployee.Settings.PageSize != pagesize)
                Assert.Fail("contagem de itens diferente");

        }
    }
}
