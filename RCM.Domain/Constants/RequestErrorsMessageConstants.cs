namespace RCM.Domain.Constants
{
    public class RequestErrorsMessageConstants
    {
        public const string DuplicataAlreadyExists = "Já existe uma duplicata com esse mesmo número e fornecedor.";
        public const string ChequeAlreadyExists = "Já existe um cheque com esse mesmo número, banco e cliente.";

        public const string MarcaNotFound = "Nenhuma marca foi encontrada com esse Id.";

        public const string ChequeStateNull = "Nenhum estado foi encontrado para o cheque. Um novo estado de 'Bloqueado' foi criado.";
    }
}
