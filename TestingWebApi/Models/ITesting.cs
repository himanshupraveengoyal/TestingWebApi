namespace TestingWebApi.Models
{
    public interface ITesting
    {
        Task<IEnumerable<Message>> SaveMessages(Dictionary<string, string> sqlParameterArray, string procName);
    }
}
