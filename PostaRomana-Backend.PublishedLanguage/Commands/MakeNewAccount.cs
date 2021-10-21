using MediatR;

namespace PostaRomanaBackend.PublishedLanguage.Commands
{
    public class MakeNewAccount : IRequest
    {
        public string UniqueIdentifier { get; set; }
        public string AccountType { get; set; }
        public string Valuta { get; set; }
    }
}
