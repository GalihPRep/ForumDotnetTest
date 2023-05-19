namespace Project000.Models
{
        public class AccountResponse
        {
            public string Code
            {
                get;
                set;
            }
            public string Message
            {
                get;
                set;
            }
            public object? ResponseData
            {
                get;
                set;
            }
        }
        public enum ResponseType
        {
            Success,
            NotFound,
            Failure
        }
    }

