using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Responses
{
    public class ValueDataResponse<T> : DataResponse
    {
        public T Response { get; set; }

        public ValueDataResponse()
        {

        }

        public ValueDataResponse(T Response, bool IsSuccess = true, int AffectedRecords = 0, string EndUserMessage = "success", List<object> links = null, List<ValidationItem> ValidationErrors = null, Exception Exception = null)
        {
            this.Response = Response;
            this.IsSuccess = IsSuccess;
            this.AffectedRecords = AffectedRecords;
            this.EndUserMessage = EndUserMessage;
            this.links = links;
            this.ValidationErrors = ValidationErrors;
            this.Exception = Exception;


        }
    }
}
