using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {       
            public ViewModelToDomainMappingProfile()
            {
                CreateMap<ClienteViewModel, Cliente>();
                CreateMap<ProdutoViewModel, Produto>();
            }
        
    }
}