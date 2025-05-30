namespace EcoDenuncia.DTO.Response
{
    public class DenunciaResponse
    {
        public Guid IdDenuncia { get; set; }
        public Guid IdUsuario { get; set; } // ID do usuário que fez a denúncia
        public Guid IdLocalizacao { get; set; } // ID da localização da denúncia
        public Guid IdOrgaoPublico { get; set; } // ID do órgão público relacionado à denúncia
        public DateTime DataHora { get; set; } // Data e hora da denúncia
        public string Descricao { get; set; } // Descrição da denúncia


    }
}
