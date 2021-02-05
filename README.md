# EFBlazorBasics - Add Some Data
Demonstrates getting started with Code First Entity Framework Core with a Blazor Server app.

View Blog Posts [Blazor Helpers App posts on https://davidjones.sportronics.com.au](https://davidjones.sportronics.com.au/search.html?query=Blazor+Helpers+App)

This version demonstrates adding some data to the Helpers App context and displaying of lists in Blazor. 
Includes generating a list of objects from Json which which have referenced list objects.  

Replaces WeatherForecast with Helper Data.

See the Entity Framework Core functionality on the **FetchData** page.
Demonstrates Create and Add SQL operations in the Helpers App context.  

There are three entities:  
- Activity
- Helper
- Round

A Helper volunteers for an activity.  
An Activity has Task, a Round and a nullable Helper (no Helper has volunteered).  

When the **FetchData** page is loaded, or refreshed, a call is made to get the Activitys list.  
If the Activitys is empty, a call is made to generate the data.
This is done via a Json string deserialization and saved to the database.

The three entity lists are then loaded.  

This version of the app only displays the sample data in that razor page  

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

| Next: See the **CRUD** branch of the repository. |
| Link: [CRUD branch of djaus2/EFBlazorBasics on GitHub](https://github.com/djaus2/EFBlazorBasics/tree/CRUD) |
