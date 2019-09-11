namespace infra.generics.repository.exceptions
{
    using System;


    public class RepositorioException : Exception
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="message">Mensagem de erro.</param>
        public RepositorioException(string message)
            : base(message)
        {
        }
    }
}
