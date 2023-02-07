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

    class ReturnToMainExceptionNoTicketCreation : Exception
    {
        public ReturnToMainExceptionNoTicketCreation() {}
    }

    class DatabaseUnreachableException : Exception{
        public DatabaseUnreachableException(){}
    }
}
