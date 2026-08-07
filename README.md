# ExamenOnlineGokken - Entity Framework Core oefening

Uitwerking van de EF Core oefening (12 punten) op de bestaande `ExamenOnlineGokken` starter.

## Opdracht -> commits

- **a)** `League` entity (Id, verplichte Name max 200 tekens) - zie commit `a) Add League entity ...`
- **b)** Een-op-veel relatie League-Game met Navigation Properties en FK property `LeagueId` op `Game` - zie commits `b) ...`
- **c)** Migration `AddedLeague` - zie commits `c) ...`
- **d)** Seeding van de vier Leagues in `Seeder.cs` - zie commit `d) Seed the four Leagues in Seeder.cs`
- **e)** Koppelen van elke Game aan zijn League via `LeagueId` in dezelfde seeding-code - zie commit `e) Link each seeded Game to its League via LeagueId`
- **f)** Migration `AddedSeeding` - zie commits `f) ...`

## Opmerking bij de migraties

`Game.LeagueId` is nullable (`long?`) op databankniveau. De `Games`-tabel bevatte al seed-data uit de
oorspronkelijke `First` migration, dus een niet-nullable FK zou bij het toevoegen van de constraint
falen (er bestaat op dat moment nog geen League om naar te verwijzen). De League-koppeling zelf is wel
altijd ingevuld: `AddedSeeding` vult `LeagueId` voor elke Game in nadat de Leagues zijn aangemaakt.

## Lokaal opzetten

```
cd ExamenOnlineGokken.Web
dotnet ef database update
dotnet run
```

Connection string (SQL Server Express) staat in `appsettings.json`.
