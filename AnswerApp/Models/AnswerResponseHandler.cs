using AnswerApp.Models;

namespace AnswerApp.Models
{
    public class AnswerResponseHandler
    {
        public static AnswerResponse GetSuccessResponse(ResponseType responseType, object? data)
        {
            AnswerResponse response = new AnswerResponse() { ResponseData = data};
            switch (responseType)
            {
                case ResponseType.Success:
                    response.Code = "200";
                    response.Message = "Success";
                    break;
                case ResponseType.NotFound:
                    response.Code = "404";
                    response.Message = "Not found";
                    break;
            }
            return response;
        }

        public static AnswerResponse GetExceptionResponse(Exception ex)
        {
            AnswerResponse response = new AnswerResponse();
            response.Code = "505";
            response.ResponseData = ex.Message;
            return response;
        }
    }
}
