using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Responses
{
    public class MultipleDataResponse<T>
    {
        public MultipleResult<T> Response { get; set; }
        public bool IsSuccess { get; set; }
        public string EndUserMessage { get; set; }
        public List<object> links { get; set; }
        public List<ValidationItem> ValidationErrors { get; set; }
        public Exception Exception { get; set; }

        public MultipleDataResponse()
        {
            ValidationErrors = new List<ValidationItem>();
            Response = new MultipleResult<T>();
        }

    }
    public class MultipleResult<T>
    {
        public IEnumerable<T> ListResult { get; set; }
        public long Count { get; set; }
        public int AffectedRecords { get; set; }
    }
}

