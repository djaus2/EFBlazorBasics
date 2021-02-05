# EFBlazorBasics
Demonstrates getting started with Code First Entity Framework Core with a Blazor Server app.

View Blog Posts [Blazor Helpers App posts on https://davidjones.sportronics.com.au](https://davidjones.sportronics.com.au/search.html?query=Blazor+Helpers+App)

This version demonstrates adding some data to the Helpers App context and displaying of lists in Blazor. 
Includes generating a list of objects from Json which which have referenced list objects.  

Replaces WeatherForecast with Helper Data.

See the Entity Framework Core functionality on FetchData page.
Demonstrates CRUD operations in the Helpers App context.
Includes Cascade delete and other features.
Note that deletion of a Round deletes any activity in that round ... Cascade Delete
Whereas deletion of a Helper does not delete an activity that that Helper has volunteered for.
It nulls that entry in the activity.

<hr/>

## The UI

### Activitys

| **Id** | **Round** | **Helper**  | **Task** |
|--------|-----------|-------------|----------|
| 1      | 1         | John Marshall | Shot Put   |
| 2      | 2         | Sue Burrows | Marshalling   |
| 3      | 3         | Jimmy Beans | Discus   |

## Helpers

| **Id** | **Name**    |
|--------|-------------|
| 1      | John Marshall |
| 2      | Sue Burrows |
| 3      | Jimmy Beans |

## Rounds

| **Id** | **Round No.** |
|--------|---------------|
| 1      | 1             |
| 2      | 2             |
| 3      | 3             |

## _Actions:_

| **Action**    |   |
|-----------------|---|
| [Delete Round]    |  3 |
| [Delete Activity] | 3  |
|[Delete Helper]   | 3  |


