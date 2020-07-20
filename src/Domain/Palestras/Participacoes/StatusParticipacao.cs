namespace Domain.Palestras.Participacoes
{
    public enum StatusParticipacao
    {
        Desconhecido = 0,

        Planejado = 10,
        PendenteConfirmacaoSuperior = 20,
        RecusadoSuperior = 30,
        Cancelado = 40,
        Confirmado = 50,
    }
}
