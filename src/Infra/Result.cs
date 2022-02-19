namespace Infra
{
    public class Result<T>
    {
        private Result() { }
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

        public static Result<T> CreateSucess(T data)
        {
            Result<T> result = new Result<T>();
            result.Data = data;
            result.IsSuccess = true;

            return result;
        }

        public static Result<T> CreateFail(string message)
        {
            Result<T> result = new Result<T>();
            result.Error = message;
            result.IsSuccess = false;

            return result;
        }
    }
}
