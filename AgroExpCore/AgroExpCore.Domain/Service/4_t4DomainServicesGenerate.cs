﻿


// —————————————— 
// <auto-generated> 
//	This code was auto-generated 01/22/2021 05:38:40
//     	T4 template generates service code
//	NOTE:T4 generated code may need additional updates/addjustments by developer in order to compile a solution.
// <auto-generated> 
// —————————————–
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using AgroExpCore.Entity;
using AgroExpCore.Entity.UnitofWork;

namespace AgroExpCore.Domain.Service
{

    /// <summary>
    ///
    /// A Company service
    ///       
    /// </summary>
    public class CompanyService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : CompanyViewModel
                                        where Te : Company
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A Company service
    /// </summary>
    public class CompanyServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : CompanyViewModel
                                        where Te : Company
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public CompanyServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }
}