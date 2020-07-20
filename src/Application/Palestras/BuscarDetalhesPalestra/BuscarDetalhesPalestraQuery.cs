using Domain.Palestras.ValueObjects;
using MediatR;

namespace Application.Palestras.BuscarDetalhesPalestra
{
    public class BuscarDetalhesPalestraQuery : IRequest<PalestraDetalhesReadModel>
    {
        public PalestraId PalestraId { get; }

        public BuscarDetalhesPalestraQuery(PalestraId palestraId)
        {
            PalestraId = palestraId;
        }
    }
}
