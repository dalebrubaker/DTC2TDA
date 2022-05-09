namespace Domain;

/// <summary>
///     Bidirectional map of internal accountId to DTC accountDisplayName.
///     Thanks to Enigmativity at https://stackoverflow.com/questions/10966331/two-way-bidirectional-dictionary-in-c/10966684#10966684
/// </summary>
public class AccountDisplayNamesToIdsMap
{
    private readonly Dictionary<string, string?> _accountIdByName = new();
    private readonly Dictionary<string, string?> _accountNameById = new();
    private readonly object _lock = new();
    private readonly string _name;

    public AccountDisplayNamesToIdsMap(string name)
    {
        _name = name;
    }

    public int Count => _accountNameById.Count;

    /// <summary>
    ///     Add the pair accountId,accountDisplayName
    /// </summary>
    /// <param name="accountId">some accountId to pair with accountDisplayName</param>
    /// <param name="accountDisplayName">the display name associated with accountId</param>
    public void Add(string accountId, string accountDisplayName)
    {
        lock (_lock)
        {
            _accountNameById.Add(accountId, accountDisplayName);
            _accountIdByName.Add(accountDisplayName, accountId);
        }
    }

    /// <summary>
    ///     Try to get the value of accountDisplayName for the given accountId
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="accountDisplayName"></param>
    /// <returns></returns>
    public bool TryGetValueAccountDisplayName(string accountId, out string? accountDisplayName)
    {
        lock (_lock)
        {
            var result = _accountNameById.TryGetValue(accountId, out accountDisplayName);
            return result;
        }
    }

    /// <summary>
    ///     Try to get the value of accountId for the given accountDisplayName
    /// </summary>
    /// <param name="accountDisplayName"></param>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public bool TryGetValueAccountId(string accountDisplayName, out string? accountId)
    {
        lock (_lock)
        {
            var result = _accountIdByName.TryGetValue(accountDisplayName, out accountId);
            return result;
        }
    }

    public override string ToString()
    {
        return $"{_name} Count={Count:N0}";
    }
}