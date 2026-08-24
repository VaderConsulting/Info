# Info

VS 2008 VB.NET (.NET 3.5) working copy. Info.CPU samples kernel32 GetSystemTimes over 250 ms and StartCPUSpin launches one DoSpin thread per core until CurrentUtilisation meets DesiredCPUUtilisation (default 25%). Test.frmMain plots the percentage on Plotter1 and Start/Stop toggles the spinner from nudDesiredValue; the solution also references an external Plotter.csproj that is not in this tree. Open `Info.sln`. This is a historical working copy from Dave Robinson / VaderConsulting.

**Source last updated:** 2010-01-05  
**Language:** VB.NET  
**Target:** v3.5  
**Output:** Library, WinExe

## What it is

VS 2008 VB.NET (.NET 3.5) working copy. Info.CPU samples kernel32 GetSystemTimes over 250 ms and StartCPUSpin launches one DoSpin thread per core until CurrentUtilisation meets DesiredCPUUtilisation (default 25%). Test.frmMain plots the percentage on Plotter1 and Start/Stop toggles the spinner from nudDesiredValue; the solution also references an external Plotter.csproj that is not in this tree. Open `Info.sln`. This is a historical working copy from Dave Robinson / VaderConsulting.

## Solution structure

| Project | Language | Path |
|---------|----------|------|
| `Test` | VB.NET | `Test/Test.vbproj` |
| `Info` | VB.NET | `Info/Info.vbproj` |

## How to open

Open `Info.sln` in Visual Studio.

## Attribution and provenance

- **Assembly company:** Microsoft
- **Assembly copyright:** Copyright © Microsoft 2010

## License

MIT. See `LICENSE`.
