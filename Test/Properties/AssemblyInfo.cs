using Microsoft.VisualStudio.TestTools.UnitTesting;

// Workers = 0 → desabilita paralelismo em qualquer Scope
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]