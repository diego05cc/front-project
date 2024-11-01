﻿@ModelType ForgotPasswordViewModel
@Code
    ViewBag.Title = "¿Olvidó su contraseña?"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @Using Html.BeginForm("ForgotPassword", "Account", FormMethod.Post, New With {.role = "form"})
        @Html.AntiForgeryToken()
        @<text>
        <h4>Especifique su correo electrónico.</h4>
        <hr />
        @Html.ValidationSummary("", New With {.class = "text-danger"})
        <div class="row">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
            </div>
        </div>
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <input type="submit" class="btn btn-outline-dark" value="Vínculo de correo electrónico" />
            </div>
        </div>
        </text>
    End Using
</main>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
