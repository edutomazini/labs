using System.Collections.Generic;

namespace LlabsDomain
{
    public class Result
    {
        public IEnumerable<Employee> Employees { get; set; }
        public Settings Settings { get; set; }
    }
}
