using System.Collections.Generic;

namespace JustEat.TechTest.WebApi.DTO
{
    public class MetaData
    {
        public object SearchedTerms { get; set; }
        public IEnumerable<TagDetail> TagDetails { get; set; }
    }
}