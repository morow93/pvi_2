<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Lab2WebForms.Partials.Friends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div class="all-users">
        <ul>
            <li data-ng-repeat="user in allusers">{{user.Login}}<a data-ng-click="addFriend(user.Id)" href="javascript:void(0)" class="glyphicon glyphicon-plus"></a></li>
        </ul>
    </div>


    <div class="panel panel-info" data-ng-repeat="friend in friends">
        <div class="panel-heading">
            <h3 class="panel-title clearfix">
                <span class="float-left" data-ng-bind="friend.Login"></span>
                <span class="post-count float-right">Постов: {{friend.CountPosts}} шт.</span>
            </h3>
        </div>
        <div class="panel-body">
            <a href="/friends/{{friend.Login}}">Посмотреть ленту друга</a>
        </div>
    </div>

</body>
</html>
