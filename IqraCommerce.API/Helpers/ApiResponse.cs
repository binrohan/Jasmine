namespace IqraCommerce.API.Helpers
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, object data = null, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Data = data;
            IsError = DetectError(statusCode);

        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public object Data { get; set; }

        public ApiResponse()
        {

        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Updated Successfully",
                201 => "Created Successfully",
                204 => "Resource Updated Successfully",
                400 => "Bad Request",
                401 => "Unauthorize",
                404 => "Not Found",
                405 => "Not Allowed",
                406 => "Not Accepted",
                418 => "Failed to Save",
                500 => "Internal Server Error",
                _ => null
            };
        }

         private bool DetectError(int DetectError)
        {
            return DetectError > 299 || 200 > DetectError;
        }
    }
}