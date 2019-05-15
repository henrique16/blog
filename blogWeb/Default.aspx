<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="blogWeb.Home.Home" %>

<%@ Import Namespace="blogWeb.Pages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <meta name="author" content="Gabriel Henrique de Oliveira" />
    <title>web blog</title>
    <%--<link rel="icon" href="img/globe.png" runat="server" type="image/x-icon"/>--%>
    <link rel="stylesheet" href="Style/css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU"
        crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="header">
            <div class="head-1">
                <div class="logo">
                    <a href="Default.aspx"><i class="fas fa-globe"></i>web blog</a>
                </div>
                <div class="login" runat="server" id="login" onclick="showLogin()">
                    <h2>Login <i class="fas fa-angle-down"></i></h2>
                </div>
                <div class="logout" runat="server" id="logout">
                    <a href="Default.aspx" runat="server">Logout</a>
                </div>
            </div>
            <div class="head-2">
                <div class="pesquisa">
                    <input type="text" placeholder="Pesquisar" />
                    <i class="fas fa-search"></i>
                </div>
                <div class="menu">
                    <ul>
                        <li id="Estatistica" runat="server" onclick="showEstatistica()">Estatistícas <i class="fas fa-angle-down"></i></li>
                        <li id="Perfil" runat="server" onclick="showPerfil()">Perfil <i class="fas fa-angle-down"></i></li>
                        <li class="comunidade-li" onclick="showComunidade()">Comunidade <i class="fas fa-angle-down"></i></li>
                        <li class="sobre-li" onclick="showSobre()">SOBRE <i class="fas fa-angle-down"></i></li>
                    </ul>
                </div>
            </div>
        </header>
        <div id="entrarGlobal" class="entrar-global">
            <div class="entrar">
                <div class="contents">
                    <input runat="server" id="inputTextLogin" type="text" placeholder="Login" />
                    <input runat="server" id="inputTextSenha" type="password" placeholder="Senha" />
                    <asp:Button CssClass="btnEntrar" ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click"/>
                </div>
            </div>
        </div>
        <div id="Sobre" class="sobre-global">
            <div class="sobre">
                <div class="sobre-texto">
                    <h2>Sobre Nós</h2>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore
                    et
                    dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut
                    aliquip
                    ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum
                    dolore
                    eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                    </p>
                </div>
                <div class="sobre-img">
                    <img src="Style/img/certificate.png" height="245px" />
                </div>
            </div>
        </div>
        <div id="Comunidade" class="comunidade">
            <div class="lista-blog">
                <h1>Blogs</h1>
                <asp:Label CssClass="labelBlog" ID="ltListaBlogs" runat="server" />
            </div>
            <div class="lista-assunto">
                <h1>Assuntos</h1>
                <asp:Label CssClass="labelAssunto" ID="listaAssunto" runat="server" />
            </div>
        </div>
        <div class="banner" runat="server" id="divBanner">
            <div id="bannerCadastro" class="texto-banner">
                <h2>Web Blog</h2>
                <p>
                    Mantenha-se conectado com tecnologias, assuntos e discussões atuais,
                e nos ajude compartilhando seus conhecimentos.
                </p>
                <h3 class="btn-cadastrar" onclick="showCadastro()">Cadastrar-se</h3>
            </div>
            <div class="cadastro" runat="server" id="divCadastro">
                <div class="btn-cadastro-close" onclick="closeCadastro()">
                    <h3>x</h3>
                </div>
                <ul>
                    <li>
                        <input runat="server" id="cadastroNome" type="text" placeholder="Nome" /></li>
                    <li>
                        <input runat="server" id="cadastroUsuario" type="text" placeholder="Usuário" /></li>
                    <li>
                        <input runat="server" id="cadastroEmail" type="text" placeholder="E-mail" /></li>
                    <li>
                        <input runat="server" id="cadastroSenha" type="password" placeholder="Senha" /></li>
                </ul>
                <asp:Button CssClass="btnConfirmar" ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
            </div>
            <div class="img-banner">
                <img src="Style/img/website-512.png" height="245px" />

            </div>
        </div>
        <asp:HiddenField ID="Mensagens" runat="server" />
        <asp:HiddenField ID="Result" runat="server" />
        <asp:HiddenField ID="Objeto" runat="server" />
        <script>

            function showLogin() {
                if (document.getElementById('entrarGlobal').style.display == '')
                    document.getElementById('entrarGlobal').style.display = 'inherit';
                else {
                    document.getElementById('inputTextLogin').value = '';
                    document.getElementById('inputTextSenha').value = '';
                    document.getElementById('entrarGlobal').style.display = '';
                }
            }

            function showSobre() {
                if (document.getElementById('Sobre').style.display == '')
                    document.getElementById('Sobre').style.display = 'inherit';
                else
                    document.getElementById('Sobre').style.display = '';
            }

            function showComunidade() {
                if (document.getElementById('Comunidade').style.display == '')
                    document.getElementById('Comunidade').style.display = 'inherit';
                else
                    document.getElementById('Comunidade').style.display = '';
            }

            function showPerfil() {
                if (document.getElementById('Perfil').style.display == '')
                    document.getElementById('Perfil').style.display = 'inherit';
                else
                    document.getElementById('Perfil').style.display = '';
            }

            function showEstatistica() {
                if (document.getElementById('Estatistica').style.display == '')
                    document.getElementById('Estatistica').style.display = 'inherit';
                else
                    document.getElementById('Estatistica').style.display = '';
            }

            function showCadastro() {
                document.getElementById('divCadastro').style.display = 'inherit';
            }

            function closeCadastro() {
                document.getElementById('cadastroNome').value = '';
                document.getElementById('cadastroUsuario').value = '';
                document.getElementById('cadastroEmail').value = '';
                document.getElementById('cadastroSenha').value = '';
                document.getElementById('divCadastro').style.display = '';
            }

            function Mensagens() {
                window.confirm(document.getElementById('Mensagens').value);
            };

            function ResultadoOk() {
                if (document.getElementById('Result').value == 'True')
                    return true;
                else
                    return false;
            }

            debugger
            function CadastroOk() {
                Mensagens();
                var result = ResultadoOk();
                if (result == true) {
                    document.getElementById('entrarGlobal').style.display = 'inherit'
                    var obj = JSON.parse(document.getElementById('Objeto').value);
                    document.getElementById('inputTextLogin').value = obj.login_id

                    document.getElementById('cadastroNome').value = '';
                    document.getElementById('cadastroUsuario').value = '';
                    document.getElementById('cadastroEmail').value = '';
                    document.getElementById('cadastroSenha').value = '';
                }
            }

        </script>
    </form>
</body>
</html>
