using EcoDenuncia.Domain.Enums;

namespace EcoDenuncia.DTO.Request
{
    public class AcompanhamentoDenunciaRequest
    {
        public string Status { get; set; }  // "Aberto", "Em Andamento", "Concluído"
        public DateTime DataAtualizacao { get; set; }
        public string Observacao { get; set; }

        public Guid DenunciaId { get; set; }
    }
}
