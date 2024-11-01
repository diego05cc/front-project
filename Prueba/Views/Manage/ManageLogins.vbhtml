﻿@ModelType ManageLoginsViewModel
@Imports Microsoft.Owin.Security
@Imports Microsoft.AspNet.Identity
@Code
    ViewBag.Title = "Administre sus inicios de sesión externos"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    <p class="text-success">@ViewBag.StatusMessage</p>
    @Code
        Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
        If loginProviders.Count = 0 Then
            @<div>
                <p>
                    No existen servicios de autenticación externos configurados. Consulte <a href="https://go.microsoft.com/fwlink/?LinkId=313242">este artículo</a>
                    para obtener información sobre cómo configurar esta aplicación ASP.NET para admitir el inicio de sesión a través de servicios externos.
                </p>
            </div>
        Else
            If Model.CurrentLogins.Count > 0  Then
                @<h4>Inicios de sesión registrados</h4>
                @<table class="table">
                    <tbody>
                        @For Each account As UserLoginInfo In Model.CurrentLogins
                            @<tr>
                                <td>@account.LoginProvider</td>
                                <td>
                                    @If ViewBag.ShowRemoveButton
                                        @Using Html.BeginForm("RemoveLogin", "Manage")
                                            @Html.AntiForgeryToken()
                                            @<div>
                                                @Html.Hidden("loginProvider", account.LoginProvider)
                                                @Html.Hidden("providerKey", account.ProviderKey)
                                                <input type="submit" class="btn btn-outline-dark" value="Quitar" title="Quitar este inicio de sesión @account.LoginProvider de su cuenta" />
                                            </div>
                                        End Using
                                    Else
                                        @: &nbsp;
                                    End If
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            End If
            If Model.OtherLogins.Count > 0
                @<text>
                <h4>Agregue otro servicio para iniciar sesión.</h4>
                <hr />
                </text>
                @Using Html.BeginForm("LinkLogin", "Manage")
                    @Html.AntiForgeryToken()
                    @<div id="socialLoginList">
                    <p>
                        @For Each p As AuthenticationDescription In Model.OtherLogins
                            @<button type="submit" class="btn btn-outline-dark" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="Inicie sesión con su cuenta @p.Caption">@p.AuthenticationType</button>
                        Next
                    </p>
                    </div>
                End Using
            End If
        End If
    End Code
</main>