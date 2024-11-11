namespace Common
{
    public struct Result<T>
    {
        public bool IsExist { get; }
        public T Object { get; }

        private Result(bool isExist, T result)
        {
            IsExist = isExist;
            Object = result;
        }

        public static Result<T> Success(T result)
        {
            return new Result<T>(true, result);
        }
        
        public static Result<T> Fail()
        {
            return new Result<T>(false, default);
        }
    }
}