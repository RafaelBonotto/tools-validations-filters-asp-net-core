using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Candidato.Domain.Util

{
    public static class Filter
    {
        public static List<T> filtrar<T>(List<T> lst, string search, List<string> fields)
        {
            return lst.Where(l => filterColumns<T>(search, fields, l) == true).ToList();
        }
        public static List<T> orderBy<T>(List<T> lst, string column, string modo)
        {
            if (modo.ToUpper() == "ASC")
            {
                lst = lst.OrderBy(l => l.GetType().GetProperty(column).GetValue(l)).ToList();
            }
            else if (modo.ToUpper() == "DESC")
            {
                lst = lst.OrderByDescending(l => l.GetType().GetProperty(column).GetValue(l)).ToList();
            }
            return lst;
        }
        public static bool filterColumns<T>(string search, List<string> fields, T row)
        {

            var comparer = new StringSearchEqualityComparer();
            if (String.IsNullOrWhiteSpace(search) || String.IsNullOrEmpty(search) || fields == null)
            {
                return true;
            }
            foreach (string field in fields)
            {
                var fieldValue = row.GetType().GetProperty(field).GetValue(row).ToString();
                if (String.IsNullOrEmpty(fieldValue) || String.IsNullOrWhiteSpace(fieldValue))
                    continue;
                var fieldStrList = fieldValue.Split('|').Where(x => !String.IsNullOrEmpty(x) && !String.IsNullOrWhiteSpace(x)).ToList();
                if (fieldStrList.Where(x => comparer.Equals(search, x) || comparer.Equals(x, search)).Any())
                    return true;


            }
            return false;
        }
        private class StringSearchEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
                if (compareInfo.IndexOf(x.ToUpper(), y.ToUpper(), CompareOptions.IgnoreNonSpace) > -1)
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }
    
}