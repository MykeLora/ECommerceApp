using AutoMapper;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.DTos.ProductDTos;
using ECommerceApp.DTOs.CategoryDTOs;
using ECommerceApp.Persistence.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region ProductProfile

            // Mostrar Producto (response DTO)
            CreateMap<Product, ProductResponseDTO>()
                .ForSourceMember(src => src.CreatedAt, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.UpdatedBy, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.CreatedBy, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.IsDeleted, opt => opt.DoNotValidate())
                .ReverseMap();

            // Mostrar Producto por su categoria (response DTO)
            CreateMap<ProductCategoryModel, ProductWithCategory>();


            // Crear Producto (create DTO)
            CreateMap<ProductCreateDTO, Product>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore())  // Al crear, la fecha de actualización no se establece
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())  // Esta será establecida en el backend según el usuario logueado
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(_ => false)); // Por defecto, un producto no está eliminado

            CreateMap<Product, ProductCreateDTO>().ReverseMap();

            // Actualizar Producto (update DTO)
            CreateMap<ProductUpdateDTO, Product>()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore()) // No se debe modificar la fecha de creación
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now)) // Se debe actualizar la fecha de modificación
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore()) // Esta será establecida en el backend según el usuario logueado
                .ForMember(x => x.IsDeleted, opt => opt.Ignore());
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            #endregion

            #region CategoryProfile

            // Mostrar Categoría (response DTO)
            CreateMap<Category, CategoryResponseDTO>()
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.Ignore());
              

            // Crear Categoría (create DTO)
            CreateMap<CategoryCreateDTO, Category>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore()) // Al crear, la fecha de actualización no se establece
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())  // Esta será establecida en el backend según el usuario logueado
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(_ => false)); // Por defecto, una categoría no está eliminada
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();

            // Actualizar Categoría (update DTO)
            CreateMap<CategoryUpdateDTO, Category>()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore()) // No se debe modificar la fecha de creación
                .ForMember(x => x.CreatedBy, opt => opt.Ignore()) // No se debe modificar el usuario que creó la categoría
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now)) // Se debe actualizar la fecha de modificación
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore()) // Esta será establecida en el backend según el usuario logueado
                .ForMember(x => x.IsDeleted, opt => opt.Ignore());
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            #endregion
        }

    }
}
