namespace Project000.Models
{
    public class AccountResponseHandler
    {
        public static AccountResponse GetSuccessResponse(ResponseType responseType, object? data)
        {
            AccountResponse response = new AccountResponse() { ResponseData = data};
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

        public static AccountResponse GetExceptionResponse(Exception ex)
        {
            AccountResponse response = new AccountResponse();
            response.Code = "500";
            response.ResponseData = ex.Message;
            return response;
        }
    }
}
