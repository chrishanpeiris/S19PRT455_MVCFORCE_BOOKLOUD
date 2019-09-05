## Get all data from database

```c#
Controller

public async Task<IActionResult> Index()
{
   return View(await _db.Book.ToListAsync()); //read data in Book table
}

View

<table class="table table-striped">
    <thead>
    <tr> <th>@Html.DisplayNameFor(model => model.Name)</th></tr>
    </thead>
    <tbody>
    @foreach (var item in Model)
    {
        <tr>
            <td> @Html.DisplayTextFor(modelItem => item.Name)</td>
            <td>
                <a asp-action="Edit" asp-route-id="@item.Id">Edit</a> |
                <a asp-action="View" asp-route-id="@item.Id">View</a> |
                <a asp-action="Delete" asp-route-id="@item.Id">Delete</a>
            </td>
        </tr>
    }
    </tbody>
</table>
```

## View single book by bookid

Controller

```c#
  public async Task<IActionResult> View(int? id)
  {
      if (id == null)
      {
          return NotFound();
      }

      var book = await _db.Book
          .FirstOrDefaultAsync(m => m.Id == id);
      if (book == null)
      {
          return NotFound();
      }

      return View(book);
  }
 
View

<div>
  <hr />
  <dl class="row">
      <dt class = "col-sm-2">
          @Html.DisplayNameFor(model => model.Name)
      </dt>
      <dd class = "col-sm-10">
          @Html.DisplayFor(model => model.Name)
      </dd>
  </dl>
</div>
<div>
  <a asp-action="Edit" asp-route-id="@Model.Id">Edit</a> |
  <a asp-action="Index">Go Back to List</a>
</div>
 ```
