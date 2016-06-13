.NET Core is a modular development stack that is the fundation of all future .NET platforms

.NET Core has two runtimes: CoreCLR and .NET Native

CoreCLR isn't identical to the CLR but it's very close. The key pieces are virtually identical, so same GC, same JIT, same type system etc.
https://github.com/dotnet/coreclr


In .NET Native, it's obviously a lot more different as .NET Native doesn't have a JIT, but the GC, for example, is the same.


How close is .NET Core Runtime to Mono Runtime?
They are different implementations, done by different people. But both implement the same ECMA CLI standard, so they are quite similar in what they do, but most likely not in how they do it.


ASP.NET Core is a lean and composable framework for building web and cloud applications. ASP.NET Core is fully open source and available on GitHub. ASP.NET Core is available as a Release Candidate on Windows, Mac, and Linux.