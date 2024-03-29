﻿using AgroExpCore.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroExpCore.Domain.Mapping
{
    public partial class MappingProfile : Profile
    {
        /// <summary>
        /// Create automap mapping profiles
        /// </summary>
        public MappingProfile()
        {
            CreateMap<AccountViewModel, Account>();
            CreateMap<Account, AccountViewModel>();
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.DecryptedPassword, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => string.Join(";", src.Roles)));
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.DecryptedPassword))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.Roles.Split(";", StringSplitOptions.RemoveEmptyEntries)));

            //call code in partial scaffolded function
            SetAddedMappingProfile();
        }

        //to call scaffolded method
        partial void SetAddedMappingProfile();

    }





}
