@ModelType SetPasswordViewModel
@Code
    ViewBag.Title = "Crear contraseña"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>
    <p class="text-info">
        No dispone de un nombre de usuario o contraseña local para este sitio. Agregue una cuenta
        local para iniciar sesión sin que sea necesario ningún inicio de sesión externo.
    </p>

    @Using Html.BeginForm("SetPassword", "Manage", FormMethod.Post, New With { .role = "form" })
        @Html.AntiForgeryToken()
        @<text>
        <h4>Crear inicio de sesión local</h4>
        <hr />
        @Html.ValidationSummary("", New With { .class = "text-danger" })
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
                <input type="submit" value="Establecer contraseña" class="btn btn-outline-dark" />
            </div>
        </div>
        </text>
    End Using
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section