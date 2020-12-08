using HotChocolate.Execution;
using HotChocolate.Tests;
using Snapshooter;
using Snapshooter.Xunit;

namespace HotChocolate.Data.MongoDb.Sorting
{
    public static class TestExtensions
    {
        public static void MatchDocumentSnapshot(
            this IExecutionResult? result,
            string snapshotName)
        {
            if (result is { })
            {
                result.MatchSnapshot(snapshotName);
                if (result.ContextData is { } &&
                    result.ContextData.TryGetValue("query", out object? queryResult))
                {
                    queryResult.MatchSnapshot(new SnapshotNameExtension(snapshotName + "_query"));
                }
            }
        }
    }
}