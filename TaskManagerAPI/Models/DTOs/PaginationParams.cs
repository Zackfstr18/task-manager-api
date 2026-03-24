namespace TaskManagerAPI.Models.DTOs
{
    public class PaginationParams
    {
        public int MaxPageSize = 50;
        public int _PageSize = 10;
        public int Page { get; set; } = 1;

        public int PageSize 
        { get => _PageSize; 
          set => _PageSize = value > MaxPageSize ? MaxPageSize : value ; 
        }

        public bool? IsCompleted { get; set; }

        public string? Search {  get; set; }

        public string? SortBy { get; set; }

        public bool Descending { get; set; } = false;
    }
}
