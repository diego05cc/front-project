﻿@ModelType ExternalLoginListViewModel
@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code
<h4>Utilice otro servicio para iniciar sesión.</h4>
<hr />
@If loginProviders.Count() = 0 Then
    @<div>
          <p>
              No existen servicios de autenticación externos configurados. Consulte <a href="https://go.microsoft.com/fwlink/?LinkId=403804">este artículo</a>
              para obtener información sobre cómo configurar esta aplicación ASP.NET para admitir el inicio de sesión a través de servicios externos.
          </p>
    </div>
Else
    @Using Html.BeginForm("ExternalLogin", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.role = "form"})
        @Html.AntiForgeryToken()
        @<div id="socialLoginList">
           <p>
               @For Each p As AuthenticationDescription In loginProviders
                   @<button type="submit" class="btn btn-outline-dark" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="Inicie sesión con su cuenta @p.Caption">@p.AuthenticationType</button>
               Next
           </p>
        </div>
    End Using
End If
