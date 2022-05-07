using Xunit;

namespace Tests;

/// <summary>
/// Used to make tests not-parallel and use only 1 static logger
/// </summary>
[CollectionDefinition("NotParallel collection", DisableParallelization = true)]
public class NotParallelCollection: ICollectionFixture<TestFixture>
{
    
}