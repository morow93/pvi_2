<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Lab2WebForms.Partials.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Css/bootstrap.css" rel="stylesheet" />

    <link href="../Content/Css/custom.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <header>
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="/racka">Billboard</a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <form class="navbar-form navbar-right" role="search">
                        <div class="form-group">
                            <input data-ng-change="search()" type="text" data-ng-model="query" class="form-control" placeholder="Поиск">
                        </div>
                        <button type="submit" data-ng-click="search('go')" class="btn btn-default">Поиск</button>
                    </form>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>

        <div class="cntrl-membership">
            <div class="container-fluid">
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse">
                    <div class="navbar-form navbar-right">
                        <p data-ng-if="!isLogged" class="navbar-text"><a href="/registration" class="navbar-link">Регистрация</a></p>
                        <p data-ng-if="!isLogged" class="navbar-text"><a href="/login" class="navbar-link">Войти</a></p>
                        <p data-ng-if="isLogged" class="navbar-text"><a href="/friends" class="navbar-link">Друзья</a></p>
                        <p data-ng-if="isLogged" class="navbar-text"><a href="javascript:void(0)" onclick="window.location.href = '/Partials/Add.aspx'" class="navbar-link">Добавить пост</a></p>
                        <p data-ng-if="isLogged" class="navbar-text"><a data-ng-click="logout()" href="javascript:void(0)" class="navbar-link">Выйти</a></p>
                    </div>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </div>
    </header>

    <form runat="server" method="post" name="addForm" enctype="multipart/form-data">
        <div class="modal-header">
            <button ng-click="closePopup()" type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
            <h4 class="modal-title">Добавление нового поста</h4>
        </div>
        <div class="modal-body">
            <div class="form-group pos-rel input-file">
                <input type="file" name="file" id="file" required />
            </div>
            <div class="form-group pos-rel">
                <input class="form-control field" placeholder="Заголовок" name="Title" required autofocus />
            </div>
            <div class="form-group pos-rel">
                <textarea class="form-control field add-text" placeholder="Текст" name="Text" required></textarea>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="Addpost" class="btn btn-primary-custom" Text="Добавить" runat="server" OnClick="Addpost_Click" />
        </div>
    </form>
</body>
</html>
