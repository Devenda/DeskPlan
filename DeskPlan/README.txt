## Migrations
# This project uses migrations to create the DB
# Open Package Manager Console set DeskPlan.Core as Default Project
Add-Migration Initial
Update-Database
# IMPORTANT: The created DB needs to be included in the bin when running/building, choose 'Copy to output dir': 'Always' in its properties