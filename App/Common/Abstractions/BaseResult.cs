namespace App.Common.Abstractions
{
    public abstract class BaseResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
