run:
	tmux split-window "dotnet run --project ReportsAPI/ReportsAPI.csproj"
	tmux split-window "dotnet run --project Services/WorkerUpdater/WorkerUpdater.csproj"
