# EFBlazorBasics CRUD Operations
Demonstrates getting started with Code First Entity Framework Core with a Blazor Server app.

Try the app on <a href="https://efblazorbasicssvronly.azurewebsites.net">azurewebsites.net</a> **Now available _again_ here.**

Mirrors [djaus2/EFBlazorBasics_Wasm](https://github.com/djaus2/EFBlazorBasics_Wasm) which is basic EF CRUD with a a Blazor WASM app.

View Blog Posts [Blazor Helpers App posts on https://davidjones.sportronics.com.au](https://davidjones.sportronics.com.au/search.html?query=Blazor+Helpers+App)

This version demonstrates adding some data to the Helpers App context and displaying of lists in Blazor. 
Includes generating a list of objects from Json which which have referenced list objects.  

See the Entity Framework Core functionality on the FetchData page.
Demonstrates CRUD operations in the Helpers App context.
There are three entities:  
- Activity
- Helper
- Round

A Helper volunteers for an activity.  
An Activity has Task, a Round and a nullable Helper (no Helper has volunteered).  

Can generate data in databse.
This is done via a Json string deserialization and saved to the database.
> Before that, if there are any records still in the database then those records are deleted.
Also the table Id seeds are zeroed.  

Includes Cascade delete and other features.  
Note that deletion of a Round deletes any activity in that round ... Cascade Delete.  
Whereas deletion of a Helper does not delete an activity that the Helper has volunteered for.
It nulls that entry in the activity.

Also can edit records.

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
| [Delete Round]    |  1 |
| [Delete Activity] | 2  |
|[Delete Helper]   | 3  |


