namespace Infra
{
    public class DomainResult<T>
    {
        private DomainResult() { }
        public T Model { get; private set; }
        public string Error { get; private set; }
        public bool IsSucess { get; private set; }

        public static DomainResult<T> CreateSuccess(T model)
        {
            DomainResult<T> domainResult = new DomainResult<T>();
            domainResult.Model = model;
            domainResult.IsSucess = true;
            return domainResult;
        }

        public static DomainResult<T> CreateFail(string error)
        {
            DomainResult<T> domainResult = new DomainResult<T>();
            domainResult.Error = error;
            domainResult.IsSucess = false;
            return domainResult;
        }
    }
}
