using System.Collections.Generic;

namespace CustomModelStateReturn.Controllers.Responses
{
    public class ResponseBase
    {
        public bool Succeeded { get; set; }
        public IEnumerable<ResponseError> Errors { get; set; }
    }
}
