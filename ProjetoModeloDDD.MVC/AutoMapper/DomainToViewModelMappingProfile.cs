using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }

    }
}