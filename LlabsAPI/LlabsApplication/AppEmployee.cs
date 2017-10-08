using LlabsDomain;
using LlabsRepository;
using System;
using System.Collections.Generic;
using X.PagedList;

namespace LlabsApplication
{
    public class AppEmployee
    {
        private RepositoryEmployee _RepositoryEmployee = null;
        public AppEmployee()
        {
            _RepositoryEmployee = new RepositoryEmployee();
        }

        public Result List(int PageNumber, int PageSize)
        {

            if (PageSize < 0 || PageNumber < 0)
                throw new Exception("PageSize and PageNumber must be > 0");

            List<Employee> Employees = new List<Employee>();
            Employees = _RepositoryEmployee.List();
            Employees.Sort(delegate (Employee x, Employee y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });

            PagedList<Employee> EmployeesPaged = new PagedList<Employee>(Employees, PageNumber, (PageSize != 0) ? PageSize : 1);

            Result Result = new Result()
            {
                Employees = EmployeesPaged,
                Settings = new Settings()
                {
                    HasNextPage = EmployeesPaged.HasNextPage,
                    HasPreviousPage = EmployeesPaged.HasPreviousPage,
                    IsFirstPage = EmployeesPaged.IsFirstPage,
                    IsLastPage = EmployeesPaged.IsLastPage,
                    PageCount = EmployeesPaged.PageCount,
                    PageNumber = EmployeesPaged.PageNumber,
                    PageSize = EmployeesPaged.PageSize,
                    TotalItemCount = EmployeesPaged.TotalItemCount
                }
            };
            return Result;
        }

        public int Insert(Employee value)
        {
            if (this.EmailExists(value.Email))
                throw new Exception("This email already exists!");
            else
                return _RepositoryEmployee.Insert(value);
        }

        public int Delete(int Id)
        {
            return _RepositoryEmployee.Delete(Id);
        }

        public bool EmailExists(string email)
        {
            List<Employee> Employees = new List<Employee>();
            Employees = _RepositoryEmployee.List();
            Employee employeefind = Employees.Find(employee => employee.Email == email);

            if (employeefind != null)
                return true;
            else
                return false;
        }
    }
}
