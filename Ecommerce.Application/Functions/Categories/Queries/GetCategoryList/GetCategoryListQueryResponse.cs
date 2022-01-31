namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }
    }
}