﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
