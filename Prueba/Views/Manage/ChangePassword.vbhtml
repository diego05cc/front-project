@ModelType ChangePasswordViewModel
@Code
    ViewBag.Title = "Cambiar contraseña"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @Using Html.BeginForm("ChangePassword", "Manage", FormMethod.Post, New With { .role = "form" })
        @Html.AntiForgeryToken()
        @<text>
        <h4>Formulario para cambiar contraseña</h4>
        <hr />
        @Html.ValidationSummary("", New With { .class = "text-danger" })
        <div class="row">
            @Html.LabelFor(Function(m) m.OldPassword, New With { .class = "col-md-2 col-form-label" })
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.OldPassword, New With { .class = "form-control" })
            </div>
        </div>
        <div class="row">
            @Html.LabelFor(Function(m) m.NewPassword, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
            </div>
        </div>
        <div class="row">
            @Html.LabelFor(Function(m) m.ConfirmPassword, New With { .class = "col-md-2 col-form-label" })
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With { .class = "form-control" })
            </div>
        </div>
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <input type="submit" value="Cambiar contraseña" class="btn btn-outline-dark" />
            </div>
        </div>
        </text>
    End Using
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section