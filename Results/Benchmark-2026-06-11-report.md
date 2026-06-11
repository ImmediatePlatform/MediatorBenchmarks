```

BenchmarkDotNet v0.16.0-nightly.20260608.560, Windows 11 (10.0.26200.8655/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12700H 2.30GHz, 1 CPU, 20 logical and 14 physical cores
Memory: 31.69 GB Total, 21.22 GB Available
.NET SDK 11.0.100-preview.5.26302.115
  [Host]     : .NET 11.0.0 (11.0.0-preview.5.26302.115, 11.0.26.30315), X64 RyuJIT x86-64-v3
  Job-GVKUBM : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  Job-IHFIKV : .NET 11.0.0 (11.0.0-preview.5.26302.115, 11.0.26.30315), X64 RyuJIT x86-64-v3
  Job-AZESIF : .NET 8.0.28 (8.0.28, 8.0.2826.26413), X64 RyuJIT x86-64-v3


```
| Namespace                            | Type                        | Method            | Runtime   | Implementation     | Scenario           | Mean           | Error       | Gen0   | Gen1   | Allocated |
|------------------------------------- |---------------------------- |------------------ |---------- |------------------- |------------------- |---------------:|------------:|-------:|-------:|----------:|
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Command           | .NET 10.0 | Axent              | InvokeAsync        |     49.4968 ns |   0.1899 ns | 0.0063 |      - |      80 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Command           | .NET 11.0 | Axent              | InvokeAsync        |     44.2312 ns |   0.1712 ns | 0.0063 |      - |      80 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Query             | .NET 10.0 | Axent              | InvokeAsyncT       |     70.1983 ns |   0.4146 ns | 0.0082 |      - |     104 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Query             | .NET 11.0 | Axent              | InvokeAsyncT       |     63.1785 ns |   0.1873 ns | 0.0082 |      - |     104 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | FullQuery         | .NET 10.0 | Axent              | InvokeAsyncTWithDI |    104.8694 ns |   0.2756 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | FullQuery         | .NET 11.0 | Axent              | InvokeAsyncTWithDI |     84.3546 ns |   0.3107 ns | 0.0076 |      - |      96 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | ShortCircuit      | .NET 10.0 | Axent              | ShortCircuit       |     47.5306 ns |   0.1028 ns | 0.0044 |      - |      56 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | ShortCircuit      | .NET 11.0 | Axent              | ShortCircuit       |     40.5440 ns |   0.1578 ns | 0.0044 |      - |      56 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 8.0  | Direct             | CascadingMessages  |     58.1106 ns |   0.4098 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 10.0 | Direct             | CascadingMessages  |     52.8789 ns |   0.0967 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 11.0 | Direct             | CascadingMessages  |     24.8585 ns |   0.0858 ns | 0.0057 |      - |      72 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 8.0  | Direct             | InvokeAsync        |     12.4526 ns |   0.0194 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 10.0 | Direct             | InvokeAsync        |     11.0386 ns |   0.0144 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 11.0 | Direct             | InvokeAsync        |      0.9767 ns |   0.0065 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 8.0  | Direct             | InvokeAsyncT       |     38.9293 ns |   0.1961 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 10.0 | Direct             | InvokeAsyncT       |     34.8730 ns |   0.1217 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 11.0 | Direct             | InvokeAsyncT       |     22.8746 ns |   0.0713 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 8.0  | Direct             | InvokeAsyncTWithDI |     66.4078 ns |   0.0905 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 10.0 | Direct             | InvokeAsyncTWithDI |     55.4447 ns |   0.0688 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 11.0 | Direct             | InvokeAsyncTWithDI |     32.8809 ns |   0.0889 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 8.0  | Direct             | Publish            |     15.2466 ns |   0.2016 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 10.0 | Direct             | Publish            |     12.6224 ns |   0.0579 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 11.0 | Direct             | Publish            |      0.8648 ns |   0.0023 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 8.0  | Direct             | ShortCircuit       |     10.3075 ns |   0.0140 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 10.0 | Direct             | ShortCircuit       |      9.3309 ns |   0.0126 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 11.0 | Direct             | ShortCircuit       |      1.9303 ns |   0.0025 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 8.0  | DispatchR          | CascadingMessages  |    110.6940 ns |   0.2169 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 10.0 | DispatchR          | CascadingMessages  |     92.3714 ns |   0.2017 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 11.0 | DispatchR          | CascadingMessages  |     88.1776 ns |   0.1799 ns | 0.0057 |      - |      72 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 8.0  | DispatchR          | InvokeAsync        |     31.0833 ns |   0.0437 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 10.0 | DispatchR          | InvokeAsync        |     24.9727 ns |   0.0467 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 11.0 | DispatchR          | InvokeAsync        |     20.6877 ns |   0.0292 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 8.0  | DispatchR          | InvokeAsyncT       |     62.7717 ns |   0.7294 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 10.0 | DispatchR          | InvokeAsyncT       |     55.2636 ns |   0.1499 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 11.0 | DispatchR          | InvokeAsyncT       |     47.7985 ns |   0.1209 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 8.0  | DispatchR          | InvokeAsyncTWithDI |    100.4978 ns |   0.2678 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 10.0 | DispatchR          | InvokeAsyncTWithDI |     85.2193 ns |   0.1666 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 11.0 | DispatchR          | InvokeAsyncTWithDI |     73.2588 ns |   0.2354 ns | 0.0031 |      - |      40 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 8.0  | DispatchR          | Publish            |     44.7954 ns |   0.0968 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 10.0 | DispatchR          | Publish            |     36.1721 ns |   0.0403 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 11.0 | DispatchR          | Publish            |     35.5907 ns |   0.0580 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 8.0  | DispatchR          | ShortCircuit       |     37.4888 ns |   0.1336 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 10.0 | DispatchR          | ShortCircuit       |     25.8809 ns |   0.0238 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 11.0 | DispatchR          | ShortCircuit       |     21.7858 ns |   0.0277 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 8.0  | Foundatio.Mediator | CascadingMessages  |    153.6728 ns |   0.3311 ns | 0.0114 |      - |     144 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 10.0 | Foundatio.Mediator | CascadingMessages  |    107.6519 ns |   0.3547 ns | 0.0114 |      - |     144 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 11.0 | Foundatio.Mediator | CascadingMessages  |     85.1638 ns |   0.3029 ns | 0.0114 |      - |     144 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 8.0  | Foundatio.Mediator | InvokeAsync        |     35.3970 ns |   0.0950 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 10.0 | Foundatio.Mediator | InvokeAsync        |     21.5751 ns |   0.0820 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 11.0 | Foundatio.Mediator | InvokeAsync        |     14.0770 ns |   0.0608 ns | 0.0019 |      - |      24 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 8.0  | Foundatio.Mediator | InvokeAsyncT       |     66.1105 ns |   0.1704 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 10.0 | Foundatio.Mediator | InvokeAsyncT       |     51.8124 ns |   0.1765 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 11.0 | Foundatio.Mediator | InvokeAsyncT       |     40.9700 ns |   0.0764 ns | 0.0057 |      - |      72 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 8.0  | Foundatio.Mediator | InvokeAsyncTWithDI |    107.2938 ns |   0.3204 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 10.0 | Foundatio.Mediator | InvokeAsyncTWithDI |     76.3686 ns |   0.1102 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 11.0 | Foundatio.Mediator | InvokeAsyncTWithDI |     59.6983 ns |   0.1802 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 8.0  | Foundatio.Mediator | Publish            |     83.8457 ns |   0.1892 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 10.0 | Foundatio.Mediator | Publish            |     57.5876 ns |   0.2908 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 11.0 | Foundatio.Mediator | Publish            |     41.2088 ns |   0.5446 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 8.0  | Foundatio.Mediator | ShortCircuit       |     46.4684 ns |   0.3495 ns |      - |      - |         - |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 10.0 | Foundatio.Mediator | ShortCircuit       |     33.0044 ns |   0.1060 ns |      - |      - |         - |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 11.0 | Foundatio.Mediator | ShortCircuit       |     13.5113 ns |   0.0164 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 8.0  | Immediate.Handlers | CascadingMessages  |    120.4262 ns |   0.2771 ns | 0.0081 |      - |     104 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 10.0 | Immediate.Handlers | CascadingMessages  |    108.3376 ns |   0.2182 ns | 0.0082 |      - |     104 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 11.0 | Immediate.Handlers | CascadingMessages  |     60.8781 ns |   0.2760 ns | 0.0082 |      - |     104 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 8.0  | Immediate.Handlers | InvokeAsync        |     23.8084 ns |   0.0226 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 10.0 | Immediate.Handlers | InvokeAsync        |     19.7731 ns |   0.0208 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 11.0 | Immediate.Handlers | InvokeAsync        |      2.3605 ns |   0.0022 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 8.0  | Immediate.Handlers | InvokeAsyncT       |     47.4652 ns |   0.2234 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 10.0 | Immediate.Handlers | InvokeAsyncT       |     42.7614 ns |   0.1194 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 11.0 | Immediate.Handlers | InvokeAsyncT       |     24.1921 ns |   0.0680 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 8.0  | Immediate.Handlers | InvokeAsyncTWithDI |     86.4343 ns |   0.1495 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 10.0 | Immediate.Handlers | InvokeAsyncTWithDI |     70.1635 ns |   0.1550 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 11.0 | Immediate.Handlers | InvokeAsyncTWithDI |     48.4441 ns |   0.1384 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 8.0  | Immediate.Handlers | Publish            |     68.0646 ns |   0.1960 ns | 0.0025 |      - |      32 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 10.0 | Immediate.Handlers | Publish            |     58.4185 ns |   0.1374 ns | 0.0025 |      - |      32 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 11.0 | Immediate.Handlers | Publish            |     25.5478 ns |   0.0667 ns | 0.0025 |      - |      32 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 8.0  | Immediate.Handlers | ShortCircuit       |     19.7860 ns |   0.1140 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 10.0 | Immediate.Handlers | ShortCircuit       |     19.3960 ns |   0.1104 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 11.0 | Immediate.Handlers | ShortCircuit       |      2.5728 ns |   0.0034 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 8.0  | MassTransit        | CascadingMessages  | 34,179.7782 ns | 160.0169 ns | 1.7090 | 0.0610 |   21680 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 10.0 | MassTransit        | CascadingMessages  | 28,631.1624 ns | 186.5853 ns | 1.6785 | 0.0610 |   21184 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 11.0 | MassTransit        | CascadingMessages  | 33,409.3908 ns | 654.6435 ns | 1.6479 | 0.0610 |   21032 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 8.0  | MassTransit        | InvokeAsync        |  2,390.1137 ns |   9.0012 ns | 0.3967 |      - |    5024 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 10.0 | MassTransit        | InvokeAsync        |  1,963.8265 ns |   9.0492 ns | 0.3929 | 0.0038 |    4960 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 11.0 | MassTransit        | InvokeAsync        |  2,158.9541 ns |   7.7517 ns | 0.3929 | 0.0038 |    4960 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 8.0  | MassTransit        | InvokeAsyncT       | 25,324.5213 ns | 138.5639 ns | 1.0681 | 0.0305 |   13696 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 10.0 | MassTransit        | InvokeAsyncT       | 22,074.7304 ns | 144.3110 ns | 1.0681 | 0.0305 |   13384 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 11.0 | MassTransit        | InvokeAsyncT       | 24,588.7679 ns | 198.5065 ns | 1.0376 | 0.0305 |   13232 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 8.0  | MassTransit        | InvokeAsyncTWithDI | 25,257.1865 ns | 204.6795 ns | 1.0681 |      - |   13648 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 10.0 | MassTransit        | InvokeAsyncTWithDI | 21,917.4929 ns |  92.1305 ns | 1.0681 | 0.0305 |   13336 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 11.0 | MassTransit        | InvokeAsyncTWithDI | 22,981.4296 ns | 212.5936 ns | 1.0376 | 0.0305 |   13184 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 8.0  | MassTransit        | Publish            |  3,974.6792 ns |  17.2035 ns | 0.6104 |      - |    7680 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 10.0 | MassTransit        | Publish            |  3,613.7470 ns |  29.4509 ns | 0.5989 | 0.0038 |    7552 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 11.0 | MassTransit        | Publish            |  3,612.9449 ns |  21.2357 ns | 0.5989 | 0.0038 |    7552 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 8.0  | MassTransit        | ShortCircuit       | 24,074.0455 ns | 209.7034 ns | 1.0071 | 0.0305 |   12779 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 10.0 | MassTransit        | ShortCircuit       | 21,152.6270 ns | 216.9915 ns | 0.9766 | 0.0305 |   12464 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 11.0 | MassTransit        | ShortCircuit       | 22,642.3898 ns | 306.5777 ns | 0.9766 |      - |   12312 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 8.0  | MediatR            | CascadingMessages  |    226.0501 ns |   0.6083 ns | 0.0682 |      - |     856 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 10.0 | MediatR            | CascadingMessages  |    164.4783 ns |   0.4863 ns | 0.0591 |      - |     744 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 11.0 | MediatR            | CascadingMessages  |    163.5033 ns |   0.6478 ns | 0.0591 |      - |     744 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 8.0  | MediatR            | InvokeAsync        |     83.1248 ns |   0.4600 ns | 0.0191 |      - |     240 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 10.0 | MediatR            | InvokeAsync        |     48.6296 ns |   0.1705 ns | 0.0102 |      - |     128 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 11.0 | MediatR            | InvokeAsync        |     49.6130 ns |   0.2401 ns | 0.0102 |      - |     128 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 8.0  | MediatR            | InvokeAsyncT       |    117.2066 ns |   0.8782 ns | 0.0286 |      - |     360 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 10.0 | MediatR            | InvokeAsyncT       |     78.9934 ns |   1.1083 ns | 0.0197 |      - |     248 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 11.0 | MediatR            | InvokeAsyncT       |     74.2955 ns |   0.9705 ns | 0.0197 |      - |     248 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 8.0  | MediatR            | InvokeAsyncTWithDI |    202.3821 ns |   1.9804 ns | 0.0489 |      - |     616 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 10.0 | MediatR            | InvokeAsyncTWithDI |    160.1263 ns |   3.1278 ns | 0.0439 |      - |     552 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 11.0 | MediatR            | InvokeAsyncTWithDI |    143.0193 ns |   0.8873 ns | 0.0439 |      - |     552 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 8.0  | MediatR            | Publish            |    101.0635 ns |   1.5691 ns | 0.0350 |      - |     440 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 10.0 | MediatR            | Publish            |     79.1676 ns |   0.3520 ns | 0.0350 |      - |     440 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 11.0 | MediatR            | Publish            |     77.5823 ns |   0.3470 ns | 0.0350 |      - |     440 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 8.0  | MediatR            | ShortCircuit       |    126.3838 ns |   0.5646 ns | 0.0420 |      - |     528 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 10.0 | MediatR            | ShortCircuit       |    105.3672 ns |   0.4414 ns | 0.0370 |      - |     464 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 11.0 | MediatR            | ShortCircuit       |     98.9715 ns |   1.7678 ns | 0.0370 |      - |     464 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 8.0  | MediatorNet        | CascadingMessages  |     73.1405 ns |   0.1604 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 10.0 | MediatorNet        | CascadingMessages  |     61.7238 ns |   0.1368 ns | 0.0057 |      - |      72 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 11.0 | MediatorNet        | CascadingMessages  |     54.7335 ns |   0.8385 ns | 0.0057 |      - |      72 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 8.0  | MediatorNet        | InvokeAsync        |     25.9841 ns |   0.0936 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 10.0 | MediatorNet        | InvokeAsync        |     19.7084 ns |   0.0160 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 11.0 | MediatorNet        | InvokeAsync        |     12.5804 ns |   0.0454 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 8.0  | MediatorNet        | InvokeAsyncT       |     46.7121 ns |   0.1361 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 10.0 | MediatorNet        | InvokeAsyncT       |     45.8028 ns |   0.1735 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 11.0 | MediatorNet        | InvokeAsyncT       |     37.3381 ns |   0.0689 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 8.0  | MediatorNet        | InvokeAsyncTWithDI |     91.0765 ns |   0.5952 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 10.0 | MediatorNet        | InvokeAsyncTWithDI |     74.5113 ns |   0.1891 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 11.0 | MediatorNet        | InvokeAsyncTWithDI |     61.1463 ns |   0.1275 ns | 0.0031 |      - |      40 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 8.0  | MediatorNet        | Publish            |     28.9393 ns |   0.3389 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 10.0 | MediatorNet        | Publish            |     23.3568 ns |   0.0232 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 11.0 | MediatorNet        | Publish            |     16.1522 ns |   0.0136 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 8.0  | MediatorNet        | ShortCircuit       |     28.3680 ns |   0.5101 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 10.0 | MediatorNet        | ShortCircuit       |     22.7357 ns |   0.0232 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 11.0 | MediatorNet        | ShortCircuit       |     15.6651 ns |   0.0191 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | CascadingMessages | .NET 10.0 | Wolverine          | CascadingMessages  |  3,424.0053 ns |  15.1475 ns | 0.2785 |      - |    3512 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | CascadingMessages | .NET 11.0 | Wolverine          | CascadingMessages  |  3,432.3220 ns |  19.2612 ns | 0.2747 |      - |    3488 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Command           | .NET 10.0 | Wolverine          | InvokeAsync        |    223.0538 ns |   0.2401 ns |      - |      - |         - |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Command           | .NET 11.0 | Wolverine          | InvokeAsync        |    218.0333 ns |   0.2592 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Query             | .NET 10.0 | Wolverine          | InvokeAsyncT       |    294.1991 ns |   1.4157 ns | 0.0095 |      - |     120 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Query             | .NET 11.0 | Wolverine          | InvokeAsyncT       |    282.4079 ns |   0.6235 ns | 0.0095 |      - |     120 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | FullQuery         | .NET 10.0 | Wolverine          | InvokeAsyncTWithDI |    308.5159 ns |   1.0533 ns | 0.0086 |      - |     112 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | FullQuery         | .NET 11.0 | Wolverine          | InvokeAsyncTWithDI |    310.9998 ns |   4.4980 ns | 0.0105 |      - |     136 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Publish           | .NET 10.0 | Wolverine          | Publish            |  2,876.9418 ns |  11.5697 ns | 0.2365 |      - |    2992 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Publish           | .NET 11.0 | Wolverine          | Publish            |  2,824.7569 ns |  10.6094 ns | 0.2365 |      - |    2968 B |
|                                      |                             |                   |           |                    |                    |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | ShortCircuit      | .NET 10.0 | Wolverine          | ShortCircuit       |    261.3427 ns |   0.2846 ns |      - |      - |         - |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | ShortCircuit      | .NET 11.0 | Wolverine          | ShortCircuit       |    245.6313 ns |   0.8924 ns |      - |      - |         - |
