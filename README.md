# Pure.DI Lifetime Regression Repro

This is a minimal console app for comparing the behavior of Pure.DI `2.3.3` and `2.3.4`.

## Purpose

- A composition configured with `DefaultLifetime(Singleton)`
- A concrete class `MyDialog` that is not explicitly registered with `.Bind<MyDialog>()`
- Multiple resolutions through `Func<MyDialog>`

This verifies whether `MyDialog` is created on every resolution or whether the same instance is reused under those conditions.

## Version Comparison

```powershell
dotnet run --project 2.3.3/PureDiLifetimeRegression.csproj
dotnet run --project 2.3.4/PureDiLifetimeRegression.csproj
```

Each version is placed in a separate folder to avoid sharing `obj/bin` outputs.

## Observed Results in the Current Environment

- `2.3.3`: `ReferenceEquals = False`
- `2.3.4`: `ReferenceEquals = True`

## Expected Usage

When attaching this to an issue, include the output difference between `2.3.3` and `2.3.4` as-is.
