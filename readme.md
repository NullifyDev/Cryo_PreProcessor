# Cryo Library Pre-Processor
###
This pre-processor is specifically for the [Cryo](https://github.com/NullifyDev/Cryo) project which is made for the [Sphere](https://github.com/NullifyDev/Sphere) project.

> [!WARNING]
> - The pre-processor trusts that the method or exported object at hand contains the correct parameter types in the right order, in accordance to the associated push and pop order within the associated assembly files of the library at hand.
> - Only supports function definitions.

##

## Building and Testing
This project uses the [latest .Net release](https://dotnet.microsoft.com/en-us/download/dotnet). 
You can change the .Net verison by modifying the `TargetFramework` property under `Project.PropertyGroup` within the `.csproj` file, which is usually the 2nd property within `PropertyGroup` under `Project`.

The following are possible ways to run the pre-processor:

| Code                                                        | Description                                                                                                                      |
|-------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------|
| `dotnet run interpret "<code>"`                             | Interprets the code similarly to if it was from a file (must have `"` on either side of the code to count it as the whole thing) |
| `dotnet run <file1.clod> <file2.clod> ...`                  | Interprets each file as long as the referring argument at hand ends with `.clod`                                                 |
| `dotnet run <file1.clod> <file2.clod> ... interpret <code>` | This is just the combination of the two. The order doesn't matter 

you can build the project by doing `dotnet publish`. 
You can learn more via Microsoft's Documentation of .Net

## 

## Features 
The project for the time being only returns Function Definitions.
The following items are the recognised keywords:

| Type                 | Keywords                                                                                                                                      |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| DataTypes            | `none` `int` `str`                                                                                                                            |
| Registers            | (hopefully) all 64-bit registers, so far. Defaults to `int` with the register's bit length (Think of it like C/C++'s `size_t`, in a nutshell) |
| Other                | `input` (defaults to `str`)                                                                                                                   |
| [<b>Mandatory</b>](https://github.com/NullifyDev/Cryo_PreProcessor#Syntax) | `->`                                                                                    | 

##

### Syntax
The `->` is a mandatory token. Which is an inspiration as well as a *functional* token for telling the interpreter that the item is complet and that the interpreter can move to the next item in the line.


The following syntax, taken from [Haskell](https://www.haskell.org/), is as follows:
| Implemented          | Definitions | Syntax                                            |
|----------------------|-------------|---------------------------------------------------|
| [:heavy_check_mark:] | Function    | `arg0 -> arg1 -> arg2 -> ... -> returnTypeOrItem` |
|                      | Class       | N/A                                               |

##

The following is how it should look like as an example, which can be found in the [Core library of Cryo](https://github.com/NullifyDev/Cryo/blob/main/lib/core/core.json) (file is to be updated):
```
none  -> int
int   -> none
str   -> rsi
str   -> none
input -> rsi:str
```

As you may have noticed, in the [Features](https://github.com/NullifyDev/Cryo_PreProcessor#Features) section of this readme documentation, there's `Mandatory` under the types column of the recognized keywords which has `->` as the associated token.
This is because the pre-processor's syntax is inspired by [Haskell](https://www.haskell.org/).