namespace Exceptions
{
  [Serializable]
    class ReturnToMainExceptionDeleteCreated : Exception
    {
        ///<summary>
        ///Exception thrown when cancelling during the creation of a ticket
        ///</summary>
        public ReturnToMainExceptionDeleteCreated() {}
    }
    class ReturnToMainException : Exception
    {
        ///<summary>
        ///Exception thrown before the creation of a ticket
        ///</summary>
        public ReturnToMainException() {}
    }

    class ReturnToMainExceptionNoTicketCreation : Exception
    {
        ///<summary>
        ///Exception thrown 
        ///</summary>
        public ReturnToMainExceptionNoTicketCreation() {}
    }

    class DatabaseUnreachableException : Exception{
        ///<summary>
        ///Exception thrown when databaseconnection is unavailable
        ///</summary>
        public DatabaseUnreachableException(){}
    }
}
