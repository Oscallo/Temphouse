﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Temphouse.Extensions
{
    public static class ReadOnlyCollectionExtensions
    {
        public static IList<T> ToIList<T>(this ReadOnlyCollection<T> collection) 
        {
            IList<T> list = new List<T>();

            foreach (T item in collection) 
            {
                list.Add(item);
            }
            
            return list;
        }
    }
}
