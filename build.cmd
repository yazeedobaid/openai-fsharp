﻿echo Restoring dotnet tools...
dotnet tool restore

dotnet run --project Build -- %*