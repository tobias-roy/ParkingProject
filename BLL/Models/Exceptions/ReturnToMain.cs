namespace Exceptions
{
  [Serializable]
    class ReturnToMainException : Exception
    {
        public ReturnToMainException() {}
    }
    class ReturnToMainExceptionNoDB : Exception
    {
        public ReturnToMainExceptionNoDB() {}
    }
}
