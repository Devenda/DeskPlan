## To Scaffold:
# Open PMC
# Change Default Project to DeskPlan.Core
# Run:
Scaffold-DbContext -Connection name=DeskPlanDatabase Microsoft.EntityFrameworkCore.Sqlite -OutputDir Entities -ContextDir Context -Context DeskPlanContext -Force