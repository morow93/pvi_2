var app = angular.module('Billboard', ['ngRoute', 'ui.bootstrap']);

app.config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                controller: 'WelcomeCtrl',
                templateUrl: '/Partials/Welcome.aspx'
            })
            .when('/login', {
                controller: 'LoginCtrl',
                templateUrl: '/Partials/Welcome.aspx'
            })
            .when('/registration', {
                controller: 'RegisterCtrl',
                templateUrl: '/Partials/Welcome.aspx'
            })
            .when('/advt', {
                controller: 'AdCtrl',
                templateUrl: '/Partials/Ad.aspx'
            })
            .when('/friends', {
                controller: 'FriendsCtrl',
                templateUrl: '/Partials/Friends.aspx'
            })
            .when('/friends/:friend', {
                controller: 'FriendCtrl',
                templateUrl: '/Partials/Ad.aspx'
            })
            .otherwise({ redirectTo: '/' });
    }]);