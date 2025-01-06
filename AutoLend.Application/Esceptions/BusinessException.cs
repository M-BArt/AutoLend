namespace AutoLend.Core.Esceptions {
    public class BusinessException : Exception {
        public BusinessException( string message ) : base(message) { }
    }
}
