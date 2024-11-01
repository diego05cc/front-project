@ModelType AddPhoneNumberViewModel
@Code
    ViewBag.Title = "Número de teléfono"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @Using Html.BeginForm("AddPhoneNumber", "Manage", FormMethod.Post, New With { .role = "form" })
        @Html.AntiForgeryToken()
        @<text>
        <h4>Agregar un número de teléfono</h4>
        <hr />
        @Html.ValidationSummary("", New With { .class = "text-danger" })
        <div class="row">
            @Html.LabelFor(Function(m) m.Number, New With { .class = "col-md-2 col-form-label" })
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Number, New With{ .class = "form-control" })
            </div>
        </div>
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <input type="submit" class="btn btn-outline-dark" value="Enviar" />
            </div>
        </div>
        </text>
    End Using
</main>    

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
