using System.Threading;
using System.Threading.Tasks;
using Application.Core.Data;
using Dapper;
using MediatR;

namespace Application.Palestras.BuscarDetalhesPalestra
{
    public class BuscarDetalhesPalestraQueryHandler
        : IRequestHandler<BuscarDetalhesPalestraQuery, PalestraDetalhesReadModel>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public BuscarDetalhesPalestraQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<PalestraDetalhesReadModel> Handle(BuscarDetalhesPalestraQuery request,
            CancellationToken cancellationToken)
        {
            const string palestraSql = "SELECT" +
                " palestra.\"PalestraId\"," +
                " palestra.\"Tema\"," +
                " palestra.\"Titulo\"," +
                " palestra.\"DataInicial\"," +
                " palestra.\"DataFinal\"," +
                " palestra.\"Status\"," +
                " palestra.\"Local\"," +
                " palestra.\"OrganizadorEmail\"," +
                " palestra.\"PalestranteNome\"," +
                " palestra.\"PalestranteEmail\"" +
                " FROM public.\"Palestra\" palestra" +
                " WHERE palestra.\"PalestraId\" = @PalestraId";

            const string participantesSql = "SELECT " +
                " part.\"FuncionarioId\"," +
                " part.\"Status\"," +
                " func.\"Nome\"," +
                " func.\"Email\"," +
                " func.\"SuperiorEmail\"" +
                " FROM public.\"Participacao\" part" +
                " INNER JOIN public.\"Funcionario\" func" +
                " ON part.\"FuncionarioId\" = func.\"FuncionarioId\"" +
                " WHERE part.\"PalestraId\" = @PalestraId";

            var connection = _connectionFactory.GetOpenConnection();

            PalestraDetalhesReadModel detalhes;
            using (var multi = connection.QueryMultipleAsync(palestraSql + "; " + participantesSql,
                new { PalestraId = request.PalestraId.Value }))
            {
                detalhes = await multi.Result.ReadSingleAsync<PalestraDetalhesReadModel>();
                detalhes.Participantes = await multi.Result.ReadAsync<ParticipantesReadModel>();
            }

            return detalhes;
        }
    }
}
