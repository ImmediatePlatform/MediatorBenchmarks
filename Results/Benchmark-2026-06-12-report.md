```

BenchmarkDotNet v0.16.0-nightly.20260608.560, Windows 11 (10.0.26200.8655/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12700H 2.30GHz, 1 CPU, 20 logical and 14 physical cores
Memory: 31.69 GB Total, 20.83 GB Available
.NET SDK 11.0.100-preview.5.26302.115
  [Host]     : .NET 11.0.0 (11.0.0-preview.5.26302.115, 11.0.26.30315), X64 RyuJIT x86-64-v3
  Job-GVKUBM : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  Job-IHFIKV : .NET 11.0.0 (11.0.0-preview.5.26302.115, 11.0.26.30315), X64 RyuJIT x86-64-v3
  Job-AZESIF : .NET 8.0.28 (8.0.28, 8.0.2826.26413), X64 RyuJIT x86-64-v3


```
| Namespace                            | Type                        | Method            | Runtime   | Implementation     | Scenario          | Mean           | Error       | Gen0   | Gen1   | Allocated |
|------------------------------------- |---------------------------- |------------------ |---------- |------------------- |------------------ |---------------:|------------:|-------:|-------:|----------:|
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Command           | .NET 10.0 | Axent              | Command           |     49.1420 ns |   0.1869 ns | 0.0063 |      - |      80 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Command           | .NET 11.0 | Axent              | Command           |     48.3025 ns |   0.0896 ns | 0.0063 |      - |      80 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | FullQuery         | .NET 10.0 | Axent              | FullQuery         |    107.4147 ns |   0.1739 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | FullQuery         | .NET 11.0 | Axent              | FullQuery         |     85.9661 ns |   0.3084 ns | 0.0076 |      - |      96 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Query             | .NET 10.0 | Axent              | Query             |     50.4124 ns |   0.1269 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | Query             | .NET 11.0 | Axent              | Query             |     41.3548 ns |   0.1094 ns | 0.0076 |      - |      96 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | ShortCircuit      | .NET 10.0 | Axent              | ShortCircuit      |     48.3484 ns |   0.1242 ns | 0.0044 |      - |      56 B |
| MediatorBenchmarks.Axent             | AxentBenchmarks             | ShortCircuit      | .NET 11.0 | Axent              | ShortCircuit      |     41.0761 ns |   0.1047 ns | 0.0044 |      - |      56 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 8.0  | Direct             | CascadingMessages |     39.8320 ns |   0.1596 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 10.0 | Direct             | CascadingMessages |     35.3686 ns |   0.1625 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | CascadingMessages | .NET 11.0 | Direct             | CascadingMessages |      5.8421 ns |   0.0738 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 8.0  | Direct             | Command           |     12.2734 ns |   0.0854 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 10.0 | Direct             | Command           |     10.8577 ns |   0.0328 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Command           | .NET 11.0 | Direct             | Command           |      0.8913 ns |   0.0047 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 8.0  | Direct             | FullQuery         |     66.5418 ns |   0.0933 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 10.0 | Direct             | FullQuery         |     55.4707 ns |   0.0804 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | FullQuery         | .NET 11.0 | Direct             | FullQuery         |     32.8281 ns |   0.0962 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 8.0  | Direct             | Publish           |     15.4391 ns |   0.0201 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 10.0 | Direct             | Publish           |     12.7826 ns |   0.0322 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Publish           | .NET 11.0 | Direct             | Publish           |      0.8637 ns |   0.0018 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 8.0  | Direct             | Query             |     17.7846 ns |   0.0430 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 10.0 | Direct             | Query             |     15.8479 ns |   0.0701 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | Query             | .NET 11.0 | Direct             | Query             |      3.9220 ns |   0.0394 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 8.0  | Direct             | ShortCircuit      |     10.2993 ns |   0.0154 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 10.0 | Direct             | ShortCircuit      |      9.8658 ns |   0.0124 ns |      - |      - |         - |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | ShortCircuit      | .NET 11.0 | Direct             | ShortCircuit      |      1.7187 ns |   0.0032 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamFullQuery   | .NET 8.0  | Direct             | StreamFullQuery   |    626.7863 ns |   3.7952 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamFullQuery   | .NET 10.0 | Direct             | StreamFullQuery   |    453.9694 ns |   1.5513 ns | 0.1836 |      - |    2304 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamFullQuery   | .NET 11.0 | Direct             | StreamFullQuery   |    454.8064 ns |   3.4129 ns | 0.1836 |      - |    2304 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamQuery       | .NET 8.0  | Direct             | StreamQuery       |    114.3680 ns |   0.3675 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamQuery       | .NET 10.0 | Direct             | StreamQuery       |     84.9115 ns |   0.3397 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.Direct            | DirectBenchmarks            | StreamQuery       | .NET 11.0 | Direct             | StreamQuery       |     77.4905 ns |   0.1876 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 8.0  | DispatchR          | CascadingMessages |     84.4434 ns |   0.1117 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 10.0 | DispatchR          | CascadingMessages |     73.1946 ns |   0.1675 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | CascadingMessages | .NET 11.0 | DispatchR          | CascadingMessages |     60.6371 ns |   0.1699 ns | 0.0050 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 8.0  | DispatchR          | Command           |     31.0634 ns |   0.1804 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 10.0 | DispatchR          | Command           |     25.3559 ns |   0.0266 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Command           | .NET 11.0 | DispatchR          | Command           |     20.6377 ns |   0.0212 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 8.0  | DispatchR          | FullQuery         |    102.8795 ns |   0.4040 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 10.0 | DispatchR          | FullQuery         |     86.0328 ns |   0.0609 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | FullQuery         | .NET 11.0 | DispatchR          | FullQuery         |     73.7650 ns |   0.2198 ns | 0.0031 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 8.0  | DispatchR          | Publish           |     44.9109 ns |   0.0694 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 10.0 | DispatchR          | Publish           |     35.9500 ns |   0.0489 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Publish           | .NET 11.0 | DispatchR          | Publish           |     35.4662 ns |   0.0430 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 8.0  | DispatchR          | Query             |     42.5243 ns |   0.0852 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 10.0 | DispatchR          | Query             |     28.8886 ns |   0.0911 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | Query             | .NET 11.0 | DispatchR          | Query             |     23.7205 ns |   0.0987 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 8.0  | DispatchR          | ShortCircuit      |     40.9260 ns |   0.1629 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 10.0 | DispatchR          | ShortCircuit      |     25.8846 ns |   0.0326 ns |      - |      - |         - |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | ShortCircuit      | .NET 11.0 | DispatchR          | ShortCircuit      |     24.0045 ns |   0.0350 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamFullQuery   | .NET 8.0  | DispatchR          | StreamFullQuery   |    636.0566 ns |   2.8919 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamFullQuery   | .NET 10.0 | DispatchR          | StreamFullQuery   |    480.4173 ns |   1.8791 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamFullQuery   | .NET 11.0 | DispatchR          | StreamFullQuery   |    472.6274 ns |   2.4524 ns | 0.1836 |      - |    2304 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamQuery       | .NET 8.0  | DispatchR          | StreamQuery       |    125.7593 ns |   0.4567 ns | 0.0222 |      - |     280 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamQuery       | .NET 10.0 | DispatchR          | StreamQuery       |     92.3404 ns |   0.2778 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.DispatchR         | DispatchRBenchmarks         | StreamQuery       | .NET 11.0 | DispatchR          | StreamQuery       |     86.6465 ns |   0.2914 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 8.0  | Foundatio.Mediator | CascadingMessages |    133.6306 ns |   0.3465 ns | 0.0107 |      - |     136 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 10.0 | Foundatio.Mediator | CascadingMessages |     88.9955 ns |   0.2322 ns | 0.0107 |      - |     136 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | CascadingMessages | .NET 11.0 | Foundatio.Mediator | CascadingMessages |     62.8053 ns |   0.1402 ns | 0.0107 |      - |     136 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 8.0  | Foundatio.Mediator | Command           |     35.8654 ns |   0.1946 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 10.0 | Foundatio.Mediator | Command           |     21.9193 ns |   0.0335 ns | 0.0019 |      - |      24 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Command           | .NET 11.0 | Foundatio.Mediator | Command           |     13.8849 ns |   0.0376 ns | 0.0019 |      - |      24 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 8.0  | Foundatio.Mediator | FullQuery         |     95.4581 ns |   0.2059 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 10.0 | Foundatio.Mediator | FullQuery         |     75.0697 ns |   0.2343 ns | 0.0050 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | FullQuery         | .NET 11.0 | Foundatio.Mediator | FullQuery         |     58.4594 ns |   0.1296 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 8.0  | Foundatio.Mediator | Publish           |     81.4508 ns |   0.1402 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 10.0 | Foundatio.Mediator | Publish           |     55.3340 ns |   0.1084 ns | 0.0038 |      - |      48 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Publish           | .NET 11.0 | Foundatio.Mediator | Publish           |     40.0227 ns |   0.1340 ns | 0.0038 |      - |      48 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 8.0  | Foundatio.Mediator | Query             |     44.5580 ns |   0.1582 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 10.0 | Foundatio.Mediator | Query             |     28.7465 ns |   0.1854 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | Query             | .NET 11.0 | Foundatio.Mediator | Query             |     19.3691 ns |   0.0578 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 8.0  | Foundatio.Mediator | ShortCircuit      |     47.3451 ns |   0.0830 ns |      - |      - |         - |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 10.0 | Foundatio.Mediator | ShortCircuit      |     33.5424 ns |   0.0267 ns |      - |      - |         - |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | ShortCircuit      | .NET 11.0 | Foundatio.Mediator | ShortCircuit      |     14.3823 ns |   0.0111 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | StreamQuery       | .NET 8.0  | Foundatio.Mediator | StreamQuery       |    135.9143 ns |   0.4524 ns | 0.0241 |      - |     304 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | StreamQuery       | .NET 10.0 | Foundatio.Mediator | StreamQuery       |     95.0486 ns |   0.2442 ns | 0.0242 |      - |     304 B |
| MediatorBenchmarks.FoundatioMediator | FoundatioMediatorBenchmarks | StreamQuery       | .NET 11.0 | Foundatio.Mediator | StreamQuery       |     90.5388 ns |   0.4184 ns | 0.0242 |      - |     304 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 8.0  | Immediate.Handlers | CascadingMessages |    105.2750 ns |   1.8969 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 10.0 | Immediate.Handlers | CascadingMessages |     89.5246 ns |   0.1422 ns | 0.0076 |      - |      96 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | CascadingMessages | .NET 11.0 | Immediate.Handlers | CascadingMessages |     31.8675 ns |   0.0820 ns | 0.0076 |      - |      96 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 8.0  | Immediate.Handlers | Command           |     23.7965 ns |   0.0224 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 10.0 | Immediate.Handlers | Command           |     19.9847 ns |   0.0535 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Command           | .NET 11.0 | Immediate.Handlers | Command           |      2.3663 ns |   0.0070 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 8.0  | Immediate.Handlers | FullQuery         |     86.3371 ns |   0.1699 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 10.0 | Immediate.Handlers | FullQuery         |     70.1609 ns |   0.1495 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | FullQuery         | .NET 11.0 | Immediate.Handlers | FullQuery         |     49.1216 ns |   0.0836 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 8.0  | Immediate.Handlers | Publish           |     69.0696 ns |   0.1804 ns | 0.0025 |      - |      32 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 10.0 | Immediate.Handlers | Publish           |     58.7742 ns |   0.1349 ns | 0.0025 |      - |      32 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Publish           | .NET 11.0 | Immediate.Handlers | Publish           |     24.5702 ns |   0.0622 ns | 0.0025 |      - |      32 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 8.0  | Immediate.Handlers | Query             |     28.2674 ns |   0.1325 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 10.0 | Immediate.Handlers | Query             |     24.4531 ns |   0.0734 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | Query             | .NET 11.0 | Immediate.Handlers | Query             |      5.4128 ns |   0.0297 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 8.0  | Immediate.Handlers | ShortCircuit      |     20.2212 ns |   0.1601 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 10.0 | Immediate.Handlers | ShortCircuit      |     17.4089 ns |   0.0835 ns |      - |      - |         - |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | ShortCircuit      | .NET 11.0 | Immediate.Handlers | ShortCircuit      |      2.5840 ns |   0.0079 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamFullQuery   | .NET 8.0  | Immediate.Handlers | StreamFullQuery   |    609.2202 ns |   2.0695 ns | 0.1831 |      - |    2304 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamFullQuery   | .NET 10.0 | Immediate.Handlers | StreamFullQuery   |    454.9529 ns |   1.9908 ns | 0.1836 |      - |    2304 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamFullQuery   | .NET 11.0 | Immediate.Handlers | StreamFullQuery   |    445.4019 ns |   1.9986 ns | 0.1836 |      - |    2304 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamQuery       | .NET 8.0  | Immediate.Handlers | StreamQuery       |    114.5073 ns |   0.4439 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamQuery       | .NET 10.0 | Immediate.Handlers | StreamQuery       |     84.6430 ns |   0.3048 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.ImmediateHandlers | ImmediateHandlersBenchmarks | StreamQuery       | .NET 11.0 | Immediate.Handlers | StreamQuery       |     76.7229 ns |   0.2335 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 8.0  | MassTransit        | CascadingMessages | 33,358.1136 ns | 206.9068 ns | 1.7090 |      - |   21648 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 10.0 | MassTransit        | CascadingMessages | 28,555.4146 ns | 331.1506 ns | 1.6785 | 0.0610 |   21152 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | CascadingMessages | .NET 11.0 | MassTransit        | CascadingMessages | 29,193.9793 ns | 560.5411 ns | 1.6785 | 0.0305 |   21000 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 8.0  | MassTransit        | Command           |  2,399.2274 ns |  10.5144 ns | 0.3967 |      - |    5016 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 10.0 | MassTransit        | Command           |  2,052.6778 ns |  10.4202 ns | 0.3929 | 0.0038 |    4952 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Command           | .NET 11.0 | MassTransit        | Command           |  2,065.6602 ns |  12.4072 ns | 0.3929 | 0.0038 |    4952 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 8.0  | MassTransit        | FullQuery         | 25,342.0927 ns | 164.9007 ns | 1.0681 |      - |   13640 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 10.0 | MassTransit        | FullQuery         | 22,420.4840 ns | 177.9018 ns | 1.0681 | 0.0305 |   13328 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | FullQuery         | .NET 11.0 | MassTransit        | FullQuery         | 21,875.0205 ns |  95.1232 ns | 1.0376 | 0.0305 |   13176 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 8.0  | MassTransit        | Publish           |  4,006.2997 ns |  21.5646 ns | 0.6104 | 0.0076 |    7664 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 10.0 | MassTransit        | Publish           |  3,375.2436 ns |  10.6202 ns | 0.5989 | 0.0038 |    7536 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Publish           | .NET 11.0 | MassTransit        | Publish           |  3,588.9461 ns |  16.4362 ns | 0.5989 | 0.0038 |    7536 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 8.0  | MassTransit        | Query             | 24,864.8008 ns | 150.4368 ns | 1.0681 | 0.0305 |   13680 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 10.0 | MassTransit        | Query             | 22,041.8382 ns | 209.6981 ns | 1.0681 | 0.0305 |   13368 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | Query             | .NET 11.0 | MassTransit        | Query             | 23,403.9719 ns | 220.7130 ns | 1.0376 |      - |   13216 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 8.0  | MassTransit        | ShortCircuit      | 23,979.8155 ns |  85.2603 ns | 1.0071 | 0.0305 |   12768 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 10.0 | MassTransit        | ShortCircuit      | 21,112.2673 ns | 119.2957 ns | 0.9766 | 0.0305 |   12456 B |
| MediatorBenchmarks.MassTransit       | MassTransitBenchmarks       | ShortCircuit      | .NET 11.0 | MassTransit        | ShortCircuit      | 22,291.3807 ns | 442.2833 ns | 0.9766 |      - |   12304 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 8.0  | MediatR            | CascadingMessages |    210.0747 ns |   2.1009 ns | 0.0675 |      - |     848 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 10.0 | MediatR            | CascadingMessages |    150.0633 ns |   1.6927 ns | 0.0587 |      - |     736 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | CascadingMessages | .NET 11.0 | MediatR            | CascadingMessages |    147.9493 ns |   1.7843 ns | 0.0587 |      - |     736 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 8.0  | MediatR            | Command           |     92.1236 ns |   0.5704 ns | 0.0191 |      - |     240 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 10.0 | MediatR            | Command           |     49.4646 ns |   0.3138 ns | 0.0102 |      - |     128 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Command           | .NET 11.0 | MediatR            | Command           |     48.4783 ns |   0.2712 ns | 0.0102 |      - |     128 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 8.0  | MediatR            | FullQuery         |    191.7353 ns |   0.5570 ns | 0.0489 |      - |     616 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 10.0 | MediatR            | FullQuery         |    159.3004 ns |   3.1681 ns | 0.0439 |      - |     552 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | FullQuery         | .NET 11.0 | MediatR            | FullQuery         |    134.2790 ns |   0.3905 ns | 0.0439 |      - |     552 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 8.0  | MediatR            | Publish           |     99.5029 ns |   0.7330 ns | 0.0350 |      - |     440 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 10.0 | MediatR            | Publish           |     79.2871 ns |   0.3400 ns | 0.0350 |      - |     440 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Publish           | .NET 11.0 | MediatR            | Publish           |     81.6095 ns |   0.2602 ns | 0.0350 |      - |     440 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 8.0  | MediatR            | Query             |     95.1178 ns |   0.3116 ns | 0.0280 |      - |     352 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 10.0 | MediatR            | Query             |     53.3137 ns |   0.1463 ns | 0.0191 |      - |     240 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | Query             | .NET 11.0 | MediatR            | Query             |     51.5282 ns |   0.7117 ns | 0.0191 |      - |     240 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 8.0  | MediatR            | ShortCircuit      |    111.7461 ns |   1.9707 ns | 0.0414 |      - |     520 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 10.0 | MediatR            | ShortCircuit      |     89.6872 ns |   0.9826 ns | 0.0362 |      - |     456 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | ShortCircuit      | .NET 11.0 | MediatR            | ShortCircuit      |     76.5236 ns |   0.9557 ns | 0.0362 |      - |     456 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamFullQuery   | .NET 8.0  | MediatR            | StreamFullQuery   |  1,062.9633 ns |  13.9835 ns | 0.2537 |      - |    3192 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamFullQuery   | .NET 10.0 | MediatR            | StreamFullQuery   |    804.5307 ns |  10.7250 ns | 0.2537 | 0.0010 |    3192 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamFullQuery   | .NET 11.0 | MediatR            | StreamFullQuery   |    783.9596 ns |   5.0396 ns | 0.2537 | 0.0010 |    3192 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamQuery       | .NET 8.0  | MediatR            | StreamQuery       |    314.7880 ns |   0.6171 ns | 0.0572 |      - |     720 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamQuery       | .NET 10.0 | MediatR            | StreamQuery       |    205.8005 ns |   1.7637 ns | 0.0534 |      - |     672 B |
| MediatorBenchmarks.MediatR           | MediatRBenchmarks           | StreamQuery       | .NET 11.0 | MediatR            | StreamQuery       |    188.1915 ns |   0.6537 ns | 0.0534 |      - |     672 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 8.0  | MediatorNet        | CascadingMessages |     51.1188 ns |   0.1590 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 10.0 | MediatorNet        | CascadingMessages |     40.6005 ns |   0.0763 ns | 0.0051 |      - |      64 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | CascadingMessages | .NET 11.0 | MediatorNet        | CascadingMessages |     31.9343 ns |   0.1182 ns | 0.0051 |      - |      64 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 8.0  | MediatorNet        | Command           |     25.9319 ns |   0.0748 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 10.0 | MediatorNet        | Command           |     19.7220 ns |   0.0242 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Command           | .NET 11.0 | MediatorNet        | Command           |     12.8316 ns |   0.0210 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 8.0  | MediatorNet        | FullQuery         |     90.9546 ns |   0.1524 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 10.0 | MediatorNet        | FullQuery         |     74.5812 ns |   0.1733 ns | 0.0031 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | FullQuery         | .NET 11.0 | MediatorNet        | FullQuery         |     61.7335 ns |   0.1055 ns | 0.0031 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 8.0  | MediatorNet        | Publish           |     28.6194 ns |   0.0985 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 10.0 | MediatorNet        | Publish           |     22.9366 ns |   0.0164 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Publish           | .NET 11.0 | MediatorNet        | Publish           |     16.1837 ns |   0.0178 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 8.0  | MediatorNet        | Query             |     34.3554 ns |   0.0542 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 10.0 | MediatorNet        | Query             |     23.9721 ns |   0.0494 ns | 0.0032 |      - |      40 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | Query             | .NET 11.0 | MediatorNet        | Query             |     20.3519 ns |   0.0629 ns | 0.0032 |      - |      40 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 8.0  | MediatorNet        | ShortCircuit      |     28.5971 ns |   0.0893 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 10.0 | MediatorNet        | ShortCircuit      |     23.3279 ns |   0.0126 ns |      - |      - |         - |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | ShortCircuit      | .NET 11.0 | MediatorNet        | ShortCircuit      |     16.9862 ns |   0.0169 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamFullQuery   | .NET 8.0  | MediatorNet        | StreamFullQuery   |    615.2637 ns |   3.2417 ns | 0.1841 |      - |    2320 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamFullQuery   | .NET 10.0 | MediatorNet        | StreamFullQuery   |    462.0392 ns |   2.7654 ns | 0.1845 |      - |    2320 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamFullQuery   | .NET 11.0 | MediatorNet        | StreamFullQuery   |    490.5667 ns |   5.5761 ns | 0.1841 |      - |    2320 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamQuery       | .NET 8.0  | MediatorNet        | StreamQuery       |    121.6367 ns |   0.4470 ns | 0.0222 |      - |     280 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamQuery       | .NET 10.0 | MediatorNet        | StreamQuery       |     91.7513 ns |   0.5206 ns | 0.0223 |      - |     280 B |
| MediatorBenchmarks.MediatorNet       | MediatorNetBenchmarks       | StreamQuery       | .NET 11.0 | MediatorNet        | StreamQuery       |     79.5899 ns |   0.4275 ns | 0.0223 |      - |     280 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | CascadingMessages | .NET 10.0 | Wolverine          | CascadingMessages |  3,426.3041 ns |  14.3402 ns | 0.2785 |      - |    3504 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | CascadingMessages | .NET 11.0 | Wolverine          | CascadingMessages |  3,389.3636 ns |  19.3061 ns | 0.2747 |      - |    3480 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Command           | .NET 10.0 | Wolverine          | Command           |    224.2265 ns |   0.5015 ns |      - |      - |         - |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Command           | .NET 11.0 | Wolverine          | Command           |    218.0969 ns |   0.3540 ns |      - |      - |         - |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | FullQuery         | .NET 10.0 | Wolverine          | FullQuery         |    305.3459 ns |   0.6878 ns | 0.0086 |      - |     112 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | FullQuery         | .NET 11.0 | Wolverine          | FullQuery         |    290.7497 ns |   0.6389 ns | 0.0105 |      - |     136 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Publish           | .NET 10.0 | Wolverine          | Publish           |  2,887.8301 ns |   9.7817 ns | 0.2365 |      - |    2992 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Publish           | .NET 11.0 | Wolverine          | Publish           |  2,828.5740 ns |   8.8270 ns | 0.2365 |      - |    2968 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Query             | .NET 10.0 | Wolverine          | Query             |    278.9511 ns |   1.6378 ns | 0.0086 |      - |     112 B |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | Query             | .NET 11.0 | Wolverine          | Query             |    257.4971 ns |   0.8702 ns | 0.0086 |      - |     112 B |
|                                      |                             |                   |           |                    |                   |                |             |        |        |           |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | ShortCircuit      | .NET 10.0 | Wolverine          | ShortCircuit      |    262.3790 ns |   0.4346 ns |      - |      - |         - |
| MediatorBenchmarks.Wolverine         | WolverineBenchmarks         | ShortCircuit      | .NET 11.0 | Wolverine          | ShortCircuit      |    243.9880 ns |   0.5565 ns |      - |      - |         - |
