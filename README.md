A minimal Test Repo for [#6473](https://github.com/aspnet/AspNetCore/issues/6473)

Branches:

1. `Master` : It runs flawlessly on Win10 and hangs on CentOS7
2. `AsyncTest` : As suggested by [javiercn](https://github.com/aspnet/AspNetCore/issues/6473#issuecomment-452902783), I change the XUnit to use `async Task` and finally solve this problem.


Is there a dark magic which happens on Win10 that helps us avoid the Deadlock ?
