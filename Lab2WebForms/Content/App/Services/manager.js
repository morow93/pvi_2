angular.module('Billboard')
    .factory('Manager', ['$http', '$location', '$rootScope',
        function ($http, $location, $rootScope) {

            var api = {};

            api.Posts = function (page, query) {
                return $http.post('/Services/Post.asmx/Posts', { page: page, query: query }).then(function (results) {
                    return results.data.d;
                })
            };

            api.deletePost = function (id) {
                return $http.post('/Services/Post.asmx/DeletePost', { id: id }).then(function (results) {
                    if (results.data.d) {
                        $rootScope.Alert('info', 'Объявление удалено.');
                    } else {
                        $rootScope.Alert('danger', 'Произошла внутренняя ошибка. Приносим свои извенения. Попробуйте позже');
                    }
                });
            };

            api.savePost = function (post) {
                return $http.post('/Services/Post.asmx/SavePost',
                    {
                        id: post.id,
                        title: post.title,
                        text: post.text
                    }).then(function (results) {
                        if (results.data.d) {
                            $rootScope.m.dismiss('cancel');
                            $rootScope.Alert('info', 'Объявление изменено.');
                        } else {
                            $rootScope.Alert('danger', 'Произошла внутренняя ошибка. Приносим свои извенения. Попробуйте позже');
                        }
                    });
            };

            api.Friends = function (userId) {
                return $http.post('/Services/UserService.asmx/Friends', { userId: userId }).then(function (results) {
                    return results.data.d;
                })
            };

            api.FriendsPost = function (login) {
                return $http.post('/Services/Post.asmx/FriendsPosts', { login: login }).then(function (results) {
                    return results.data.d;
                })
            };

            api.AllUsers = function () {
                return $http.post('/Services/UserService.asmx/AllUsers', {}).then(function (results) {
                    return results.data.d;
                })
            };

            api.AddUserToFriends = function (id) {
                return $http.post('/Services/UserService.asmx/AddToFriend', { id: id }).then(function (results) {
                    return results.data.d;
                })
            };

            return api;
        }
    ]);