# EntityFrameworkQueries

## Getting Started
- VS 2022
- .net 6
- [AP Database](https://github.com/lewisjae1/EntityFrameworkQueries/blob/c8132dfa2e0255a0ab9710e0e3ac3ebd47d35e17/create_ap%20(3).sql) installed

You may need to change the DB connection string located in the APContext class
By default it points to mssqllocaldb. If your AP script is not installed on mssqllocaldb, update the string.
```csharp
optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocalDB;Initial catalog=AP");
```
