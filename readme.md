``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.200
  [Host]     : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT
  DefaultJob : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT


|                Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|---------------------- |----------:|----------:|----------:|------:|--------:|
|        float_standard |  4.486 ms | 0.0894 ms | 0.1282 ms |  1.00 |    0.00 |
| float_FastInverseSqrt | 30.929 ms | 0.2492 ms | 0.2331 ms |  6.89 |    0.22 |
