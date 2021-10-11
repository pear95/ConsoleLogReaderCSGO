# ConsoleLogReaderCSGO
A .NET Core library to analyse CS:GO console logs.

## Installation


Use the package manager [NuGet](https://www.nuget.org/) to install. Temporarily unavailable.

## Usage

```C#
using ConsoleLogReaderCSGO;

class Test
{
    public void Method()
    {
        //Create instance
        var reader1 = new LogReader<string>(myString);
        //or
        var reader2 = new LogReader<string[]>(myStringArray);
        //or
        var reader3 = new LogReader<List<string>>(myStringList);
        
        //Get object array of sorted logs.
        var sortedLogs = reader2.GetLogs(LogFlags.Chat);
        
        //Update Logs
        reader2.UpdateLogExtendedFile(myNewLogs);
        //or
        reader2.UpdateLogNewFile(myNewLogs);
    }
}
```
### Flags

```C#
  LogFlags.Chat
  LogFlags.Damage
  LogFlags.MatchInfo
  LogFlags.Debug
  LogFlags.All
```


## License
[MIT](https://choosealicense.com/licenses/mit/)
