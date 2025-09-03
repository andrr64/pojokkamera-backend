namespace pojokkamera_backend.Dtos.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Detail { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(T data, string detail = "Success")
        {
            return new ApiResponse<T> { Success = true, Detail = detail, Data = data };
        }

        public static ApiResponse<T> Fail(string detail)
        {
            return new ApiResponse<T> { Success = false, Detail = detail, Data = default };
        }
    }
}
