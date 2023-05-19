namespace QuestionApp.Models
{
    public class QuestionResponseHandler
    {
        public static QuestionResponse GetSuccessResponse(ResponseType responseType, object? data)
        {
            QuestionResponse response = new QuestionResponse() { ResponseData = data};
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

        public static QuestionResponse GetExceptionResponse(Exception ex)
        {
            QuestionResponse response = new QuestionResponse();
            response.Code = "500";
            response.ResponseData = ex.Message;
            return response;
        }
    }
}
