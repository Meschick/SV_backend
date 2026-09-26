using AutoMapper;
using SV_backend.Application.DTOs;
using SV_backend.Domain.Entities;

namespace SV_backend.Application.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CriarProdutoRequest, Produto>();
            CreateMap<ProdutoVariacaoRequest, ProdutoVariacao>();
            CreateMap<ProdutoVariacao, ProdutoVariacaoResponseDto>();

            CreateMap<Produto, ProdutoResponseDto>()
                .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.CategoriaId))
                .ForMember(dest => dest.CategoriaNome, opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nome : string.Empty))
                .ForMember(dest => dest.Variacoes, opt => opt.MapFrom(src => src.Variacoes));

            CreateMap<Produto, CriarProdutoRequest>();
        }
    }
}
