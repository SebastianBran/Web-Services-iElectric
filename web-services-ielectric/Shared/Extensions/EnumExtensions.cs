﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Supermarket.API.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum sourceEnum)
        {
            FieldInfo info = sourceEnum.GetType().GetField(sourceEnum.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? sourceEnum.ToString();
        }
    }
}
