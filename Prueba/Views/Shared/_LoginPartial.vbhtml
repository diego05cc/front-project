﻿@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated
    @Using Html.BeginForm("LogOff", "Account", New With { .area = "" }, FormMethod.Post, New With { .id = "logoutForm", .class = "navbar-right" })
        @Html.AntiForgeryToken()
        @<ul class="navbar-nav navbar-right">
            <li>
                @Html.ActionLink("Hola " + User.Identity.GetUserName() + "!", "Index", "Manage", routeValues := New With { .area = "" }, htmlAttributes := New With { .title = "Manage", .class = "nav-link" })
            </li>
            <li><a class="nav-link" href="javascript:sessionStorage.removeItem('accessToken');$('#logoutForm').submit();">Cerrar sesión</a></li>
        </ul>
    End Using
Else
    @<ul class="navbar-nav navbar-right">
        <li>@Html.ActionLink("Registrarse", "Register", "Account", routeValues := New With { .area = "" }, htmlAttributes := New With { .id = "registerLink", .class = "nav-link" })</li>
        <li>@Html.ActionLink("Iniciar sesión", "Login", "Account", routeValues := New With { .area = "" }, htmlAttributes := New With { .id = "loginLink", .class = "nav-link" })</li>
    </ul>
End If
