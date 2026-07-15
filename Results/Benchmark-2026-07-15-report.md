```

BenchmarkDotNet v0.16.0-nightly.20260714.579, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12700H 2.30GHz, 1 CPU, 20 logical and 14 physical cores
Memory: 31.69 GB Total, 19.5 GB Available
.NET SDK 11.0.100-preview.6.26359.118
  [Host]     : .NET 11.0.0 (11.0.0-preview.6.26359.118, 11.0.26.36018), X64 RyuJIT x86-64-v3
  Job-GVKUBM : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  Job-IHFIKV : .NET 11.0.0 (11.0.0-preview.6.26359.118, 11.0.26.36018), X64 RyuJIT x86-64-v3
  Job-AZESIF : .NET 8.0.29 (8.0.29, 8.0.2926.32403), X64 RyuJIT x86-64-v3


```
| Namespace                            | Type                        | Method            | Runtime   | Implementation     | Scenario          | Mean          | Error       | Gen0   | Gen1   | Allocated |
|------------------------------------- |---------------------------- |------------------ |---------- |------------------- |------------------ |--------------:|------------:|-------:|-------:|----------:|
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Command           | .NET 10.0 | Axent              | Command           |     33.162 ns |   0.1104 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Command           | .NET 11.0 | Axent              | Command           |      5.590 ns |   0.0358 ns | 0.0019 |      - |      24 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | FullQuery         | .NET 10.0 | Axent              | FullQuery         |    103.973 ns |   0.1920 ns | 0.0134 |      - |     168 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | FullQuery         | .NET 11.0 | Axent              | FullQuery         |     71.219 ns |   0.1227 ns | 0.0134 |      - |     168 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Query             | .NET 10.0 | Axent              | Query             |     36.354 ns |   0.1723 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Query             | .NET 11.0 | Axent              | Query             |     10.618 ns |   0.0551 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | ShortCircuit      | .NET 10.0 | Axent              | ShortCircuit      |     40.867 ns |   0.2531 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | ShortCircuit      | .NET 11.0 | Axent              | ShortCircuit      |     13.969 ns |   0.0645 ns | 0.0076 |      - |      96 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 8.0  | Direct             | CascadingMessages |     40.935 ns |   0.1405 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 10.0 | Direct             | CascadingMessages |     34.945 ns |   0.1177 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 11.0 | Direct             | CascadingMessages |      5.478 ns |   0.0511 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 8.0  | Direct             | Command           |     12.450 ns |   0.0146 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 10.0 | Direct             | Command           |     10.830 ns |   0.0219 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 11.0 | Direct             | Command           |      1.072 ns |   0.0021 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 8.0  | Direct             | FullQuery         |     66.784 ns |   0.1847 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 10.0 | Direct             | FullQuery         |     56.355 ns |   0.1800 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 11.0 | Direct             | FullQuery         |     32.929 ns |   0.0728 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 8.0  | Direct             | Publish           |     15.466 ns |   0.0591 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 10.0 | Direct             | Publish           |     13.081 ns |   0.0139 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 11.0 | Direct             | Publish           |      1.077 ns |   0.0022 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 8.0  | Direct             | Query             |     17.848 ns |   0.0607 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 10.0 | Direct             | Query             |     15.821 ns |   0.0457 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 11.0 | Direct             | Query             |      3.709 ns |   0.0376 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 8.0  | Direct             | ShortCircuit      |     10.652 ns |   0.0299 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 10.0 | Direct             | ShortCircuit      |      9.441 ns |   0.0125 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 11.0 | Direct             | ShortCircuit      |      1.929 ns |   0.0027 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamFullQuery   | .NET 8.0  | Direct             | StreamFullQuery   |    617.676 ns |   2.0954 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamFullQuery   | .NET 10.0 | Direct             | StreamFullQuery   |    465.474 ns |   1.8141 ns | 0.1836 |      - |    2304 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamFullQuery   | .NET 11.0 | Direct             | StreamFullQuery   |    444.841 ns |   1.8635 ns | 0.1836 |      - |    2304 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamQuery       | .NET 8.0  | Direct             | StreamQuery       |    114.426 ns |   0.3361 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamQuery       | .NET 10.0 | Direct             | StreamQuery       |     85.085 ns |   0.3369 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamQuery       | .NET 11.0 | Direct             | StreamQuery       |     72.754 ns |   0.3456 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 8.0  | DispatchR          | CascadingMessages |     92.460 ns |   1.0135 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 10.0 | DispatchR          | CascadingMessages |     69.116 ns |   0.1775 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 11.0 | DispatchR          | CascadingMessages |     60.926 ns |   0.1572 ns | 0.0050 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 8.0  | DispatchR          | Command           |     31.613 ns |   0.1066 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 10.0 | DispatchR          | Command           |     32.858 ns |   0.0410 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 11.0 | DispatchR          | Command           |     19.581 ns |   0.0682 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 8.0  | DispatchR          | FullQuery         |    106.171 ns |   0.7706 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 10.0 | DispatchR          | FullQuery         |     87.919 ns |   0.5912 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 11.0 | DispatchR          | FullQuery         |     66.730 ns |   0.1645 ns | 0.0031 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 8.0  | DispatchR          | Publish           |     46.520 ns |   0.1263 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 10.0 | DispatchR          | Publish           |     36.309 ns |   0.0780 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 11.0 | DispatchR          | Publish           |     33.945 ns |   0.0659 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 8.0  | DispatchR          | Query             |     41.584 ns |   0.1003 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 10.0 | DispatchR          | Query             |     29.109 ns |   0.0613 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 11.0 | DispatchR          | Query             |     21.783 ns |   0.0708 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 8.0  | DispatchR          | ShortCircuit      |     42.010 ns |   0.2118 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 10.0 | DispatchR          | ShortCircuit      |     26.529 ns |   0.0285 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 11.0 | DispatchR          | ShortCircuit      |     19.804 ns |   0.0721 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamFullQuery   | .NET 8.0  | DispatchR          | StreamFullQuery   |    630.625 ns |   2.0494 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamFullQuery   | .NET 10.0 | DispatchR          | StreamFullQuery   |    482.385 ns |   3.0654 ns | 0.1836 |      - |    2304 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamFullQuery   | .NET 11.0 | DispatchR          | StreamFullQuery   |    473.010 ns |   1.5985 ns | 0.1836 |      - |    2304 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamQuery       | .NET 8.0  | DispatchR          | StreamQuery       |    126.919 ns |   0.5100 ns | 0.0222 |      - |     280 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamQuery       | .NET 10.0 | DispatchR          | StreamQuery       |     92.894 ns |   0.3352 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamQuery       | .NET 11.0 | DispatchR          | StreamQuery       |     82.117 ns |   0.3641 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 8.0  | Foundatio.Mediator | CascadingMessages |    134.442 ns |   0.2607 ns | 0.0107 |      - |     136 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 10.0 | Foundatio.Mediator | CascadingMessages |     87.752 ns |   0.2168 ns | 0.0107 |      - |     136 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 11.0 | Foundatio.Mediator | CascadingMessages |     48.851 ns |   0.2129 ns | 0.0108 |      - |     136 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 8.0  | Foundatio.Mediator | Command           |     35.476 ns |   0.0780 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 10.0 | Foundatio.Mediator | Command           |     21.861 ns |   0.1444 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 11.0 | Foundatio.Mediator | Command           |     12.407 ns |   0.0888 ns | 0.0019 |      - |      24 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 8.0  | Foundatio.Mediator | FullQuery         |     96.381 ns |   0.3430 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 10.0 | Foundatio.Mediator | FullQuery         |     82.633 ns |   0.2244 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 11.0 | Foundatio.Mediator | FullQuery         |     50.875 ns |   0.2699 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 8.0  | Foundatio.Mediator | Publish           |     82.783 ns |   0.3966 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 10.0 | Foundatio.Mediator | Publish           |     56.323 ns |   0.2532 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 11.0 | Foundatio.Mediator | Publish           |     40.039 ns |   0.1922 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 8.0  | Foundatio.Mediator | Query             |     44.186 ns |   0.2208 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 10.0 | Foundatio.Mediator | Query             |     28.362 ns |   0.1246 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 11.0 | Foundatio.Mediator | Query             |     11.499 ns |   0.0192 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 8.0  | Foundatio.Mediator | ShortCircuit      |     45.788 ns |   0.0977 ns |      - |      - |         - |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 10.0 | Foundatio.Mediator | ShortCircuit      |     35.102 ns |   0.0475 ns |      - |      - |         - |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 11.0 | Foundatio.Mediator | ShortCircuit      |      4.992 ns |   0.0145 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | StreamQuery       | .NET 8.0  | Foundatio.Mediator | StreamQuery       |    135.408 ns |   0.5309 ns | 0.0241 |      - |     304 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | StreamQuery       | .NET 10.0 | Foundatio.Mediator | StreamQuery       |     92.573 ns |   0.3497 ns | 0.0242 |      - |     304 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | StreamQuery       | .NET 11.0 | Foundatio.Mediator | StreamQuery       |     80.059 ns |   0.3018 ns | 0.0242 |      - |     304 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 8.0  | Immediate.Handlers | CascadingMessages |    104.223 ns |   0.2524 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 10.0 | Immediate.Handlers | CascadingMessages |     96.341 ns |   0.3102 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 11.0 | Immediate.Handlers | CascadingMessages |     32.662 ns |   0.1556 ns | 0.0076 |      - |      96 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 8.0  | Immediate.Handlers | Command           |     23.789 ns |   0.0692 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 10.0 | Immediate.Handlers | Command           |     20.042 ns |   0.0302 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 11.0 | Immediate.Handlers | Command           |      2.574 ns |   0.0041 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 8.0  | Immediate.Handlers | FullQuery         |     86.468 ns |   0.1750 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 10.0 | Immediate.Handlers | FullQuery         |     69.906 ns |   0.2115 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 11.0 | Immediate.Handlers | FullQuery         |     37.144 ns |   0.1432 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 8.0  | Immediate.Handlers | Publish           |     69.544 ns |   0.3362 ns | 0.0025 |      - |      32 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 10.0 | Immediate.Handlers | Publish           |     61.060 ns |   1.2026 ns | 0.0025 |      - |      32 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 11.0 | Immediate.Handlers | Publish           |     23.710 ns |   0.0819 ns | 0.0025 |      - |      32 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 8.0  | Immediate.Handlers | Query             |     29.124 ns |   0.0743 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 10.0 | Immediate.Handlers | Query             |     24.617 ns |   0.0752 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 11.0 | Immediate.Handlers | Query             |      5.388 ns |   0.0290 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 8.0  | Immediate.Handlers | ShortCircuit      |     21.139 ns |   0.0681 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 10.0 | Immediate.Handlers | ShortCircuit      |     18.057 ns |   0.0662 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 11.0 | Immediate.Handlers | ShortCircuit      |      2.583 ns |   0.0040 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamFullQuery   | .NET 8.0  | Immediate.Handlers | StreamFullQuery   |    612.850 ns |   2.3799 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamFullQuery   | .NET 10.0 | Immediate.Handlers | StreamFullQuery   |    459.495 ns |   3.5353 ns | 0.1836 |      - |    2304 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamFullQuery   | .NET 11.0 | Immediate.Handlers | StreamFullQuery   |    443.718 ns |   2.5859 ns | 0.1836 |      - |    2304 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamQuery       | .NET 8.0  | Immediate.Handlers | StreamQuery       |    115.686 ns |   0.3828 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamQuery       | .NET 10.0 | Immediate.Handlers | StreamQuery       |     83.928 ns |   0.3767 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamQuery       | .NET 11.0 | Immediate.Handlers | StreamQuery       |     72.747 ns |   0.1964 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 8.0  | MassTransit        | CascadingMessages | 25,563.345 ns | 113.7462 ns | 1.7090 | 0.0610 |   21456 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 10.0 | MassTransit        | CascadingMessages | 19,653.870 ns | 118.0362 ns | 1.6479 | 0.0610 |   20960 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 11.0 | MassTransit        | CascadingMessages | 19,307.600 ns | 180.0865 ns | 1.6479 | 0.0610 |   20912 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 8.0  | MassTransit        | Command           |  2,326.874 ns |   9.2982 ns | 0.3967 |      - |    5016 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 10.0 | MassTransit        | Command           |  1,958.769 ns |   6.9253 ns | 0.3929 | 0.0038 |    4952 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 11.0 | MassTransit        | Command           |  1,981.587 ns |   6.4633 ns | 0.3929 | 0.0038 |    4952 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 8.0  | MassTransit        | FullQuery         | 16,924.478 ns | 239.8656 ns | 1.0681 | 0.0305 |   13448 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 10.0 | MassTransit        | FullQuery         | 11,641.513 ns |  95.4008 ns | 1.0376 | 0.0305 |   13136 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 11.0 | MassTransit        | FullQuery         | 12,564.368 ns |  84.5048 ns | 1.0376 | 0.0305 |   13088 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 8.0  | MassTransit        | Publish           |  3,919.179 ns |  11.5969 ns | 0.6104 | 0.0076 |    7664 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 10.0 | MassTransit        | Publish           |  3,287.498 ns |   9.9978 ns | 0.5989 | 0.0038 |    7536 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 11.0 | MassTransit        | Publish           |  3,227.931 ns |  14.5491 ns | 0.5989 | 0.0038 |    7536 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 8.0  | MassTransit        | Query             | 16,975.811 ns | 195.4065 ns | 1.0681 | 0.0305 |   13488 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 10.0 | MassTransit        | Query             | 10,653.507 ns | 139.7652 ns | 1.0376 | 0.0305 |   13176 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 11.0 | MassTransit        | Query             | 12,748.387 ns |  93.9100 ns | 1.0376 | 0.0305 |   13128 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 8.0  | MassTransit        | ShortCircuit      | 15,566.891 ns | 159.3255 ns | 0.9918 | 0.0305 |   12576 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 10.0 | MassTransit        | ShortCircuit      | 10,809.944 ns |  64.8804 ns | 0.9766 | 0.0305 |   12264 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 11.0 | MassTransit        | ShortCircuit      | 11,622.525 ns |  75.9759 ns | 0.9613 | 0.0305 |   12216 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 8.0  | MediatR            | CascadingMessages |    203.166 ns |   1.0666 ns | 0.0675 |      - |     848 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 10.0 | MediatR            | CascadingMessages |    138.363 ns |   0.4246 ns | 0.0587 |      - |     736 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 11.0 | MediatR            | CascadingMessages |    165.829 ns |   0.9024 ns | 0.0637 |      - |     800 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 8.0  | MediatR            | Command           |     85.429 ns |   0.3489 ns | 0.0191 |      - |     240 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 10.0 | MediatR            | Command           |     48.179 ns |   0.2147 ns | 0.0102 |      - |     128 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 11.0 | MediatR            | Command           |     59.414 ns |   0.2365 ns | 0.0153 |      - |     192 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 8.0  | MediatR            | FullQuery         |    196.128 ns |   1.2313 ns | 0.0489 |      - |     616 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 10.0 | MediatR            | FullQuery         |    156.309 ns |   0.6391 ns | 0.0439 |      - |     552 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 11.0 | MediatR            | FullQuery         |    161.071 ns |   0.8014 ns | 0.0489 |      - |     616 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 8.0  | MediatR            | Publish           |     99.942 ns |   0.3760 ns | 0.0350 |      - |     440 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 10.0 | MediatR            | Publish           |     77.318 ns |   0.1665 ns | 0.0350 |      - |     440 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 11.0 | MediatR            | Publish           |     92.665 ns |   0.3849 ns | 0.0350 |      - |     440 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 8.0  | MediatR            | Query             |     98.096 ns |   0.6316 ns | 0.0280 |      - |     352 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 10.0 | MediatR            | Query             |     52.768 ns |   0.2488 ns | 0.0191 |      - |     240 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 11.0 | MediatR            | Query             |     63.143 ns |   0.2855 ns | 0.0242 |      - |     304 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 8.0  | MediatR            | ShortCircuit      |    107.584 ns |   0.5733 ns | 0.0414 |      - |     520 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 10.0 | MediatR            | ShortCircuit      |     81.054 ns |   0.3177 ns | 0.0362 |      - |     456 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 11.0 | MediatR            | ShortCircuit      |     96.271 ns |   0.3595 ns | 0.0414 |      - |     520 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamFullQuery   | .NET 8.0  | MediatR            | StreamFullQuery   |  1,006.445 ns |   2.6304 ns | 0.2537 |      - |    3192 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamFullQuery   | .NET 10.0 | MediatR            | StreamFullQuery   |    748.754 ns |   4.2762 ns | 0.2537 | 0.0010 |    3192 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamFullQuery   | .NET 11.0 | MediatR            | StreamFullQuery   |    739.917 ns |   2.6471 ns | 0.2537 | 0.0010 |    3192 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamQuery       | .NET 8.0  | MediatR            | StreamQuery       |    307.311 ns |   0.9878 ns | 0.0572 |      - |     720 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamQuery       | .NET 10.0 | MediatR            | StreamQuery       |    200.395 ns |   0.7343 ns | 0.0534 |      - |     672 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamQuery       | .NET 11.0 | MediatR            | StreamQuery       |    183.208 ns |   0.7787 ns | 0.0534 |      - |     672 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 8.0  | MediatorNet        | CascadingMessages |     50.640 ns |   0.1873 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 10.0 | MediatorNet        | CascadingMessages |     40.951 ns |   0.1075 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 11.0 | MediatorNet        | CascadingMessages |     37.743 ns |   0.1417 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 8.0  | MediatorNet        | Command           |     25.606 ns |   0.2394 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 10.0 | MediatorNet        | Command           |     19.528 ns |   0.0266 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 11.0 | MediatorNet        | Command           |      9.098 ns |   0.0192 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 8.0  | MediatorNet        | FullQuery         |     90.723 ns |   0.2096 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 10.0 | MediatorNet        | FullQuery         |     87.997 ns |   0.3197 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 11.0 | MediatorNet        | FullQuery         |     55.962 ns |   0.1319 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 8.0  | MediatorNet        | Publish           |     28.716 ns |   0.0390 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 10.0 | MediatorNet        | Publish           |     22.765 ns |   0.0427 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 11.0 | MediatorNet        | Publish           |     21.667 ns |   0.1043 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 8.0  | MediatorNet        | Query             |     27.075 ns |   0.0900 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 10.0 | MediatorNet        | Query             |     23.371 ns |   0.0812 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 11.0 | MediatorNet        | Query             |     13.558 ns |   0.0619 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 8.0  | MediatorNet        | ShortCircuit      |     31.164 ns |   0.1878 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 10.0 | MediatorNet        | ShortCircuit      |     22.480 ns |   0.0307 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 11.0 | MediatorNet        | ShortCircuit      |     14.001 ns |   0.2639 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamFullQuery   | .NET 8.0  | MediatorNet        | StreamFullQuery   |    659.834 ns |   8.2812 ns | 0.1841 |      - |    2320 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamFullQuery   | .NET 10.0 | MediatorNet        | StreamFullQuery   |    482.483 ns |   9.5279 ns | 0.1841 |      - |    2320 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamFullQuery   | .NET 11.0 | MediatorNet        | StreamFullQuery   |    495.623 ns |   9.7444 ns | 0.1841 |      - |    2320 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamQuery       | .NET 8.0  | MediatorNet        | StreamQuery       |    122.804 ns |   1.1109 ns | 0.0222 |      - |     280 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamQuery       | .NET 10.0 | MediatorNet        | StreamQuery       |     88.373 ns |   0.2724 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamQuery       | .NET 11.0 | MediatorNet        | StreamQuery       |     74.578 ns |   0.2360 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | CascadingMessages | .NET 10.0 | Wolverine          | CascadingMessages |  3,441.256 ns |  17.3145 ns | 0.2785 |      - |    3504 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | CascadingMessages | .NET 11.0 | Wolverine          | CascadingMessages |  3,026.436 ns |  10.9458 ns | 0.2747 |      - |    3480 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Command           | .NET 10.0 | Wolverine          | Command           |    225.974 ns |   1.2428 ns |      - |      - |         - |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Command           | .NET 11.0 | Wolverine          | Command           |    219.062 ns |   0.4195 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | FullQuery         | .NET 10.0 | Wolverine          | FullQuery         |    306.139 ns |   1.3444 ns | 0.0086 |      - |     112 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | FullQuery         | .NET 11.0 | Wolverine          | FullQuery         |    298.520 ns |   1.8852 ns | 0.0105 |      - |     136 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Publish           | .NET 10.0 | Wolverine          | Publish           |  2,971.445 ns |  12.9041 ns | 0.2365 |      - |    2992 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Publish           | .NET 11.0 | Wolverine          | Publish           |  2,505.018 ns |   6.9999 ns | 0.2365 |      - |    2968 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Query             | .NET 10.0 | Wolverine          | Query             |    271.107 ns |   0.9637 ns | 0.0086 |      - |     112 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Query             | .NET 11.0 | Wolverine          | Query             |    268.893 ns |   0.4720 ns | 0.0086 |      - |     112 B |
|                                      |                             |                   |           |                    |                   |               |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | ShortCircuit      | .NET 10.0 | Wolverine          | ShortCircuit      |    255.351 ns |   0.7989 ns |      - |      - |         - |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | ShortCircuit      | .NET 11.0 | Wolverine          | ShortCircuit      |    248.718 ns |   0.5467 ns |      - |      - |         - |
