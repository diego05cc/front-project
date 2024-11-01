@ModelType ExternalLoginConfirmationViewModel
@Code
    ViewBag.Title = "Registrarse"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>
    <h3>Asocie su cuenta @ViewBag.LoginProvider.</h3>

    @Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.role = "form"})
        @Html.AntiForgeryToken()

        @<text>
        <h4>Formulario de asociación</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <p class="text-info">
            Se ha autenticado correctamente con <strong>@ViewBag.LoginProvider</strong>.
            Introduzca un nombre de usuario para este sitio y haga clic en el botón Registrar para finalizar
            el inicio de sesión.
        </p>
        <div class="row">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="row">
            @Html.LabelFor(Function(m) m.Hometown, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Hometown, New With {.class = "form-control"})
            </div>
        </div>    
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <input type="submit" class="btn btn-outline-dark" value="Registrarse" />
            </div>
        </div>
        </text>
    End Using
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
