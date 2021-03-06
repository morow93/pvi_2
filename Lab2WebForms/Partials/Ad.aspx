﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ad.aspx.cs" Inherits="Lab2WebForms.Partials.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <div class="panel panel-info" data-ng-repeat="post in posts">
        <div class="panel-heading">
            <h3 class="panel-title" data-ng-bind="post.Title"></h3>
        </div>
        <div class="panel-body">
            <div class="post-img">
                <img data-ng-src="{{post.ImagePath}}" alt="post.title" />
            </div>
            <div class="post-text">{{post.Text}}</div>
        </div>
        <div class="panel-footer clearfix">
            <div class="post-time-ago float-left">{{post.DateCreation | fromNow}} от <a href="javascript:void(0)" class="navbar-link">{{post.UserLogin}}</a></div>
            <div data-ng-if="post.UserId == currentUser" class="post-administration float-right">
                <a data-ng-click="edit(post.Id)" href="javascript:void(0)" class="navbar-link">Редактировать</a> / <a data-ng-click="delete(post.Id)" href="javascript:void(0)" class="navbar-link">Удалить</a>
            </div>
        </div>
    </div>

    <nav class="paging" data-ng-if="postsIsFull">
        <ul class="pagination">
            <li><a data-ng-click="getLeft()" href="javascript:void(0)"><span aria-hidden="true">&laquo;</span><span class="sr-only">Previous</span></a></li>
            <li><a href="#">{{currentPage}}</a></li>
            <li><a data-ng-click="getRight()" href="javascript:void(0)"><span aria-hidden="true">&raquo;</span><span class="sr-only">Next</span></a></li>
        </ul>
    </nav>

    <div class="empty-posts">
        <h1 data-ng-if="!postsIsFull">Нет добавленных новостей</h1>
    </div>
</body>
</html>
