using API.Models;
using API.Models.DTOs.AdministradorDTO;
using API.Models.DTOs.ClienteDTO;
using API.Models.DTOs.ProductoDTO;
using API.Models.Entities;
using AutoMapper;

namespace API.Helpers
{
	public class MappingConfig
	{
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //Clientes
                config.CreateMap<Users, ClienteDTO>().ReverseMap();
                config.CreateMap<ClienteCreacionDTO, Users>();

                //Administradores
                config.CreateMap<Users, AdministradorDTO>().ReverseMap();
                config.CreateMap<AdministradorCreacionDTO, Users>();

                //productos
                config.CreateMap<ProductoCreacionDTO, Producto>().ReverseMap();
                config.CreateMap<Producto, ProductoDTO>();
                config.CreateMap<ProductoEdicionDTO, ProductoDTO>().ReverseMap();
                config.CreateMap<Producto, ProductoEdicionDTO>().ReverseMap();
                config.CreateMap<ProductoEdicionDTO, Producto>();
                
			});

            return mappingConfig;
            
        }
    }
}
