using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapesMVC.Models
{
    public class PagedCollection<T>
    {
        /// <summary>
        /// Collection data.
        /// </summary>
        public IEnumerable<T> Data { get; private set; }
        public int TotalCount { get; private set; }
        public int PageCount { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }


        public PagedCollection(IEnumerable<T> data, int page, int pageSize, int totalCount, int pageCount)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            PageCount = pageCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="page">1-based page index</param>
        /// <param name="pageSize">Number of collection elements per page.</param>
        /// <returns></returns>
        public static PagedCollection<T> ExtractPage(IQueryable<T> source, int page, int pageSize)
        {
            int totalCount, pageCount;
            IEnumerable<T> data = GetData(source, ref page, ref pageSize, out totalCount, out pageCount);
            return new PagedCollection<T>(data, page, pageSize, totalCount, pageCount);
        }

        public static PagedCollection<T> ExtractAndConvert<U>(IQueryable<U> source, int page, int pageSize, Converter<U, T> converter)
        {
            int totalCount, pageCount;
            IEnumerable<U> data = GetData(source, ref page, ref pageSize, out totalCount, out pageCount);
            return new PagedCollection<T>(data.ToList().ConvertAll(converter), page, pageSize, totalCount, pageCount);
        }

        /// <summary>
        /// Helper method which computes and validates parameters for a set of paged data, 
        /// and extracts the speciied page of data from a source.
        /// </summary>
        /// <typeparam name="U">Element type of collection from which to extract page of data.</typeparam>
        /// <param name="source">Collection from which to extract page of data.</param>
        /// <param name="page">1-based page number</param>
        /// <param name="pageSize">Number of collection elements per page.</param>
        /// <param name="totalCount">total number of elements in collection.</param>
        /// <param name="pageCount">Total number of pages worth of data in collection.</param>
        /// <returns>Extracted paged data.</returns>
        private static IEnumerable<U> GetData<U>(IQueryable<U> source, ref int page, ref int pageSize, out int totalCount, out int pageCount)
        {
            // Compute parameters of collection page.
            totalCount = source.Count();
            pageCount = (pageSize > 0) ? pageCount = (totalCount + pageSize - 1) / pageSize : 1;

            // Ensure page is within valid range.
            page = Math.Max(Math.Min(page, pageCount), 1);
            
            // Extract paged subset of data from source.
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}